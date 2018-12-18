using System;
using System.Collections.ObjectModel;
using System.Windows;
using MainApplication.Classes;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for FindPropertyCadastralIdForm.xaml
    /// </summary>
    public partial class FindPropertyCadastralIdForm : Window
    {
        private bool warning = false;

        public FindPropertyCadastralIdForm()
        {
            InitializeComponent();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FindProperty_OnClick(object sender, RoutedEventArgs e)
        {
            int cadastralId;
            int propertyId;

            if (Int32.TryParse(CheckTextBox(CadastralId.Text), out cadastralId))
            {
                if (!warning)
                {
                    Cadastral cadastral = State.Instance.CadastralAreas.Find(cadastralId);
                    if (cadastral != null)
                    {
                        if (Int32.TryParse(CheckTextBox(PropertyId.Text), out propertyId))
                        {
                            Property property = cadastral.CadastralProperties.Find(propertyId);
                            if (property != null)
                            {
                                property.PropertyFound += OnPropertyFound;

                                property.FindById();

                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Property with such id doesn't exist.", "Alert", MessageBoxButton.OK);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Property id must be a number.", "Alert", MessageBoxButton.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cadastral area with such id doesn't exist.", "Alert", MessageBoxButton.OK);
                    }
                }
                warning = false;
            }
            else
            {
                MessageBox.Show("Cadastral area id must be a number.", "Alert", MessageBoxButton.OK);
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
