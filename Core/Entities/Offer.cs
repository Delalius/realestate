using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Offer
    {
        public string OfferName { get; set; }
        public Apartment Apartment { get; set; }
    }
}
