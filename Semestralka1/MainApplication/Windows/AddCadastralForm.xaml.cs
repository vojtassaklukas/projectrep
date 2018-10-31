using System;
using System.Collections.Generic;
using System.Windows;
using MainApplication.Classes;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for AddCadastralForm.xaml
    /// </summary>
    public partial class AddCadastralForm : Window
    {
        private bool warning = false;

        public AddCadastralForm()
        {
            InitializeComponent();
        }

        private void AddcadastralArea_OnClick(object sender, RoutedEventArgs e)
        {
            int id;

            if (Int32.TryParse(CheckTextBox(CadastralId.Text), out id))
            {
                foreach (Cadastral c in State.Instance.CadastralAreas.GetDataEnumerator())
                {
                    if (c.CadastralName == CheckTextBox(CadastralName.Text))
                    {
                        warning = true;
                        MessageBox.Show("Cadastral area name already in use.", "Alert", MessageBoxButton.OK);
                    }
                }

                var cadastral = new Cadastral(id, CheckTextBox(CadastralName.Text));
                if (warning != true)
                {
                    if (State.Instance.CadastralAreas.Insert(id, cadastral))
                    {
                        MessageBox.Show("Cadastral area added.", "Alert", MessageBoxButton.OK);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Cadastral area id already in use.", "Alert", MessageBoxButton.OK);
                    }
                }
                warning = false;
            }
            else
            {
                MessageBox.Show("Cadastral area id must be a number.", "Alert", MessageBoxButton.OK);
            }
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
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
