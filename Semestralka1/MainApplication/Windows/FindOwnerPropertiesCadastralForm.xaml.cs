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
using Structures;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for FindOwnerPropertiesCadastralForm.xaml
    /// </summary>
    public partial class FindOwnerPropertiesCadastralForm : Window
    {
        private bool warning = false;

        public FindOwnerPropertiesCadastralForm()
        {
            InitializeComponent();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddcadastralArea_OnClick(object sender, RoutedEventArgs e)
        {
            int cadastralId;
            string ean = CheckTextBox(CitizenEan.Text);

            if (!warning)
            {
                if (Int32.TryParse(CheckTextBox(CadastralId.Text), out cadastralId))
                {
                    Cadastral cadastral = State.Instance.CadastralAreas.Find(cadastralId);
                    if (cadastral != null)
                    {
                        Citizen citizen = State.Instance.Citizens.Find(ean);
                        if (citizen != null)
                        {
                            citizen.PropertiesFound += OnPropertiesFound;

                            citizen.FindCitizenPropertiesCadastral(cadastral);

                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Citizen with such ean doesnt exist.", "Alert", MessageBoxButton.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cadastral with such id doesnt exist.", "Alert", MessageBoxButton.OK);
                    }                
                }
                else
                {
                    MessageBox.Show("Cadastral area id must be a number.", "Alert", MessageBoxButton.OK);
                }
            }
            warning = false;
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

        private void OnPropertiesFound(object source, PropertiesFoundEventArgs e)
        {
            var showProperties = new ShowOwnerPropertiesCadastral();
            showProperties.Show();
            showProperties.CitizenProperties.ItemsSource = e.Properties;
            showProperties.PropertyInterests.ItemsSource = e.Interests;
        }
    }
}
