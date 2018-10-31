using System;
using System.Windows;
using MainApplication.Classes;

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
            int registerNumber;

            if (Int32.TryParse(CheckTextBox(RegisterNumber.Text), out registerNumber))
            {
                Property property = new Property(registerNumber, CheckTextBox(PropertyAdress.Text), CheckTextBox(PropertyDescription.Text));
                if (warning != true)
                {
                    if (!usedPropertyList.Properties.Insert(registerNumber, property))
                    {
                        MessageBox.Show("Property register number in this property list already in use.", "Alert", MessageBoxButton.OK);
                    }
                    else
                    {
                        if (!usedCadastral.CadastralProperties.Insert(registerNumber,property))
                        {
                            usedPropertyList.Properties.Delete(registerNumber);
                            MessageBox.Show("Property register number in this cadastral already in use.", "Alert", MessageBoxButton.OK);
                        }
                        else
                        {
                            MessageBox.Show("Property added.", "Alert", MessageBoxButton.OK);
                            Close();
                        }
                    }

                }
                warning = false;
            }
            else
            {
                MessageBox.Show("Property list id must be a number.", "Alert", MessageBoxButton.OK);
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
