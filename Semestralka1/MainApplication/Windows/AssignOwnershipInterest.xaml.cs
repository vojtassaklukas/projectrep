using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using MainApplication.Classes;
using Structures;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for AssignOwnershipInterest.xaml
    /// </summary>
    public partial class AssignOwnershipInterest : Window
    {
        private bool warning;
        public ObservableCollection<OwnershipInterest> Owners { get; set; }
        public AssignOwnershipInterest()
        {
            InitializeComponent();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AssignInterest_OnClick(object sender, RoutedEventArgs e)
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
                            Citizen citizen = State.Instance.Citizens.Find(CheckTextBox(Ean.Text));
                            if (!warning)
                            {   
                                if (citizen != null)
                                {
                                    if (!propertyList.Properties.IsEmpty())
                                    {
                                        propertyList.OwnersFound += OnOwnersFound;

                                        propertyList.AssignOi(citizen, cadastral);
                                        MessageBox.Show("Property list owner added", "Warning", MessageBoxButton.OK);
                                        Close();                                
                                    }
                                    else
                                    {
                                        MessageBox.Show("Can't assign new ownership, because there are no properties yet", "Warning", MessageBoxButton.OK);
                                    }     
                                }
                                else
                                {
                                    MessageBox.Show("Citizen with such EAN doesn't exist", "Warning", MessageBoxButton.OK);
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

        private void OnOwnersFound(object source, OwnersFoundEventArgs e)
        {
            var citizenOwnershipsInterestsForm = new CitizenOwnershipsInterests();
            citizenOwnershipsInterestsForm.Show();

            citizenOwnershipsInterestsForm.DataGridOwners.ItemsSource = e.OwnersCollection;
        }
    }
}
