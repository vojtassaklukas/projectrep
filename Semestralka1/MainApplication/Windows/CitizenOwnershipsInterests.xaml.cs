using System.Collections.ObjectModel;
using System.Windows;
using MainApplication.Classes;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for CitizenOwnershipsInterests.xaml
    /// </summary>
    public partial class CitizenOwnershipsInterests : Window
    {
        public CitizenOwnershipsInterests()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            int total = 0;           
            foreach (OwnershipInterest o in DataGridOwners.Items)
            {
                total += o.Interest;
            }

            if (total == 1000)
            {
                MessageBox.Show("Ownership interests changed", "Warning", MessageBoxButton.OK);
                Close();
            }
            else
            {
                MessageBox.Show("Ownership interests must equal 100% together", "Warning", MessageBoxButton.OK);
            }
        }
    }
}
