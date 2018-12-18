using System;
using System.Collections.ObjectModel;
using System.Windows;
using Structures;

namespace MainApplication.Classes
{
    public class PropertiesFoundEventArgs : EventArgs
    {
        public ObservableCollection<Property> Properties { get; set; }
        public ObservableCollection<int> Interests { get; set; }
    }

    public class ResidenceFoundEventArgs : EventArgs
    {
        public Property Property { get; set; }
        public ObservableCollection<Citizen> PermanentPeople { get; set; }
        public PropertyList PropertyList { get; set; }
    }

    public class Citizen
    {
        public String Name { get; set; }
        public String EAN { get; set; }
        public DateTime BirthDate { get; set; }
        public Property PermanentResidance { get; set; }
        public AvlTree<int, Property> AllProperties { get; set; } // unique property id
        public AvlTree<int, AvlTree<int, Property>> PropertiesByCadastral { get; set; } // unique cadastral id and property it

        public event EventHandler<PropertiesFoundEventArgs> PropertiesFound;
        public event EventHandler<ResidenceFoundEventArgs> ResidenceFound; 

        public Citizen(string name, DateTime birthDate, string ean)
        {
            Name = name;
            EAN = ean;
            BirthDate = birthDate;
            PermanentResidance = null;
            AllProperties = new AvlTree<int, Property>();
            PropertiesByCadastral = new AvlTree<int, AvlTree<int, Property>>();
        }

        public void AssignPermanentRes(string Ean, Property property)
        {
            if (PermanentResidance != null)
            {
                PermanentResidance.PermanentPeople.Delete(Ean); // vymazanie stareho trvaleho pobytu ak nejaky bol
            }
            PermanentResidance = property;
            if (!property.PermanentPeople.Insert(Ean, this))
            {
                MessageBox.Show("Citizens permanent residence is already registered", "Warning", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Citizen permanent residence assigned", "Warning", MessageBoxButton.OK);
            }
        }

        public void DeleteCadastralArea(int deletedCadastralId, int InsertedCadastralId)
        {
            AvlTree<int, Property> foundTreeDeleted = PropertiesByCadastral.Find(deletedCadastralId);
            if (foundTreeDeleted != null)
            {
                AvlTree<int, Property> foundTreeInserted = PropertiesByCadastral.Find(InsertedCadastralId);

                if (foundTreeInserted == null)
                {
                    PropertiesByCadastral.Insert(InsertedCadastralId, new AvlTree<int, Property>());
                }

                foundTreeInserted = PropertiesByCadastral.Find(InsertedCadastralId);

                foreach (Property property in foundTreeDeleted.GetDataEnumerator())
                {
                    foundTreeInserted.Insert(property.PropertyId, property);
                }

                foreach (Property property in foundTreeDeleted.GetDataEnumerator())
                {
                    foundTreeDeleted.Delete(property.PropertyId);
                }
            }
        }

        public void FindCitizenPropertiesCadastral(Cadastral cadastral)
        {
            ObservableCollection<Property> properties = new ObservableCollection<Property>();
            ObservableCollection<int> interests = new ObservableCollection<int>();
            AvlTree<int, Property> foundcadastral = PropertiesByCadastral.Find(cadastral.CadastralId);

            if (foundcadastral != null) // ak hej
            {
                foreach (Property p in foundcadastral.GetDataEnumerator())
                {
                    properties.Add(p);
                    int interest = p.PropertyList.Owners.Find(EAN).Interest;
                    interests.Add(interest);
                }
                OnPropertiesFound(properties, interests);
            }
            else
            {
                MessageBox.Show("Citizen has no properties.", "Alert", MessageBoxButton.OK);
            }
        }

        public void FindCitizenProperties()
        {
            ObservableCollection<Property> properties = new ObservableCollection<Property>();
            ObservableCollection<int> interests = new ObservableCollection<int>();
            foreach (Property p in AllProperties.GetDataEnumerator())
            {
                properties.Add(p);
                int interest = p.PropertyList.Owners.Find(EAN).Interest;
                interests.Add(interest);
            }

            OnPropertiesFound(properties, interests);
        }

        public void FindPermanentResidence()
        {
            ObservableCollection<Citizen> permanentPeople = new ObservableCollection<Citizen>(); 
            foreach (Citizen c in PermanentResidance.PermanentPeople.GetDataEnumerator())
            {
                permanentPeople.Add(c);
            }
            OnResidenceFound(permanentPeople, PermanentResidance, PermanentResidance.PropertyList);
        }

        protected virtual void OnPropertiesFound(ObservableCollection<Property> properties, ObservableCollection<int> interests)
        {
            if (PropertiesFound != null)
            {
                PropertiesFound(this, new PropertiesFoundEventArgs() { Properties = properties, Interests = interests});
            }
        }

        protected virtual void OnResidenceFound(ObservableCollection<Citizen> permanentPeople, Property property, PropertyList propertyList)
        {
            if (ResidenceFound != null)
            {
                ResidenceFound(this, new ResidenceFoundEventArgs());
            }
        }
    }
}
