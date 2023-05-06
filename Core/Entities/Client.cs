using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Client
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string CardNamber { get; set; }
        public List<Offer> Offers { get; set; }

        public Client()
        {
            Offers = new List<Offer>();
        }
    }
}
