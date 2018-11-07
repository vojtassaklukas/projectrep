using System;
using System.Windows;
using MainApplication.Classes;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for DeletePropertyForm.xaml
    /// </summary>
    public partial class DeletePropertyForm : Window
    {
        private bool warning = false;
        public DeletePropertyForm()
        {
            InitializeComponent();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DeleteProperty_OnClick(object sender, RoutedEventArgs e)
        {
            int cadastralId;
            int propertyId;
            int propertyListId;

            if (Int32.TryParse(CheckTextBox(CadasterId.Text), out cadastralId))
            {
                if (Int32.TryParse(CheckTextBox(PropertyListId.Text), out propertyListId))
                {
                    if (Int32.TryParse(CheckTextBox(PropertyId.Text), out propertyId))
                    {
                        if (!warning)
                        {
                            Cadastral cadastral = State.Instance.CadastralAreas.Find(cadastralId);
                            if (cadastral != null)
                            {
                                PropertyList propertyList = cadastral.PropertyLists.Find(propertyListId);
                                if (propertyList != null)
                                {
                                    Property property = propertyList.Properties.Find(propertyId);
                                    if (property != null)
                                    {
                                        foreach (Citizen c in property.PermanentPeople.GetDataEnumerator()) // všetkym z nej odstranim trvaly pobyt
                                        {
                                            c.PermanentResidance = null;
                                        }

                                        foreach (OwnershipInterest oi in propertyList.Owners.GetDataEnumerator()) // zmazať ownerovi z dvoch stromov
                                        {
                                            oi.Citizen.AllProperties.Delete(property.PropertyId);
                                            oi.Citizen.PropertiesByCadastral.Find(cadastralId).Delete(propertyId);
                                        }
                                        propertyList.Properties.Delete(property.PropertyId);
                                        cadastral.CadastralProperties.Delete(property.PropertyId);
                                        Close();

                                        MessageBox.Show("Property removed", "Warning", MessageBoxButton.OK);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Property with such id doesn't exist", "Warning", MessageBoxButton.OK);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Property list with such id doesn't exist", "Warning", MessageBoxButton.OK);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Cadastral with such id doesn't exist", "Warning", MessageBoxButton.OK);
                            }
                        }
                        warning = false;
                    }
                    else
                    {
                        MessageBox.Show("Property id must be a number.", "Warning", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Property list id must be a number.", "Warning", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Cadastral id must be a number.", "Warning", MessageBoxButton.OK);
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
