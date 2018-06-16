using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Durczak.AplikacjaWielowarstowa.Core;
using Durczak.AplikacjaWielowarstowa.Interfaces;

namespace ThreeWpf
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Propulsion Propulsion { get; set; }
        public Material Material { get; set; }
        public int Velocity { get; set; }
        public int ProducerId { get; set; }



        public override string ToString()
        {
            return "Producer{" +
                   "id= " + Id +
                   ", name= " + Name +
                   ", propulsion= " + Propulsion +
                   ", material= " + Material +
                   ", velocity= " + Velocity + "FPS" +
                   ", producerId= " + ProducerId +
                   "}";
        }
    }
}
