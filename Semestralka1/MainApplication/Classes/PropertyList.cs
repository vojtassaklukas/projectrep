using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structures;

namespace MainApplication.Classes
{
    public class PropertyList
    {
        public Cadastral Cadastral { get; set; }
        public int PropertyListId { get; set; }
        public AvlTree<int, Property> Properties { get; set; }
        public AvlTree<string, Citizen> Owners { get; set; }

        public PropertyList(Cadastral cadastral, int propertyListId)
        {
            Cadastral = cadastral;
            PropertyListId = propertyListId;
            Properties = new AvlTree<int, Property>();
            Owners = new AvlTree<string, Citizen>();
        }
    }
}
