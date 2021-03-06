﻿using System.Collections.ObjectModel;
using System.Windows;
using MainApplication.Classes;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for FindOwnerPropertiesForm.xaml
    /// </summary>
    public partial class FindOwnerPropertiesForm : Window
    {
        private bool warning = false;
        public ObservableCollection<Property> Properties { get; set; }
        public ObservableCollection<int> Interests { get; set; }

        public FindOwnerPropertiesForm()
        {
            InitializeComponent();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddcadastralArea_OnClick(object sender, RoutedEventArgs e)
        {
            string ean = CheckTextBox(CitizenEan.Text);

            if (!warning)
            {          
                Citizen citizen = State.Instance.Citizens.Find(ean);
                Properties = new ObservableCollection<Property>();
                Interests = new ObservableCollection<int>();
                if (citizen != null)
                {
                    citizen.PropertiesFound += OnPropertiesFound;

                    citizen.FindCitizenProperties();

                    Close();
                }
                else
                {
                    MessageBox.Show("Citizen with such ean doesnt exist.", "Alert", MessageBoxButton.OK);
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

        private void OnPropertiesFound(object source, PropertiesFoundEventArgs e)
        {
            var showProperties = new ShowOwnerPropertiesCadastral();
            showProperties.Show();
            showProperties.CitizenProperties.ItemsSource = e.Properties;
            showProperties.PropertyInterests.ItemsSource = e.Interests;
        }
    }
}
