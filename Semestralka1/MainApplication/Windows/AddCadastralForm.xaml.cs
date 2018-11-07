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
            foreach (Cadastral c in State.Instance.CadastralAreas.GetDataEnumerator())
            {
                if (c.CadastralName == CheckTextBox(CadastralName.Text))
                {
                    warning = true;
                    MessageBox.Show("Cadastral area name already in use.", "Alert", MessageBoxButton.OK);
                }
            }

            var cadastral = new Cadastral(State.Instance.CadastralNumerator, CheckTextBox(CadastralName.Text));
            if (warning != true)
            {
                State.Instance.CadastralAreas.Insert(State.Instance.CadastralNumerator, cadastral);
                State.Instance.CadastralAreasByName.Insert(CadastralName.Text, cadastral); // inertion by name
                State.Instance.CadastralNumerator++;
                MessageBox.Show("Cadastral area added.", "Alert", MessageBoxButton.OK);
                Close();
            }
            warning = false;
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
