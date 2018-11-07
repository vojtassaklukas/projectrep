﻿using System;
using System.Collections.ObjectModel;
using System.Windows;
using MainApplication.Classes;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for AssignExistingOwnershipInterest.xaml
    /// </summary>
    public partial class AssignExistingOwnershipInterest : Window
    {
        private bool warning;
        public ObservableCollection<OwnershipInterest> Owners { get; set; }

        public AssignExistingOwnershipInterest()
        {
            InitializeComponent();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AssignExistingInterest_OnClick(object sender, RoutedEventArgs e)
        {
            int cadastalId;
            int propertyListId;
            warning = false;

            if (Int32.TryParse(CheckTextBox(CadastralId.Text), out cadastalId))
            {
                Cadastral cadastral = State.Instance.CadastralAreas.Find(cadastalId);
                if (cadastral != null)
                {
                    if (Int32.TryParse(CheckTextBox(PropertyListId.Text), out propertyListId))
                    {
                        PropertyList propertyList = cadastral.PropertyLists.Find(propertyListId);
                        if (propertyList != null)
                        {
                            if (!warning)
                            {
                                Owners = new ObservableCollection<OwnershipInterest>();
                                foreach (OwnershipInterest o in propertyList.Owners.GetDataEnumerator())
                                {
                                    Owners.Add(o);
                                }
                                if (Owners.Count != 0)
                                {
                                    var citizenOwnershipsInterestsForm = new CitizenOwnershipsInterests();
                                    citizenOwnershipsInterestsForm.Show();

                                    citizenOwnershipsInterestsForm.DataGridOwners.ItemsSource = Owners;

                                    Close();
                                }
                                else
                                {
                                    MessageBox.Show("No ownership data found", "Warning", MessageBoxButton.OK);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Property list with such Id doesn't exist", "Warning", MessageBoxButton.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Property list Id must be a number", "Warning", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Cadastral with such Id doesn't exist", "Warning", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Cadastral Id must be a number", "Warning", MessageBoxButton.OK);
            }
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
    }
}
