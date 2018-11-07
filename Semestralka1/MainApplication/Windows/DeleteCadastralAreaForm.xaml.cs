using System;
using System.Windows;
using MainApplication.Classes;
using Structures;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for DeleteCadastralAreaForm.xaml
    /// </summary>
    public partial class DeleteCadastralAreaForm : Window
    {
        private bool warning = false;
        public DeleteCadastralAreaForm()
        {
            InitializeComponent();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DeleteCadastralArea_OnClick(object sender, RoutedEventArgs e)
        {
            int deletedCadastralId;
            int InsertedCadastralId;

            if (Int32.TryParse(CheckTextBox(DeletedId.Text), out deletedCadastralId))
            {
                if (Int32.TryParse(CheckTextBox(InsertedId.Text), out InsertedCadastralId))
                {
                    if (!warning)
                    {
                        Cadastral deleted = State.Instance.CadastralAreas.Find(deletedCadastralId);
                        if (deleted != null)
                        {
                            Cadastral inserted = State.Instance.CadastralAreas.Find(InsertedCadastralId);
                            if (inserted != null)
                            {
                                foreach (Citizen citizen in State.Instance.Citizens.GetDataEnumerator())
                                {
                                    AvlTree<int, Property> foundTreeDeleted = citizen.PropertiesByCadastral.Find(deletedCadastralId);
                                    if (foundTreeDeleted != null)
                                    {
                                        AvlTree<int, Property> foundTreeInserted = citizen.PropertiesByCadastral.Find(InsertedCadastralId);

                                        if (foundTreeInserted == null)
                                        {
                                            citizen.PropertiesByCadastral.Insert(InsertedCadastralId,new AvlTree<int, Property>());
                                        }

                                        foundTreeInserted = citizen.PropertiesByCadastral.Find(InsertedCadastralId);

                                        foreach (Property property in foundTreeDeleted.GetDataEnumerator())
                                        {
                                            foundTreeInserted.Insert(property.PropertyId, property);
                                        }

                                        foreach (Property property in foundTreeDeleted.GetDataEnumerator())
                                        {
                                            foundTreeDeleted.Delete(property.PropertyId);
                                        }
                                    }
                                }

                                foreach (PropertyList pl in deleted.PropertyLists.GetDataEnumerator())
                                {
                                    pl.Cadastral = inserted;
                                    inserted.PropertyLists.Insert(pl.PropertyListId, pl);
                                }

                                foreach (Property p in deleted.CadastralProperties.GetDataEnumerator())
                                {
                                    inserted.CadastralProperties.Insert(p.PropertyId, p);
                                }

                                State.Instance.CadastralAreas.Delete(deleted.CadastralId);
                                State.Instance.CadastralAreasByName.Delete(deleted.CadastralName);

                                MessageBox.Show("Cadastral area removed.", "Warning", MessageBoxButton.OK);
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Cadaster to be inserted to id is wrong", "Warning", MessageBoxButton.OK);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cadaster to be deleted id is wrong", "Warning", MessageBoxButton.OK);
                        }
                    }
                    warning = false;
                }
                else
                {
                    MessageBox.Show("Inserted cadastral id must be a number", "Warning", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Deleted cadastral id must be a number", "Warning", MessageBoxButton.OK);
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
    }
}
