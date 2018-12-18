using System;
using System.Collections.ObjectModel;
using System.Windows;
using MainApplication.Windows;
using Structures;

namespace MainApplication.Classes
{
    public class OwnersFoundEventArgs : EventArgs
    {
        public ObservableCollection<OwnershipInterest> OwnersCollection { get; set; }
    }

    public class PropertyListFoundEventArgs : EventArgs
    {
        public PropertyList PropertyList { get; set; }
        public ObservableCollection<Property> PropertyListProperties { get; set; }
        public ObservableCollection<OwnershipInterest> PropertyListOwners { get; set; }
    }

    public class PropertyList
    {
        public Cadastral Cadastral { get; set; }
        public int PropertyListId { get; set; }
        public AvlTree<int, Property> Properties { get; set; }
        public AvlTree<string, OwnershipInterest> Owners { get; set; }

        public event EventHandler<OwnersFoundEventArgs> OwnersFound;
        public event EventHandler<PropertyListFoundEventArgs> PropertyListFound;

        public PropertyList(Cadastral cadastral, int propertyListId)
        {
            Cadastral = cadastral;
            PropertyListId = propertyListId;
            Properties = new AvlTree<int, Property>();
            Owners = new AvlTree<string, OwnershipInterest>();
        }

        public void AssignExistingOi()
        {
            ObservableCollection<OwnershipInterest> owners = new ObservableCollection<OwnershipInterest>();
            foreach (OwnershipInterest o in Owners.GetDataEnumerator())
            {
                owners.Add(o);
            }
            if (owners.Count != 0)
            {
                OnOwnersFound(owners);
            }
            else
            {
                MessageBox.Show("No ownership data found", "Warning", MessageBoxButton.OK);
            }
        }

        public void AssignOi(Citizen citizen, Cadastral cadastral)
        {
            OwnershipInterest ownership = new OwnershipInterest(citizen, 0);
            ObservableCollection<OwnershipInterest> owners = new ObservableCollection<OwnershipInterest>();
            if (!Owners.Insert(citizen.EAN, ownership))
            {
                MessageBox.Show("Citizen is already an owner", "Warning", MessageBoxButton.OK);
            }
            else
            {
                foreach (OwnershipInterest o in Owners.GetDataEnumerator())
                {
                    owners.Add(o);
                }

                foreach (Property p in Properties.GetDataEnumerator()) // prechadzam cez vsetky property na LV
                {
                    citizen.AllProperties.Insert(p.PropertyId, p); // najprv hodim no vsetkych properties

                    AvlTree<int, Property>
                        foundTree = citizen.PropertiesByCadastral.Find(cadastral
                            .CadastralId); // zistim ci mam uz strom na property s takym catastrom
                    if (foundTree != null) // ak hej
                    {
                        foundTree.Insert(p.PropertyId, p); // pridam tam tu property
                    }
                    else // ak nie
                    {
                        citizen.PropertiesByCadastral.Insert(cadastral.CadastralId,
                            new AvlTree<int, Property>()); // tak najprv spravim novy strom
                        citizen.PropertiesByCadastral.Find(cadastral.CadastralId)
                            .Insert(p.PropertyId, p); // potom ho najdem a vlozim do neho
                    }
                }
                OnOwnersFound(owners);
            }
        }

        public void UnassignOi(Citizen citizen, Cadastral cadastral)
        {
            ObservableCollection<OwnershipInterest> owners = new ObservableCollection<OwnershipInterest>();
            Owners.Delete(citizen.EAN);
            foreach (OwnershipInterest o in Owners.GetDataEnumerator())
            {
                owners.Add(o);
            }

            foreach (Property p in Properties.GetDataEnumerator())
            {
                citizen.AllProperties.Delete(p.PropertyId);
                citizen.PropertiesByCadastral.Find(cadastral.CadastralId).Delete(p.PropertyId);
            }

            if (owners.Count != 0)
            {
                OnOwnersFound(owners);
            }

            MessageBox.Show("Property list owner removed", "Warning", MessageBoxButton.OK);
        }

        public void DeletePropertyList(PropertyList inserted)
        {
            foreach (Property p in Properties.GetDataEnumerator())
            {
                p.PropertyList = inserted;
                inserted.Properties.Insert(p.PropertyId, p);
            }

            foreach (OwnershipInterest oi in Owners.GetDataEnumerator())
            {
                inserted.Owners.Insert(oi.Citizen.EAN, oi);
            }
        }

        public void FindByName()
        {
            ObservableCollection<Property> propertyListProperties = new ObservableCollection<Property>();
            ObservableCollection<OwnershipInterest> propertyListOwners = new ObservableCollection<OwnershipInterest>();
            foreach (Property p in Properties.GetDataEnumerator())
            {
                propertyListProperties.Add(p);
            }

            foreach (OwnershipInterest o in Owners.GetDataEnumerator())
            {
                propertyListOwners.Add(o);
            }

            OnPropertyListFound(propertyListProperties, propertyListOwners, this);
        }

        public void FindById()
        {
            ObservableCollection<Property> propertyListProperties = new ObservableCollection<Property>();
            ObservableCollection<OwnershipInterest> propertyListOwners = new ObservableCollection<OwnershipInterest>();
            foreach (Property p in Properties.GetDataEnumerator())
            {
                propertyListProperties.Add(p);
            }

            foreach (OwnershipInterest o in Owners.GetDataEnumerator())
            {
                propertyListOwners.Add(o);
            }
            OnPropertyListFound(propertyListProperties, propertyListOwners, this);
        }

        protected virtual void OnOwnersFound(ObservableCollection<OwnershipInterest> owners)
        {
            if (OwnersFound != null)
            {
                OwnersFound(this, new OwnersFoundEventArgs() { OwnersCollection = owners });
            }
        }

        protected virtual void OnPropertyListFound(ObservableCollection<Property> propertyListProperties, ObservableCollection<OwnershipInterest> propertyListOwners, PropertyList propertyList)
        {
            if (PropertyListFound != null)
            {
                PropertyListFound(this, new PropertyListFoundEventArgs() {PropertyListProperties = propertyListProperties, PropertyListOwners = propertyListOwners, PropertyList = propertyList});
            }
        }
    }
}
