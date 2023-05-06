using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Apartment
    {
        public string Addres { get; set; }
        public int CostApartment { get; set; }
        public int CountOfRoom { get; set; }
        public bool PrivatePlot { get; set; }
    }
}
