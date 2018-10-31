using System;
using Structures;

namespace MainApplication.Classes
{
    public class Cadastral
    {
        public int CadastralId { get; set; }
        public String CadastralName { get; set; }
        public AvlTree<int, PropertyList> PropertyLists { get; set; }

        public Cadastral(int cadastralId, string cadastralName)
        {
            CadastralId = cadastralId;
            CadastralName = cadastralName;
            PropertyLists = new AvlTree<int, PropertyList>();
        }
    }
}
