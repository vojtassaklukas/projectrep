using System.Windows;
using MainApplication.Classes;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for AddCitizenForm.xaml
    /// </summary>
    public partial class AddCitizenForm : Window
    {
        private bool warning = false;
        public AddCitizenForm()
        {
            InitializeComponent();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddCitizen_OnClick(object sender, RoutedEventArgs e)
        {
            if (BirthDate.SelectedDate != null)
            {
                var Citizen = new Citizen(CheckTextBox(Name.Text),
                    BirthDate.SelectedDate.Value,
                    CheckTextBox(Ean.Text));

                if (warning != true)
                {
                    if (State.Instance.Citizens.Insert(Ean.Text, Citizen))
                    {
                        MessageBox.Show("Citizen added", "Alert", MessageBoxButton.OK);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Citizen with this EAN is already registered", "Alert", MessageBoxButton.OK);
                    }
                }
            }
            else
            {
                MessageBox.Show("Choose birth date", "Warning", MessageBoxButton.OK);
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
