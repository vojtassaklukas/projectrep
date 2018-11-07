using System.Collections.ObjectModel;
using System.Windows;
using MainApplication.Classes;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for FindOwnerPropertiesForm.xaml
    /// </summary>
    public partial class FindOwnerPropertiesForm : Window
    {
        private bool warning = false;
        public ObservableCollection<Property> Properties { get; set; }
        public ObservableCollection<int> Interests { get; set; }

        public FindOwnerPropertiesForm()
        {
            InitializeComponent();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddcadastralArea_OnClick(object sender, RoutedEventArgs e)
        {
            string ean = CheckTextBox(CitizenEan.Text);

            if (!warning)
            {          
                Citizen citizen = State.Instance.Citizens.Find(ean);
                Properties = new ObservableCollection<Property>();
                Interests = new ObservableCollection<int>();
                if (citizen != null)
                {
                    var showProperties = new ShowOwnerPropertiesCadastral();
                    showProperties.Show();
                    showProperties.CitizenProperties.ItemsSource = Properties;
                    showProperties.PropertyInterests.ItemsSource = Interests;

                    foreach (Property p in citizen.AllProperties.GetDataEnumerator())
                    {
                        Properties.Add(p);
                        int interest = p.PropertyList.Owners.Find(citizen.EAN).Interest;
                        Interests.Add(interest);
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show("Citizen with such ean doesnt exist.", "Alert", MessageBoxButton.OK);
                }
                    
            }
            warning = false;
        }

        private string CheckTextBox(string text)
        {
            if (string.IsNullOrWhiteSpace(text) && warning == false)
            {
                MessageBox.Show("Fill all the blank spaces", "Warning", MessageBoxButton.OK);
                warning = true;
            }
            return text;
        }
    }
}
