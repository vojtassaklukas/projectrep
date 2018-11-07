using System;
using System.Windows;
using System.Xml.Schema;
using MainApplication.Classes;
using Structures;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for AddPropertyForm.xaml
    /// </summary>
    public partial class AddPropertyForm : Window
    {
        private readonly Cadastral usedCadastral;
        private readonly PropertyList usedPropertyList;
        private bool warning = false;

        public AddPropertyForm(Cadastral currentCadastral, PropertyList propertyList)
        {
            InitializeComponent();
            usedCadastral = currentCadastral;
            usedPropertyList = propertyList;
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddProperty_OnClick(object sender, RoutedEventArgs e)
        {
            Property property = new Property(State.Instance.PropertyNumerator, CheckTextBox(PropertyAdress.Text), CheckTextBox(PropertyDescription.Text));
            if (warning != true)
            {
                usedCadastral.CadastralProperties.Insert(State.Instance.PropertyNumerator, property);

                foreach (OwnershipInterest o in usedPropertyList.Owners.GetDataEnumerator())
                {
                    o.Citizen.AllProperties.Insert(property.PropertyId, property); // pridam na list všetkych properties

                    AvlTree<int, Property> foundTree = o.Citizen.PropertiesByCadastral.Find(usedCadastral.CadastralId); // zistim ci mam uz strom na property s takym catastrom
                    if (foundTree != null) // ak hej
                    {
                        foundTree.Insert(property.PropertyId, property); // pridam tam tu property
                    }
                    else // ak nie
                    {
                        o.Citizen.PropertiesByCadastral.Insert(usedCadastral.CadastralId, new AvlTree<int, Property>()); // tak najprv spravim novy strom
                        o.Citizen.PropertiesByCadastral.Find(usedCadastral.CadastralId).Insert(property.PropertyId, property); // potom ho najdem a vlozim do neho
                    }
                }

                usedPropertyList.Properties.Insert(property.PropertyId, property);
                property.PropertyList = usedPropertyList;
                State.Instance.PropertyNumerator++;
                MessageBox.Show("Property added.", "Alert", MessageBoxButton.OK);
                Close();
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
