using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApplication.Classes
{
    public class Citizen
    {
        public String Name { get; set; }
        public String EAN { get; set; }
        public DateTime BirthDate { get; set; }
        public Property PermanentResidance { get; set; }

        public Citizen(string name, DateTime birthDate , string ean)
        {
            Name = name;
            EAN = ean;
            BirthDate = birthDate;
            PermanentResidance = null;
        }
    }
}
