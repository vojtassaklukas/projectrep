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
    /// Interaction logic for FindPropertyByCadastralName.xaml
    /// </summary>
    public partial class FindPropertyByCadastralName : Window
    {
        private bool warning = false;

        public FindPropertyByCadastralName()
        {
            InitializeComponent();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FindProperty_OnClick(object sender, RoutedEventArgs e)
        {
            string cadastralName = CheckTextBox(CadastralName.Text);
            int propertyId;

            if (!warning)
                {
                    Cadastral cadastral = State.Instance.CadastralAreasByName.Find(cadastralName);
                    if (cadastral != null)
                    {
                        if (Int32.TryParse(CheckTextBox(PropertyId.Text), out propertyId))
                        {
                            if (!warning)
                            {
                            Property property = cadastral.CadastralProperties.Find(propertyId);
                            if (property != null)
                            {
                                property.PropertyFound += OnPropertyFound;

                                property.FindByName();

                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Property with such id doesn't exist.", "Alert", MessageBoxButton.OK);
                            }
                        }                          
                        }
                        else
                        {
                            MessageBox.Show("Property id must be a number.", "Alert", MessageBoxButton.OK);
                        }
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

        private void OnPropertyFound(object source, PropertyFoundEventArgs e)
        {
            var showPropertyfound = new ShowPropertyById();
            showPropertyfound.Show();


            showPropertyfound.PropertyListInformation.Items.Add(e.PropertyList);
            showPropertyfound.PropertyInformation.Items.Add(e.Property);

            showPropertyfound.PermanentsInformation.ItemsSource = e.PermanentPeople;
            showPropertyfound.PropertyListProperties.ItemsSource = e.PropertyListProperties;
            showPropertyfound.PropertyListOwners.ItemsSource = e.PropertyListOwners;
        }
    }
}
