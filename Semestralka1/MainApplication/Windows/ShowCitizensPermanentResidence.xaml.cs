using System.Collections.ObjectModel;
using System.Windows;
using MainApplication.Classes;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for ShowCitizensPermanentResidence.xaml
    /// </summary>
    public partial class ShowCitizensPermanentResidence : Window
    {
        private bool warning = false;
        public Property Property { get; set; }
        public ObservableCollection<Citizen> PermanentPeople { get; set; }
        public PropertyList PropertyList { get; set; }
        public ShowCitizensPermanentResidence()
        {
            InitializeComponent();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FindCitizensPermanentResidence_OnClick(object sender, RoutedEventArgs e)
        {
            var ean = CheckTextBox(CitizensId.Text);

            if (!warning)
            {
                Citizen citizen = State.Instance.Citizens.Find(ean);
                PermanentPeople = new ObservableCollection<Citizen>();

                if (citizen != null )
                {
                    if (citizen.PermanentResidance != null)
                    {
                        var showPermanentResidence = new ShowPermanentResidence();
                        showPermanentResidence.Show();

                        foreach (Citizen c in citizen.PermanentResidance.PermanentPeople.GetDataEnumerator())
                        {
                            PermanentPeople.Add(c);
                        }

                        Property = citizen.PermanentResidance;
                        PropertyList = citizen.PermanentResidance.PropertyList;

                        showPermanentResidence.PropertyListInformation.Items.Add(PropertyList);
                        showPermanentResidence.PropertyInformation.Items.Add(Property);

                        showPermanentResidence.PermanentsInformation.ItemsSource = PermanentPeople;

                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Citizen doesn't have a permanent residence", "Alert", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Citizen with this EAN doesn't exist", "Alert", MessageBoxButton.OK);
                }
            }
        }

        private string CheckTextBox(string text)
        {
            if (string.IsNullOrWhiteSpace(text) && warning == false)
            {
                MessageBox.Show("You have to fill all blank spaces.", "Warning", MessageBoxButton.OK);
                warning = true;
            }
            return text;
        }
    }
}
