using System;
using System.Collections.ObjectModel;
using System.Windows;
using MainApplication.Classes;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for FindPropertyCadastralIdForm.xaml
    /// </summary>
    public partial class FindPropertyCadastralIdForm : Window
    {
        private bool warning = false;
        public Property Property { get; set; }
        public ObservableCollection<Citizen> PermanentPeople { get; set; }
        public PropertyList PropertyList { get; set; }
        public ObservableCollection<Property> PropertyListProperties { get; set; }
        public ObservableCollection<OwnershipInterest> PropertyListOwners { get; set; }

        public FindPropertyCadastralIdForm()
        {
            InitializeComponent();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FindProperty_OnClick(object sender, RoutedEventArgs e)
        {
            int cadastralId;
            int propertyId;

            if (Int32.TryParse(CheckTextBox(CadastralId.Text), out cadastralId))
            {
                if (!warning)
                {
                    Cadastral cadastral = State.Instance.CadastralAreas.Find(cadastralId);
                    if (cadastral != null)
                    {
                        if (Int32.TryParse(CheckTextBox(PropertyId.Text), out propertyId))
                        {
                            PermanentPeople = new ObservableCollection<Citizen>();
                            PropertyListProperties = new ObservableCollection<Property>();
                            PropertyListOwners = new ObservableCollection<OwnershipInterest>();
                            Property property = cadastral.CadastralProperties.Find(propertyId);
                            if (property != null)
                            {
                                var showPropertyfound = new ShowPropertyById();
                                showPropertyfound.Show();

                                foreach (Citizen c in property.PermanentPeople.GetDataEnumerator())
                                {
                                    PermanentPeople.Add(c);
                                }

                                foreach (Property p in property.PropertyList.Properties.GetDataEnumerator())
                                {
                                    PropertyListProperties.Add(p);
                                }

                                foreach (OwnershipInterest o in property.PropertyList.Owners.GetDataEnumerator())
                                {
                                    PropertyListOwners.Add(o);
                                }

                                Property = property;
                                PropertyList = property.PropertyList;

                                showPropertyfound.PropertyListInformation.Items.Add(PropertyList);
                                showPropertyfound.PropertyInformation.Items.Add(property);

                                showPropertyfound.PermanentsInformation.ItemsSource = PermanentPeople;
                                showPropertyfound.PropertyListProperties.ItemsSource = PropertyListProperties;
                                showPropertyfound.PropertyListOwners.ItemsSource = PropertyListOwners;

                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Property with such id doesn't exist.", "Alert", MessageBoxButton.OK);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Property id must be a number.", "Alert", MessageBoxButton.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cadastral area with such id doesn't exist.", "Alert", MessageBoxButton.OK);
                    }
                }
                warning = false;
            }
            else
            {
                MessageBox.Show("Cadastral area id must be a number.", "Alert", MessageBoxButton.OK);
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
