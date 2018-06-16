using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Durczak.AplikacjaWielowarstowa.Interfaces;

namespace ThreeWpf
{
    public class Producer : IProducer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryOrigin { get; set; }


        public override string ToString()
        {
            return "Producer{" +
                   "id= " + Id +
                   ", name= " + Name +
                   ", countryOrigin= " + CountryOrigin +
                   "}";
        }
    }
}
