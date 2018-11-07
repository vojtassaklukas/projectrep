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
                                        OwnershipInterest ownership = new OwnershipInterest(citizen, 0);
                                        Owners = new ObservableCollection<OwnershipInterest>();
                                        if (!propertyList.Owners.Insert(citizen.EAN, ownership))
                                        {
                                            MessageBox.Show("Citizen is already an owner", "Warning", MessageBoxButton.OK);
                                        }
                                        else
                                        {
                                            var citizenOwnershipsInterestsForm = new CitizenOwnershipsInterests();
                                            citizenOwnershipsInterestsForm.Show();
                                            foreach (OwnershipInterest o in propertyList.Owners.GetDataEnumerator())
                                            {
                                                Owners.Add(o);
                                            }

                                            citizenOwnershipsInterestsForm.DataGridOwners.ItemsSource = Owners;

                                            foreach (Property p in propertyList.Properties.GetDataEnumerator()) // prechadzam cez vsetky property na LV
                                            {
                                                citizen.AllProperties.Insert(p.PropertyId, p); // najprv hodim no vsetkych properties

                                                AvlTree<int, Property> foundTree = citizen.PropertiesByCadastral.Find(cadastral.CadastralId); // zistim ci mam uz strom na property s takym catastrom
                                                if (foundTree != null) // ak hej
                                                {
                                                    foundTree.Insert(p.PropertyId, p); // pridam tam tu property
                                                }
                                                else // ak nie
                                                {
                                                    citizen.PropertiesByCadastral.Insert(cadastral.CadastralId, new AvlTree<int, Property>()); // tak najprv spravim novy strom
                                                    citizen.PropertiesByCadastral.Find(cadastral.CadastralId).Insert(p.PropertyId, p); // potom ho najdem a vlozim do neho
                                                }
                                            }

                                            MessageBox.Show("Property list owner added", "Warning", MessageBoxButton.OK);
                                            Close();
                                        }
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
    }
}
