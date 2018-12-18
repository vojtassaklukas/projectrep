using System;
using System.Collections.ObjectModel;
using System.Windows;
using MainApplication.Classes;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for FindPropertyListByName.xaml
    /// </summary>
    public partial class FindPropertyListByName : Window
    {
        private bool warning = false;
        public FindPropertyListByName()
        {
            InitializeComponent();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FindPropoertyListById_OnClick(object sender, RoutedEventArgs e)
        {
            string cadastralName = CheckTextBox(CadastralName.Text);
            int propertyListId;

                if (!warning)
                {
                    Cadastral cadastral = State.Instance.CadastralAreasByName.Find(cadastralName);
                    if (cadastral != null)
                    {
                        if (Int32.TryParse(CheckTextBox(PropertyListId.Text), out propertyListId))
                        {
                            if (!warning)
                            {
                                PropertyList propertyList = cadastral.PropertyLists.Find(propertyListId);
                                if (propertyList != null)
                                {
                                    propertyList.PropertyListFound += OnPropertyListFound;

                                    propertyList.FindByName();

                                    Close();
                                }
                                else
                                {
                                    MessageBox.Show("Property list with such id doesn't exist.", "Alert", MessageBoxButton.OK);
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

        private void OnPropertyListFound(object source, PropertyListFoundEventArgs e)
        {
            var showPropertyList = new ShowPropertyListById();
            showPropertyList.Show();

            showPropertyList.PropertyListInformation.Items.Add(e.PropertyList);

            showPropertyList.PropertyListProperties.ItemsSource = e.PropertyListProperties;
            showPropertyList.PropertyListOwners.ItemsSource = e.PropertyListOwners;
        }
    }
}
