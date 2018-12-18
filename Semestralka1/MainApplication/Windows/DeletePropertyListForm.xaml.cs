using System;
using System.Windows;
using MainApplication.Classes;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for DeletePropertyListForm.xaml
    /// </summary>
    public partial class DeletePropertyListForm : Window
    {
        private bool warning = false;

        public DeletePropertyListForm()
        {
            InitializeComponent();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DeletePl_OnClick(object sender, RoutedEventArgs e)
        {
            int cadastralId;
            int deletedPropertyListId;
            int insertedPropertyListID;

            if (Int32.TryParse(CheckTextBox(CadastralId.Text), out cadastralId))
            {
                if (Int32.TryParse(CheckTextBox(DeletedId.Text), out deletedPropertyListId))
                {
                    if (Int32.TryParse(CheckTextBox(InsertedId.Text), out insertedPropertyListID))
                    {
                        Cadastral cadastral = State.Instance.CadastralAreas.Find(cadastralId);
                        if (!warning)
                        {
                            if (cadastral != null)
                            {
                                PropertyList inserted = cadastral.PropertyLists.Find(insertedPropertyListID);

                                if (inserted != null)
                                {
                                    if (inserted.Properties.IsEmpty())
                                    {
                                        PropertyList deleted = cadastral.PropertyLists.Find(deletedPropertyListId);

                                        if (deleted != null)
                                        {
                                            deleted.DeletePropertyList(inserted);
                                            MessageBox.Show("Property list removed and moved to another", "Warning", MessageBoxButton.OK);
                                            Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Deleted property list doesn't exist", "Warning", MessageBoxButton.OK);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("New property list must be empty", "Warning", MessageBoxButton.OK);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Inserted property list doens't exist", "Warning", MessageBoxButton.OK);
                                }

                            }
                            else
                            {
                                MessageBox.Show("Cadastral with such id doesn't exist", "Warning", MessageBoxButton.OK);
                            }
                        }
                        warning = false;
                    }
                    else
                    {
                        MessageBox.Show("Inserted property list id must be a number.", "Warning", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Deleted property list id must be a number.", "Warning", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Cadastral id must be a number.", "Warning", MessageBoxButton.OK);
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
