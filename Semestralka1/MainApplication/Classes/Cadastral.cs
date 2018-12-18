using System;
using System.Collections.ObjectModel;
using Structures;

namespace MainApplication.Classes
{
    public class CadastralPropertiesFoundEventArgs : EventArgs
    {
        public ObservableCollection<Property> Properties { get; set; }
    }

    public class Cadastral
    {
        public int CadastralId { get; set; }
        public String CadastralName { get; set; }
        public AvlTree<int, PropertyList> PropertyLists { get; set; } // unique id of property list
        public AvlTree<int, Property> CadastralProperties { get; set; } // unique id of property

        public event EventHandler<CadastralPropertiesFoundEventArgs> CadastralPropertiesFound;

        public Cadastral(int cadastralId, string cadastralName)
        {
            CadastralId = cadastralId;
            CadastralName = cadastralName;
            PropertyLists = new AvlTree<int, PropertyList>();
            CadastralProperties = new AvlTree<int, Property>();
        }

        public void ShowProperties()
        {
            ObservableCollection<Property> properties = new ObservableCollection<Property>();
            foreach (Property p in CadastralProperties.GetDataEnumerator())
            {
                properties.Add(p);
            }
            OnPropertiesFound(properties);
        }

        protected virtual void OnPropertiesFound(ObservableCollection<Property> properties)
        {
            if (CadastralPropertiesFound != null)
            {
                CadastralPropertiesFound(this, new CadastralPropertiesFoundEventArgs() {Properties = properties});
            }
        }
    }
}
