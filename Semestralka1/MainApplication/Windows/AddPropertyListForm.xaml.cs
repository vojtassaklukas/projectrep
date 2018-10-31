using System;
using System.Windows;
using MainApplication.Classes;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for AddPropertyListForm.xaml
    /// </summary>
    public partial class AddPropertyListForm : Window
    {
        private readonly Cadastral usedCadastral;
        private bool warning = false;

        public AddPropertyListForm(Cadastral cadastral)
        {
            InitializeComponent();
            usedCadastral = cadastral;
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddpropertyList_OnClick(object sender, RoutedEventArgs e)
        {
            int id;

            if (Int32.TryParse(CheckTextBox(PropertyListlId.Text), out id))
            {
                if (warning != true)
                {
                    if (usedCadastral.PropertyLists.Insert(id, new PropertyList(usedCadastral,id)))
                    {
                        MessageBox.Show("Property list added.", "Alert", MessageBoxButton.OK);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Property list id already in use.", "Alert", MessageBoxButton.OK);
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
