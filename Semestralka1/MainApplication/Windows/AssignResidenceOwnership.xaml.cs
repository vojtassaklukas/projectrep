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
                            if (property.AssignResidenceOs(OldOwner.Text, NewOwner.Text, cadastalId, cadastral))
                            {
                                Close();
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
