using System;
using System.Collections.ObjectModel;
using System.Windows;
using MainApplication.Classes;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for ShowpropertyPermanentPeopleForm.xaml
    /// </summary>
    public partial class ShowpropertyPermanentPeopleForm : Window
    {
        private bool warning = false;

        public ShowpropertyPermanentPeopleForm()
        {
            InitializeComponent();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ShowAllPermanentPeople_OnClick(object sender, RoutedEventArgs e)
        {
            int propertyId;
            int cadastralId;
            int propertyListId;

            if (Int32.TryParse(CheckTextBox(CadastralId.Text), out cadastralId))
            {
                if (!warning)
                {
                    Cadastral cadastral = State.Instance.CadastralAreas.Find(cadastralId);
                    if (cadastral != null)
                    {
                        if (Int32.TryParse(CheckTextBox(PropertyListId.Text), out propertyListId))
                        {
                            PropertyList propertyList = cadastral.PropertyLists.Find(propertyListId);
                            if (propertyList != null)
                            {
                                if (Int32.TryParse(CheckTextBox(PropertyId.Text), out propertyId))
                                {
                                    Property property = propertyList.Properties.Find(propertyId);
                                    if (property != null)
                                    {
                                        property.PermanentPeopleFound += OnPermanentPeopleFound;

                                        property.FindPermanentPeople();

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
                                MessageBox.Show("Property list with such id doesn't exist.", "Alert", MessageBoxButton.OK);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Property list id must be a number.", "Alert", MessageBoxButton.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cadastral area with such id doesn't exist.", "Alert", MessageBoxButton.OK);
                    }
                    warning = false;
                }
                else
                {
                    MessageBox.Show("Cadastral area id must be a number.", "Alert", MessageBoxButton.OK);
                }
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

        private void OnPermanentPeopleFound(object source, PermanentPeopleFoundEventArgs e)
        {
            var showPermanentStays = new ShowPropertyPermanentPeople();
            showPermanentStays.Show();

            showPermanentStays.PermanentsInformation.ItemsSource = e.PermanentPeople;
        }
    }
}
