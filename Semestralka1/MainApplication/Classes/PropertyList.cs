using Structures;

namespace MainApplication.Classes
{
    public class PropertyList
    {
        public Cadastral Cadastral { get; set; }
        public int PropertyListId { get; set; }
        public AvlTree<int, Property> Properties { get; set; }
        public AvlTree<string, OwnershipInterest> Owners { get; set; }

        public PropertyList(Cadastral cadastral, int propertyListId)
        {
            Cadastral = cadastral;
            PropertyListId = propertyListId;
            Properties = new AvlTree<int, Property>();
            Owners = new AvlTree<string, OwnershipInterest>();
        }
    }
}
