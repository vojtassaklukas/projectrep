using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApplication.Classes
{
    public class OwnershipInterest
    {
        public Citizen Citizen { get; set; }
        public int Interest { get; set; } 

        public OwnershipInterest(Citizen citizen, int interest)
        {
            Citizen = citizen;
            Interest = interest;
        }
    }
}
