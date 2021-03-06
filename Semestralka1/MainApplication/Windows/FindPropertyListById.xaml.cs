﻿using System;
using System.Collections.ObjectModel;
using System.Windows;
using MainApplication.Classes;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for FindPropertyListById.xaml
    /// </summary>
    public partial class FindPropertyListById : Window
    {
        private bool warning = false;
        public FindPropertyListById()
        {
            InitializeComponent();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FindPropoertyListById_OnClick(object sender, RoutedEventArgs e)
        {
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
                                propertyList.PropertyListFound += OnPropertyListFound;

                                propertyList.FindById();

                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Property list with such id doesn't exist.", "Alert", MessageBoxButton.OK);
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
