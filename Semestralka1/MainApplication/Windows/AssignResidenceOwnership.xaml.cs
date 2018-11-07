using System;
using System.Windows;
using MainApplication.Classes;
using Structures;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for AssignResidenceOwnership.xaml
    /// </summary>
    public partial class AssignResidenceOwnership : Window
    {
        private bool warning;
        public AssignResidenceOwnership()
        {
            InitializeComponent();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AssignOwnership_OnClick(object sender, RoutedEventArgs e)
        {
            int cadastalId;
            int propertyId;
            warning = false;

            if (Int32.TryParse(CheckTextBox(CadastralId.Text), out cadastalId))
            {
                Cadastral cadastral = State.Instance.CadastralAreas.Find(cadastalId);
                if (cadastral != null)
                {
                    if (Int32.TryParse(CheckTextBox(PropertyId.Text), out propertyId))
                    {
                        Property property = cadastral.CadastralProperties.Find(propertyId);
                        if (property != null)
                        {
                            Citizen oldOwner = State.Instance.Citizens.Find(CheckTextBox(OldOwner.Text));
                            Citizen newOwner = State.Instance.Citizens.Find(CheckTextBox(NewOwner.Text));
                            if (!warning)
                            {
                                if (oldOwner != null)
                                {
                                    if (newOwner != null)
                                    {
                                        foreach (Property p in property.PropertyList.Properties.GetDataEnumerator())
                                        {
                                            oldOwner.AllProperties.Delete(p.PropertyId); // staremu zmazem zo vsetkych
                                            oldOwner.PropertiesByCadastral.Find(cadastalId).Delete(p.PropertyId); // staremu zmazem zo vsetkych podla katastra
                                        }

                                        OwnershipInterest Oldownership = property.PropertyList.Owners.Find(oldOwner.EAN); // podiel stareho
                                        OwnershipInterest Newownership = property.PropertyList.Owners.Find(newOwner.EAN); // podiel noveho
                                        int oldCitizenInterest = Oldownership.Interest;

                                        if (Newownership != null) // ak sa novy nachadzal na liste vlastnictva
                                        {
                                            Newownership.Interest = Newownership.Interest + oldCitizenInterest;
                                            property.PropertyList.Owners.Delete(oldOwner.EAN);
                                        }
                                        else // ak na liste vlastnicvta nebol
                                        {
                                            foreach (Property p in property.PropertyList.Properties.GetDataEnumerator()) // novemu priradim nehnutelnosti
                                            {
                                                newOwner.AllProperties.Insert(p.PropertyId, p);

                                                AvlTree<int, Property> foundTree = newOwner.PropertiesByCadastral.Find(cadastral.CadastralId);
                                                if (foundTree != null) // ak hej
                                                {
                                                    foundTree.Insert(p.PropertyId, p);
                                                }
                                                else // ak nie
                                                {
                                                    newOwner.PropertiesByCadastral.Insert(cadastral.CadastralId, new AvlTree<int, Property>());
                                                    newOwner.PropertiesByCadastral.Find(cadastral.CadastralId).Insert(p.PropertyId, p);
                                                }
                                            }
                                            OwnershipInterest newInterest = new OwnershipInterest(newOwner, Oldownership.Interest); // spravim mu podiel, ma podiel toho stareho
                                            property.PropertyList.Owners.Insert(newOwner.EAN,newInterest); // podiel dam do listu
                                            property.PropertyList.Owners.Delete(oldOwner.EAN);
                                        }

                                        MessageBox.Show("Property owner assigned", "Warning", MessageBoxButton.OK);
                                        Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("New owner ean is invalid", "Warning", MessageBoxButton.OK);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Old owner ean is invalid", "Warning", MessageBoxButton.OK);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Property with such Id doesn't exist", "Warning", MessageBoxButton.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Property Id must be a number", "Warning", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Cadastral with such Id doesn't exist", "Warning", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Cadastral Id must be a number", "Warning", MessageBoxButton.OK);
            }
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
