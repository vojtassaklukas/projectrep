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

                if (citizen != null )
                {
                    if (citizen.PermanentResidance != null)
                    {
                        citizen.ResidenceFound += OnResidenceFound;

                        citizen.FindPermanentResidence();

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

        private void OnResidenceFound(object source, ResidenceFoundEventArgs e)
        {
            var showPermanentResidence = new ShowPermanentResidence();
            showPermanentResidence.Show();

            showPermanentResidence.PropertyListInformation.Items.Add(e.PropertyList);
            showPermanentResidence.PropertyInformation.Items.Add(e.Property);

            showPermanentResidence.PermanentsInformation.ItemsSource = e.PermanentPeople;
        }
    }
}
