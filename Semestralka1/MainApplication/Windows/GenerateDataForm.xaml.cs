using System;
using System.Linq;
using System.Windows;
using MainApplication.Classes;
using Structures;

namespace MainApplication.Windows
{
    /// <summary>
    /// Interaction logic for GenerateDataForm.xaml
    /// </summary>
    public partial class GenerateDataForm : Window
    {
        private bool warning = false;
        public GenerateDataForm()
        {
            InitializeComponent();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Generate_OnClick(object sender, RoutedEventArgs e)
        {
            int cadastralCount = 0;
            int citizenCount = 0;
            int propertyListCount = 0;
            int propertiesCount = 0;

            int generatedCitizens = 0;

            Int32.TryParse(CadastralCount.Text, out cadastralCount);
            Int32.TryParse(CitizenCount.Text, out citizenCount);
            Int32.TryParse(PropertyListCount.Text, out propertyListCount);
            Int32.TryParse(PRopertiesCount.Text, out propertiesCount);

            Random random = new Random();
            Random randomPermanent = new Random();
            Random randomChance = new Random();
            TimeSpan birthInterval = DateTime.Now - DateTime.Now.AddYears(-100);
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string smallAlphabet = "abcdefghijklmnopqrstuvwxyz";
            string[] adresses = new string[] { "Poriecie", "Nizny Koniec", "Podkamenne", "Trchovnica", "Oravice", "Horna mrzacka", "Dolna mrzacka",
                "Vysny koniec", "Ustredie", "Spital", "Dolinka", "Vrchova", "Slnecna", "Vcelarska" };
            string[] names = new string[]
            {
                "Lukas", "Andrej", "Anton", "Peter", "Rastislav", "Zoltan", "Juraj", "Radoslav", "Jakub", "Andrej", "Michal", "Marek",
                "Zaneta", "Zuzana", "Gabriela", "Sylvia", "Michaela", "Vladimira", "Petra", "Darina", "Natalia", "Nikola", "Mia", "Patricia",
            };
            string[] surnames = new string[]
            {
                "Vojtassak", "Florek", "Iglar", "Zavodancik", "Kiska", "Danko", "Fico", "Jurovcik", "Stevuliak", "Kocur",
                "Novak", "Liska", "Lassak", "Prokop", "Mastny", "Vysoky", "Nizky", "Priemerny", "Hruby", "Tenky", "Siroky",
            }; 
            if (warning != true)
            {
                for (int i = 0; i < cadastralCount; i++)
                {
                    var name = new string(Enumerable.Repeat(alphabet, 5)
                        .Select(s => s[random.Next(s.Length)]).ToArray());
                    Cadastral cadastral = new Cadastral(State.Instance.CadastralNumerator, name);
                    State.Instance.CadastralAreas.Insert(State.Instance.CadastralNumerator, cadastral);
                    State.Instance.CadastralAreasByName.Insert(name, cadastral);
                    State.Instance.CadastralNumerator++;
                }

                int propertyListsInCadastral = propertyListCount / cadastralCount;
                foreach (Cadastral c in State.Instance.CadastralAreas.GetDataEnumerator())
                {
                    for (int i = 0; i < propertyListsInCadastral; i++)
                    {
                        c.PropertyLists.Insert(State.Instance.PropertyListNumerator,
                            new PropertyList(c, State.Instance.PropertyListNumerator));
                        State.Instance.PropertyListNumerator++;
                    }
                }

                foreach (Cadastral c in State.Instance.CadastralAreas.GetDataEnumerator())
                {                  
                    foreach (PropertyList pl in c.PropertyLists.GetDataEnumerator())
                    {
                        for (int i = 0; i < propertiesCount/cadastralCount/propertyListsInCadastral; i++)
                        {
                            int randomAdress = random.Next(0, 14);
                            var description = new string(Enumerable.Repeat(smallAlphabet, 10)
                                .Select(s => s[random.Next(s.Length)]).ToArray());
                            Property property = new Property(State.Instance.PropertyNumerator, adresses[randomAdress], description);
                            property.PropertyList = pl;
                            pl.Properties.Insert(State.Instance.PropertyNumerator, property);
                            c.CadastralProperties.Insert(State.Instance.PropertyNumerator, property);
                            State.Instance.PropertyNumerator++;
                        }
                    }
                }

                foreach (Cadastral c in State.Instance.CadastralAreas.GetDataEnumerator())
                {
                    foreach (PropertyList pl in c.PropertyLists.GetDataEnumerator())
                    {
                        int ownersCount = 0;
                        for (int i = 0; i < citizenCount / propertyListCount; i++) // podielom sa nad kazdym propertylistom rozhodujem ci bude bezdomovec alebo osadnik
                        {
                            int randomName = random.Next(0, 24);
                            int randomSurname = random.Next(0, 21);
                            var ean = random.Next(100000, 999999) + "/" + random.Next(1000, 9999);
                            string name = names[randomName];
                            string surname = surnames[randomSurname];

                            TimeSpan date = new TimeSpan(0, random.Next(0, (int)birthInterval.TotalMinutes), 0);
                            DateTime birthDate = DateTime.Now.AddYears(-100) + date;

                            Citizen citizen = new Citizen(name + " " + surname, birthDate, ean);
                            State.Instance.Citizens.Insert(ean, citizen);

                            if (ownersCount != 4) // prvy styria vkladany do LV budu jeho majitelia
                            {
                                pl.Owners.Insert(ean, new OwnershipInterest(citizen, 250));
                                ownersCount++;

                                foreach (Property p in pl.Properties.GetDataEnumerator()) 
                                {
                                    citizen.AllProperties.Insert(p.PropertyId, p); 

                                    AvlTree<int, Property> foundTree = citizen.PropertiesByCadastral.Find(c.CadastralId); 
                                    if (foundTree != null) // ak hej
                                    {
                                        foundTree.Insert(p.PropertyId, p); 
                                    }
                                    else // ak nie
                                    {
                                        citizen.PropertiesByCadastral.Insert(c.CadastralId, new AvlTree<int, Property>()); 
                                        citizen.PropertiesByCadastral.Find(c.CadastralId).Insert(p.PropertyId, p); 
                                    }
                                }
                            }

                            foreach (Property p in pl.Properties.GetDataEnumerator())
                            {
                                double chanceOfPermanentProperty = randomChance.NextDouble();
                                if (chanceOfPermanentProperty < 0.20)
                                {
                                    p.PermanentPeople.Insert(ean, citizen);
                                    citizen.PermanentResidance = p;
                                    break;
                                }
                            }
                        }
                    }
                }

            }
            MessageBox.Show("Data generated", "Alert", MessageBoxButton.OK);
            Close();
        }
    }
}
