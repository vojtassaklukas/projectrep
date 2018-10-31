using System.Windows;
using MainApplication.Classes;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Cadastral currentCadastral;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddCadastralArea(object sender, RoutedEventArgs e)
        {
            var newCadastralAreaForm = new AddCadastralForm();
            newCadastralAreaForm.Show();
        }

        private void ViewAllCadastrals(object sender, RoutedEventArgs e)
        {
            StackPanelCadastralsForProperties.Visibility = Visibility.Hidden;
            StackPanelPropertyLists.Visibility = Visibility.Hidden;
            StackPanelCadastrals.Visibility = Visibility.Visible;
            DataGridCadastrals.Items.Clear();
            foreach (Cadastral c in State.Instance.CadastralAreas.GetDataEnumerator())
            {
                DataGridCadastrals.Items.Add(c);
            }
        }

        private void AddPropertyListToCadastral(object sender, RoutedEventArgs e)
        {
            Cadastral cadastral = ((FrameworkElement)sender).DataContext as Cadastral;
            var newPropertyListForm = new AddPropertyListForm(cadastral);
            newPropertyListForm.Show();
            // to do vyskoci okno kde zadam id listu vlastnictva v katastri
        }

        private void HideCadastralList(object sender, RoutedEventArgs e)
        {
            StackPanelCadastrals.Visibility = Visibility.Hidden;
        }

        private void AddPropertyToCadastralAndList(object sender, RoutedEventArgs e)
        {
            StackPanelPropertyLists.Visibility = Visibility.Hidden;
            StackPanelCadastrals.Visibility = Visibility.Hidden;
            StackPanelCadastralsForProperties.Visibility = Visibility.Visible;
            DataGridCadastralsForProperties.Items.Clear();
            foreach (Cadastral c in State.Instance.CadastralAreas.GetDataEnumerator())
            {
                DataGridCadastralsForProperties.Items.Add(c);
            }
        }

        private void HideCadastralListForProperty(object sender, RoutedEventArgs e)
        {
            StackPanelCadastralsForProperties.Visibility = Visibility.Hidden;
            StackPanelPropertyLists.Visibility = Visibility.Hidden;
        }

        private void ViewPropertyListsInCadastral(object sender, RoutedEventArgs e)
        {
            Cadastral cadastral = ((FrameworkElement)sender).DataContext as Cadastral;
            currentCadastral = cadastral;
            StackPanelPropertyLists.Visibility = Visibility.Visible;
            StackPanelCadastrals.Visibility = Visibility.Hidden;
            DataGridPropertyLists.Items.Clear();
            if (cadastral != null)
            {
                foreach (PropertyList pl in cadastral.PropertyLists.GetDataEnumerator())
                {
                    DataGridPropertyLists.Items.Add(pl);
                }
            }
        }

        private void HidePropertyList(object sender, RoutedEventArgs e)
        {
            StackPanelPropertyLists.Visibility = Visibility.Hidden;
        }

        private void AddProperty(object sender, RoutedEventArgs e)
        {
            PropertyList propertyList = ((FrameworkElement)sender).DataContext as PropertyList;
            var newPropertyForm = new AddPropertyForm(currentCadastral, propertyList);
            newPropertyForm.Show();
        }

        private void AddCitizen(object sender, RoutedEventArgs e)
        {
            var newCitizenForm = new AddCitizenForm();
            newCitizenForm.Show();
        }
    }
}
