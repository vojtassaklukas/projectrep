using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MainApplication.Classes;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for FindPropertyByCadastralName.xaml
    /// </summary>
    public partial class FindPropertyByCadastralName : Window
    {
        private bool warning = false;
        public Property Property { get; set; }
        public ObservableCollection<Citizen> PermanentPeople { get; set; }
        public PropertyList PropertyList { get; set; }
        public ObservableCollection<Property> PropertyListProperties { get; set; }
        public ObservableCollection<OwnershipInterest> PropertyListOwners { get; set; }

        public FindPropertyByCadastralName()
        {
            InitializeComponent();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FindProperty_OnClick(object sender, RoutedEventArgs e)
        {
            string cadastralName = CheckTextBox(CadastralName.Text);
            int propertyId;

            if (!warning)
                {
                    Cadastral cadastral = State.Instance.CadastralAreasByName.Find(cadastralName);
                    if (cadastral != null)
                    {
                        if (Int32.TryParse(CheckTextBox(PropertyId.Text), out propertyId))
                        {
                            if (!warning)
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
                        }
                        else
                        {
                            MessageBox.Show("Property id must be a number.", "Alert", MessageBoxButton.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cadastral area with such name doesn't exist.", "Alert", MessageBoxButton.OK);
                    }
                }
                warning = false;
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
