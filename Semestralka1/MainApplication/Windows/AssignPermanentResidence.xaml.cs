using System;
using System.Windows;
using MainApplication.Classes;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for AssignPermanentResidence.xaml
    /// </summary>
    public partial class AssignPermanentResidence : Window
    {
        private bool warning;
        public AssignPermanentResidence()
        {
            InitializeComponent();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AssignPermanentResidence_OnClick(object sender, RoutedEventArgs e)
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
                            Citizen citizen = State.Instance.Citizens.Find(CheckTextBox(Ean.Text));
                            if (!warning)
                            {
                                if (citizen != null)
                                {
                                    if (citizen.PermanentResidance != null)
                                    {
                                        citizen.PermanentResidance.PermanentPeople.Delete(Ean.Text); // vymazanie stareho trvaleho pobytu ak nejaky bol
                                    }                              
                                    citizen.PermanentResidance = property;
                                    if (!property.PermanentPeople.Insert(Ean.Text, citizen))
                                    {
                                        MessageBox.Show("Citizens permanent residence is already registered", "Warning", MessageBoxButton.OK);
                                        Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Citizen permanent residence assigned", "Warning", MessageBoxButton.OK);
                                        Close();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Citizen with such EAN doesn't exist", "Warning", MessageBoxButton.OK);
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
