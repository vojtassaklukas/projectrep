using System;
using System.Collections.ObjectModel;
using System.Windows;
using Structures;

namespace MainApplication.Classes
{
    public class PropertyFoundEventArgs : EventArgs
    {
        public Property Property { get; set; }
        public PropertyList PropertyList { get; set; }
        public ObservableCollection<Citizen> PermanentPeople { get; set; }
        public ObservableCollection<Property> PropertyListProperties { get; set; }
        public ObservableCollection<OwnershipInterest> PropertyListOwners { get; set; }
    }

    public class PermanentPeopleFoundEventArgs : EventArgs
    {
        public ObservableCollection<Citizen> PermanentPeople { get; set; }
    }

    public class Property
    {
        public int PropertyId { get; set; }
        public String Adress { get; set; }
        public String Description { get; set; }
        public PropertyList PropertyList { get; set; }
        public AvlTree<string, Citizen> PermanentPeople { get; set; } // unique ean of citizen

        public event EventHandler<PropertyFoundEventArgs> PropertyFound;

        public event EventHandler<PermanentPeopleFoundEventArgs> PermanentPeopleFound; 

        public Property(int propertyId, string adress, string description)
        {
            PropertyId = propertyId;
            Adress = adress;
            Description = description;
            PermanentPeople = new AvlTree<string, Citizen>();
        }

        public bool AssignResidenceOs(string OldOwner, string NewOwner, int cadastalId, Cadastral cadastral)
        {
            Citizen oldOwner = State.Instance.Citizens.Find(OldOwner);
            Citizen newOwner = State.Instance.Citizens.Find(NewOwner);
            if (oldOwner != null)
            {
                if (newOwner != null)
                {
                    foreach (Property p in PropertyList.Properties.GetDataEnumerator())
                    {
                        oldOwner.AllProperties.Delete(p.PropertyId); // staremu zmazem zo vsetkych
                        oldOwner.PropertiesByCadastral.Find(cadastalId).Delete(p.PropertyId); // staremu zmazem zo vsetkych podla katastra
                    }

                    OwnershipInterest Oldownership = PropertyList.Owners.Find(oldOwner.EAN); // podiel stareho
                    OwnershipInterest Newownership = PropertyList.Owners.Find(newOwner.EAN); // podiel noveho
                    int oldCitizenInterest = Oldownership.Interest;

                    if (Newownership != null) // ak sa novy nachadzal na liste vlastnictva
                    {
                        Newownership.Interest = Newownership.Interest + oldCitizenInterest;
                        PropertyList.Owners.Delete(oldOwner.EAN);
                    }
                    else // ak na liste vlastnicvta nebol
                    {
                        foreach (Property p in PropertyList.Properties.GetDataEnumerator()) // novemu priradim nehnutelnosti
                        {
                            newOwner.AllProperties.Insert(p.PropertyId, p);

                            AvlTree<int, Property> foundTree = newOwner.PropertiesByCadastral.Find(cadastral.CadastralId);
                            if (foundTree != null) // ak hej
                            {
                                foundTree.Insert(p.PropertyId, p);
                            }
                            else // ak nie
                            {
                                newOwner.PropertiesByCadastral.Insert(cadastral.CadastralId, new AvlTree<int, Property>());
                                newOwner.PropertiesByCadastral.Find(cadastral.CadastralId).Insert(p.PropertyId, p);
                            }
                        }
                        OwnershipInterest newInterest = new OwnershipInterest(newOwner, Oldownership.Interest); // spravim mu podiel, ma podiel toho stareho
                        PropertyList.Owners.Insert(newOwner.EAN, newInterest); // podiel dam do listu
                        PropertyList.Owners.Delete(oldOwner.EAN);
                    }

                    MessageBox.Show("Property owner assigned", "Warning", MessageBoxButton.OK);
                    return true;
                }
                else
                {
                    MessageBox.Show("New owner ean is invalid", "Warning", MessageBoxButton.OK);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Old owner ean is invalid", "Warning", MessageBoxButton.OK);
                return false;
            }
        }

        public void DeleteProperty(PropertyList propertyList, int cadastralId, int propertyId, Cadastral cadastral)
        {
            foreach (Citizen c in PermanentPeople.GetDataEnumerator()) // všetkym z nej odstranim trvaly pobyt
            {
                c.PermanentResidance = null;
            }

            foreach (OwnershipInterest oi in propertyList.Owners.GetDataEnumerator()) // zmazať ownerovi z dvoch stromov
            {
                oi.Citizen.AllProperties.Delete(PropertyId);
                oi.Citizen.PropertiesByCadastral.Find(cadastralId).Delete(propertyId);
            }
            propertyList.Properties.Delete(PropertyId);
            cadastral.CadastralProperties.Delete(PropertyId);
        }

        public void FindByName()
        {
            ObservableCollection<Citizen> permanentPeople = new ObservableCollection<Citizen>();
            ObservableCollection<Property> propertyListProperties = new ObservableCollection<Property>();
            ObservableCollection<OwnershipInterest> propertyListOwners = new ObservableCollection<OwnershipInterest>();
            foreach (Citizen c in PermanentPeople.GetDataEnumerator())
            {
                permanentPeople.Add(c);
            }

            foreach (Property p in PropertyList.Properties.GetDataEnumerator())
            {
                propertyListProperties.Add(p);
            }

            foreach (OwnershipInterest o in PropertyList.Owners.GetDataEnumerator())
            {
                propertyListOwners.Add(o);
            }

            OnPropertyFound(permanentPeople, propertyListProperties, propertyListOwners, PropertyList, this);
        }

        public void FindById()
        {
            ObservableCollection<Citizen> permanentPeople = new ObservableCollection<Citizen>();
            ObservableCollection<Property> propertyListProperties = new ObservableCollection<Property>();
            ObservableCollection<OwnershipInterest> propertyListOwners = new ObservableCollection<OwnershipInterest>();
            foreach (Citizen c in PermanentPeople.GetDataEnumerator())
            {
                permanentPeople.Add(c);
            }

            foreach (Property p in PropertyList.Properties.GetDataEnumerator())
            {
                propertyListProperties.Add(p);
            }

            foreach (OwnershipInterest o in PropertyList.Owners.GetDataEnumerator())
            {
                propertyListOwners.Add(o);
            }
            OnPropertyFound(permanentPeople, propertyListProperties, propertyListOwners, PropertyList, this);
        }

        public void FindPermanentPeople()
        {
            ObservableCollection<Citizen> permanentPeople = new ObservableCollection<Citizen>();
            foreach (Citizen c in PermanentPeople.GetDataEnumerator())
            {
                permanentPeople.Add(c);
            }
            OnPermanentPeopleFound(permanentPeople);
        }

        protected virtual void OnPropertyFound(ObservableCollection<Citizen> permanentPeople, ObservableCollection<Property> propertyListProperties,
            ObservableCollection<OwnershipInterest> propertyListOwners, PropertyList propertyList, Property property)
        {
            if (PropertyFound != null)
            {
                PropertyFound(this, new PropertyFoundEventArgs()
                {
                    PermanentPeople = permanentPeople, PropertyListProperties = propertyListProperties, PropertyListOwners = propertyListOwners
                    , PropertyList = propertyList, Property = property
                });
            }
        }

        protected virtual void OnPermanentPeopleFound(ObservableCollection<Citizen> permanentPeople)
        {
            if (PermanentPeopleFound != null)
            {
                PermanentPeopleFound(this, new PermanentPeopleFoundEventArgs() {PermanentPeople = permanentPeople});
            }
        }
    }
}
