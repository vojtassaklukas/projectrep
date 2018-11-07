using System;
using Structures;

namespace MainApplication.Classes
{
    public class Property
    {
        public int PropertyId { get; set; }
        public String Adress { get; set; }
        public String Description { get; set; }
        public PropertyList PropertyList { get; set; }
        public AvlTree<string, Citizen> PermanentPeople { get; set; } // unique ean of citizen

        public Property(int propertyId, string adress, string description)
        {
            PropertyId = propertyId;
            Adress = adress;
            Description = description;
            PermanentPeople = new AvlTree<string, Citizen>();
        }
    }
}
