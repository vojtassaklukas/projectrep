using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApplication.Classes
{
    public class Property
    {
        public int PropertyId { get; set; }
        public String Adress { get; set; }
        public String Description { get; set; }

        public Property(int propertyId, string adress, string description)
        {
            PropertyId = propertyId;
            Adress = adress;
            Description = description;
        }
    }
}
