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
    /// Interaction logic for ShowPropertiesForm.xaml
    /// </summary>
    public partial class ShowPropertiesForm : Window
    {
        private bool warning = false;
        public ShowPropertiesForm()
        {
            InitializeComponent();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ShowProperties_OnClick(object sender, RoutedEventArgs e)
        {
            string cadastralName = CheckTextBox(CadastralName.Text);

            if (!warning)
            {
                Cadastral cadastral = State.Instance.CadastralAreasByName.Find(cadastralName);
                if (cadastral != null)
                {
                    cadastral.CadastralPropertiesFound += OnPropertiesFound;

                    cadastral.ShowProperties();

                    Close();
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

        private void OnPropertiesFound(object source, CadastralPropertiesFoundEventArgs e)
        {
            var showProperties = new ShowProperties();
            showProperties.Show();
            showProperties.CadastralProperties.ItemsSource = e.Properties;
        }
    }
}
