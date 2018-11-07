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
using Structures;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for FindOwnerPropertiesCadastralForm.xaml
    /// </summary>
    public partial class FindOwnerPropertiesCadastralForm : Window
    {
        private bool warning = false;
        public ObservableCollection<Property> Properties { get; set; }
        public ObservableCollection<int> Interests { get; set; }

        public FindOwnerPropertiesCadastralForm()
        {
            InitializeComponent();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddcadastralArea_OnClick(object sender, RoutedEventArgs e)
        {
            int cadastralId;
            string ean = CheckTextBox(CitizenEan.Text);

            if (!warning)
            {
                if (Int32.TryParse(CheckTextBox(CadastralId.Text), out cadastralId))
                {
                    Cadastral cadastral = State.Instance.CadastralAreas.Find(cadastralId);
                    if (cadastral != null)
                    {
                        Citizen citizen = State.Instance.Citizens.Find(ean);
                        Properties = new ObservableCollection<Property>();
                        Interests = new ObservableCollection<int>();
                        if (citizen != null)
                        {
                            AvlTree<int, Property> foundcadastral = citizen.PropertiesByCadastral.Find(cadastral.CadastralId);
                            if (foundcadastral != null) // ak hej
                            {
                                var showProperties = new ShowOwnerPropertiesCadastral();
                                showProperties.Show();
                                showProperties.CitizenProperties.ItemsSource = Properties;
                                showProperties.PropertyInterests.ItemsSource = Interests;

                                foreach (Property p in foundcadastral.GetDataEnumerator())
                                {
                                    Properties.Add(p);
                                    int interest = p.PropertyList.Owners.Find(citizen.EAN).Interest;
                                    Interests.Add(interest);
                                }
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Citizen has no properties.", "Alert", MessageBoxButton.OK);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Citizen with such ean doesnt exist.", "Alert", MessageBoxButton.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cadastral with such id doesnt exist.", "Alert", MessageBoxButton.OK);
                    }                
                }
                else
                {
                    MessageBox.Show("Cadastral area id must be a number.", "Alert", MessageBoxButton.OK);
                }
            }
            warning = false;
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
