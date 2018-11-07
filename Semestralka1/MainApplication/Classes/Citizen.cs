using System;
using Structures;

namespace MainApplication.Classes
{
    public class Citizen
    {
        public String Name { get; set; }
        public String EAN { get; set; }
        public DateTime BirthDate { get; set; }
        public Property PermanentResidance { get; set; }
        public AvlTree<int, Property> AllProperties { get; set; } // unique property id
        public AvlTree<int, AvlTree<int, Property>> PropertiesByCadastral { get; set; } // unique cadastral id and property it

        public Citizen(string name, DateTime birthDate, string ean)
        {
            Name = name;
            EAN = ean;
            BirthDate = birthDate;
            PermanentResidance = null;
            AllProperties = new AvlTree<int, Property>();
            PropertiesByCadastral = new AvlTree<int, AvlTree<int, Property>>();
        }
    }
}
