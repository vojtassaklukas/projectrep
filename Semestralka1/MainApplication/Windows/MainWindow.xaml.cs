using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using MainApplication.Classes;
using Structures;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Cadastral currentCadastral;
        public ObservableCollection<Cadastral> Cadastrals { get; set; }

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
            if (cadastral != null)
            {
                cadastral.PropertyLists.Insert(State.Instance.PropertyListNumerator,
                    new PropertyList(cadastral, State.Instance.PropertyListNumerator));
                State.Instance.PropertyListNumerator++;
                MessageBox.Show("Property list added.", "Alert", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Pick cadastral.", "Alert", MessageBoxButton.OK);
            }
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

        private void AssignPermanentResidence_Click(object sender, RoutedEventArgs e)
        {
            var assignPermanentResidenceForm = new AssignPermanentResidence();
            assignPermanentResidenceForm.Show();
        }

        private void AssignResidenceOwnership_Click(object sender, RoutedEventArgs e)
        {
            var assignResidenceOwnershipForm = new AssignResidenceOwnership();
            assignResidenceOwnershipForm.Show();
        }

        private void AssignOwnershipInterest_Click(object sender, RoutedEventArgs e)
        {
            var assignOwnershipInterestForm = new AssignOwnershipInterest();
            assignOwnershipInterestForm.Show();
        }

        private void AssignExistingOwnershipInterest_Click(object sender, RoutedEventArgs e)
        {
            var assignExistingOwnershipInterestForm = new AssignExistingOwnershipInterest();
            assignExistingOwnershipInterestForm.Show();
        }

        private void UnassignExistingOwnership_Click(object sender, RoutedEventArgs e)
        {
            var unassignExistingOwnershipForm = new UnassigntOwnershipInterest();
            unassignExistingOwnershipForm.Show();
        }

        private void FindPropertyById_Click(object sender, RoutedEventArgs e)
        {
            var findPropertyByIdForm = new FindPropertyCadastralIdForm();
            findPropertyByIdForm.Show();
        }

        private void ShowCitizensPermanentResidence_Click(object sender, RoutedEventArgs e)
        {
            var showCitizensPermanentResidenceForm = new ShowCitizensPermanentResidence();
            showCitizensPermanentResidenceForm.Show();
        }

        private void ShowPropertyPErmanentPeople_Click(object sender, RoutedEventArgs e)
        {
            var showPropertyPermanentPeopleForm = new ShowpropertyPermanentPeopleForm();
            showPropertyPermanentPeopleForm.Show();
        }

        private void FindPropertyListById_Click(object sender, RoutedEventArgs e)
        {
            var findPropertyListByIdForm = new FindPropertyListById();
            findPropertyListByIdForm.Show();
        }

        private void FindPropertyByName_Click(object sender, RoutedEventArgs e)
        {
            var findPropertyByNameForm = new FindPropertyByCadastralName();
            findPropertyByNameForm.Show();
        }

        private void FindPropertyListByName_Click(object sender, RoutedEventArgs e)
        {
            var findPropertyListByNameForm = new FindPropertyListByName();
            findPropertyListByNameForm.Show();
        }

        private void ShowProperties_Click(object sender, RoutedEventArgs e)
        {
            var showPropertiesForm = new ShowPropertiesForm();
            showPropertiesForm.Show();
        }

        private void ShowAreasByName_Click(object sender, RoutedEventArgs e)
        {
            var showCadastralAreas = new ShowCadastralAreas();
            showCadastralAreas.Show();
            Cadastrals = new ObservableCollection<Cadastral>();
            foreach (Cadastral c in State.Instance.CadastralAreasByName.GetDataEnumerator())
            {
                Cadastrals.Add(c);
            }

            showCadastralAreas.CadastralProperties.ItemsSource = Cadastrals;
        }

        private void ShowPropertiesInCadastral_Click(object sender, RoutedEventArgs e)
        {
            var showPropertiesInCadastralForm = new FindOwnerPropertiesCadastralForm();
            showPropertiesInCadastralForm.Show();
        }

        private void ShowAllProperties_Click(object sender, RoutedEventArgs e)
        {
            var showAllProperties = new FindOwnerPropertiesForm();
            showAllProperties.Show();
        }

        private void GenerateData_Click(object sender, RoutedEventArgs e)
        {
            var generateDataForm = new GenerateDataForm();
            generateDataForm.Show();
        }

        private void DeletePropertyList_Click(object sender, RoutedEventArgs e)
        {
            var deleteProeprtyListForm = new DeletePropertyListForm();
            deleteProeprtyListForm.Show();
        }

        private void DeleteProperty_Click(object sender, RoutedEventArgs e)
        {
            var deletePropertyForm = new DeletePropertyForm();
            deletePropertyForm.Show();
        }

        private void DeleteCadastralArea_Click(object sender, RoutedEventArgs e)
        {
            var deleteCadastralAreaForm = new DeleteCadastralAreaForm();
            deleteCadastralAreaForm.Show();
        }

        private void SaveDataToFile_Click(object sender, RoutedEventArgs e)
        {
            var cadastrals = new MyArray<string>();
            var citizens = new MyArray<string>();
            var cadastralsByNames = new MyArray<string>();
            var propertiesOfCadastrals = new MyArray<string>();
            var propertyListsOfCadastrals = new MyArray<string>();
            var propertyListsProperties = new MyArray<string>();
            var propertyListsOwners = new MyArray<string>();
            var permanentPeopleOfProperties = new MyArray<string>();
            var increments = new MyArray<string>();
            var citizenAllProperties = new MyArray<string>();
            var citizenCadastralProperties = new MyArray<string>();

            foreach (Citizen c in State.Instance.Citizens.GetLevelEnumerator())
            {
                if (c.PermanentResidance != null)
                {
                    citizens.Add(c.EAN + ";" + c.Name + ";" + c.BirthDate + ";" + c.PermanentResidance.PropertyId + ";" + c.PermanentResidance.PropertyList.Cadastral.CadastralId);
                }
                else
                {
                    citizens.Add(c.EAN + ";" + c.Name + ";" + c.BirthDate);
                }
            }

            foreach (var c in State.Instance.CadastralAreas.GetLevelEnumerator())
            {
                cadastrals.Add(c.CadastralId + ";" + c.CadastralName);
            }

            foreach (var c in State.Instance.CadastralAreasByName.GetLevelEnumerator())
            {
                cadastralsByNames.Add(c.CadastralId + ";" + c.CadastralName);
            }

            foreach (var c in State.Instance.CadastralAreas.GetLevelEnumerator())
            {
                foreach (Property p in c.CadastralProperties.GetLevelEnumerator())
                {
                    propertiesOfCadastrals.Add(p.PropertyId + ";" + p.Adress + ";" + p.Description + ";" + p.PropertyList.PropertyListId + ";" + c.CadastralId);

                    foreach (Citizen cit in p.PermanentPeople.GetLevelEnumerator())
                    {
                        permanentPeopleOfProperties.Add(cit.EAN + ";" + p.PropertyId + ";" + c.CadastralId);
                    }
                }

                foreach (PropertyList pl in c.PropertyLists.GetLevelEnumerator())
                {
                    propertyListsOfCadastrals.Add(pl.PropertyListId + ";" + c.CadastralId);

                    foreach (Property p in pl.Properties.GetLevelEnumerator())
                    {
                        propertyListsProperties.Add(p.PropertyId + ";" + p.Adress + ";" + p.Description + ";" + pl.PropertyListId + ";" + c.CadastralId);
                    }

                    foreach (OwnershipInterest oi in pl.Owners.GetLevelEnumerator())
                    {
                        propertyListsOwners.Add(oi.Citizen.EAN + ";" + oi.Interest + ";" + pl.PropertyListId + ";" + c.CadastralId);
                    }
                }
            }

            foreach (Citizen c in State.Instance.Citizens.GetLevelEnumerator())
            {
                foreach (Property p in c.AllProperties.GetLevelEnumerator())
                {
                    citizenAllProperties.Add(c.EAN + ";" + p.PropertyList.Cadastral.CadastralId + ";" + p.PropertyId);
                }
            }

            increments.Add(State.Instance.CadastralNumerator + ";" + State.Instance.CitizenNumebrator + ";" + State.Instance.PropertyListNumerator + ";" + State.Instance.PropertyNumerator);

            File.WriteAllLines(@"C:\Users\Lukáš\Desktop\udajovky2\Data\Cadastrals.csv", cadastrals);
            File.WriteAllLines(@"C:\Users\Lukáš\Desktop\udajovky2\Data\Citizens.csv", citizens);
            File.WriteAllLines(@"C:\Users\Lukáš\Desktop\udajovky2\Data\CadastralsByNames.csv", cadastralsByNames);
            File.WriteAllLines(@"C:\Users\Lukáš\Desktop\udajovky2\Data\PropertiesOfCadastrals.csv", propertiesOfCadastrals);
            File.WriteAllLines(@"C:\Users\Lukáš\Desktop\udajovky2\Data\PropertyListsOfCadastrals.csv", propertyListsOfCadastrals);
            File.WriteAllLines(@"C:\Users\Lukáš\Desktop\udajovky2\Data\PropertyListsProperties.csv", propertyListsProperties);
            File.WriteAllLines(@"C:\Users\Lukáš\Desktop\udajovky2\Data\PropertyListsOwners.csv", propertyListsOwners);
            File.WriteAllLines(@"C:\Users\Lukáš\Desktop\udajovky2\Data\PermanentPeopleOfProperties.csv", permanentPeopleOfProperties);
            File.WriteAllLines(@"C:\Users\Lukáš\Desktop\udajovky2\Data\CitizenAllProperties.csv", citizenAllProperties);
            File.WriteAllLines(@"C:\Users\Lukáš\Desktop\udajovky2\Data\Increments.csv", increments);

            MessageBox.Show("Save complete", "Alert", MessageBoxButton.OK);
        }

        private void LoadDataFromFile_Click(object sender, RoutedEventArgs e)
        {
            using (var reader = new StreamReader(@"C:\Users\Lukáš\Desktop\udajovky2\Data\Cadastrals.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    Cadastral cadastral = new Cadastral(Int32.Parse(values[0]), values[1]);
                    State.Instance.CadastralAreas.Insert(cadastral.CadastralId, cadastral);
                }
            }

            using (var reader = new StreamReader(@"C:\Users\Lukáš\Desktop\udajovky2\Data\CadastralsByNames.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    Cadastral cadastral = State.Instance.CadastralAreas.Find(Int32.Parse(values[0]));
                    State.Instance.CadastralAreasByName.Insert(values[1], cadastral);
                }
            }

            using (var reader = new StreamReader(@"C:\Users\Lukáš\Desktop\udajovky2\Data\PropertyListsOfCadastrals.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    Cadastral c = State.Instance.CadastralAreas.Find(Int32.Parse(values[1]));

                    PropertyList propertyList = new PropertyList(c, Int32.Parse(values[0]));
                    c.PropertyLists.Insert(Int32.Parse(values[0]), propertyList);
                }
            }

            using (var reader = new StreamReader(@"C:\Users\Lukáš\Desktop\udajovky2\Data\PropertiesOfCadastrals.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    Cadastral c = State.Instance.CadastralAreas.Find(Int32.Parse(values[4]));
                    Property property = new Property(Int32.Parse(values[0]),values[1], values[2]);
                    property.PropertyList = c.PropertyLists.Find(Int32.Parse(values[3]));
                    c.CadastralProperties.Insert(Int32.Parse(values[0]), property);
                }
            }

            using (var reader = new StreamReader(@"C:\Users\Lukáš\Desktop\udajovky2\Data\PropertyListsProperties.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    Cadastral c = State.Instance.CadastralAreas.Find(Int32.Parse(values[4]));

                    PropertyList pl = c.PropertyLists.Find(Int32.Parse(values[3]));

                    Property property = c.CadastralProperties.Find(Int32.Parse(values[0]));

                    pl.Properties.Insert(Int32.Parse(values[0]), property);
                }
            }

            using (var reader = new StreamReader(@"C:\Users\Lukáš\Desktop\udajovky2\Data\Citizens.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    Citizen c = new Citizen(values[1], DateTime.Parse(values[2]), values[0]);
                    if (values.Length > 3)
                    {
                        Cadastral cadastral = State.Instance.CadastralAreas.Find(Int32.Parse(values[4]));

                        Property property = cadastral.CadastralProperties.Find(Int32.Parse(values[3]));

                        c.PermanentResidance = property;
                        State.Instance.Citizens.Insert(values[0], c);
                    }
                    else
                    {
                        State.Instance.Citizens.Insert(values[0], c);
                    }
                }
            }

            using (var reader = new StreamReader(@"C:\Users\Lukáš\Desktop\udajovky2\Data\PropertyListsOwners.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    Citizen citizen = State.Instance.Citizens.Find(values[0]);

                    Cadastral cadastral = State.Instance.CadastralAreas.Find(Int32.Parse(values[3]));

                    PropertyList propertyList = cadastral.PropertyLists.Find(Int32.Parse(values[2]));

                    propertyList.Owners.Insert(values[0], new OwnershipInterest(citizen, Int32.Parse(values[1])));
                }
            }

            using (var reader = new StreamReader(@"C:\Users\Lukáš\Desktop\udajovky2\Data\PermanentPeopleOfProperties.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    Citizen citizen = State.Instance.Citizens.Find(values[0]);

                    Cadastral cadastral = State.Instance.CadastralAreas.Find(Int32.Parse(values[2]));

                    Property property = cadastral.CadastralProperties.Find(Int32.Parse(values[1]));

                    property.PermanentPeople.Insert(values[0], citizen);
                }
            }

            using (var reader = new StreamReader(@"C:\Users\Lukáš\Desktop\udajovky2\Data\Increments.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    State.Instance.CadastralNumerator = Int32.Parse(values[0]);
                    State.Instance.CitizenNumebrator = Int32.Parse(values[1]);
                    State.Instance.PropertyListNumerator = Int32.Parse(values[2]);
                    State.Instance.PropertyNumerator = Int32.Parse(values[3]);
                }
            }

            using (var reader = new StreamReader(@"C:\Users\Lukáš\Desktop\udajovky2\Data\CitizenAllProperties.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    Citizen citizen = State.Instance.Citizens.Find(values[0]);

                    Cadastral cadastral = State.Instance.CadastralAreas.Find(Int32.Parse(values[1]));

                    Property property = cadastral.CadastralProperties.Find(Int32.Parse(values[2]));

                    citizen.AllProperties.Insert(Int32.Parse(values[2]), property);

                    AvlTree<int, Property> foundTree = citizen.PropertiesByCadastral.Find(cadastral.CadastralId); 
                    if (foundTree != null) // ak hej
                    {
                        foundTree.Insert(property.PropertyId, property); 
                    }
                    else // ak nie
                    {
                        citizen.PropertiesByCadastral.Insert(cadastral.CadastralId, new AvlTree<int, Property>()); 
                        citizen.PropertiesByCadastral.Find(cadastral.CadastralId).Insert(property.PropertyId, property);
                    }
                }
            }

            MessageBox.Show("Load complete", "Alert", MessageBoxButton.OK);
        }
    }
}
