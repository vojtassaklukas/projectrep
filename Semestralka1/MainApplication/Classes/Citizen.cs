using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApplication.Classes
{
    class Citizen
    {
        public String Name { get; set; }
        public String EAN { get; set; }
        public DateTime BirthDay { get; set; }
        public Property PermanentResidance { get; set; }

        public Citizen(string name, string ean, DateTime birthDay, Property permanentResidance)
        {
            Name = name;
            EAN = ean;
            BirthDay = birthDay;
            PermanentResidance = permanentResidance;
        }
    }
}
