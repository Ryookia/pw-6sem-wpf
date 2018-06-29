using Durczak.AplikacjaWielowarstowa.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoEntitySql
{
    public partial class Producer : IProducer
    {

        public Producer()
        {

        }

        public Producer(IProducer producer)
        {
            Id = producer.Id;
            Name = producer.Name;
            CountryOrigin = producer.CountryOrigin;
        }
    

        string IProducer.CountryOrigin
        {
            get
            {
                return CountryOrigin;
            }

            set
            {
                CountryOrigin = value;
            }
        }

        int IProducer.Id
        {
            get
            {
                return (int)Id;
            }

            set
            {
                Id = value;
            }
        }

        string IProducer.Name
        {
            get
            {
                return Name;    
            }

            set
            {
                Name = value;
            }
        }
    }
}
