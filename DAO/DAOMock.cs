using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Durczak.AplikacjaWielowarstowa.Core;
using Durczak.AplikacjaWielowarstowa.Interfaces;

namespace Durczak.AplikacjaWielowarstowa.Dao
{
    public class DaoMock : IDao
    {

        private List<IProducer> _producerList;
        private List<IProduct> _productList;

        public DaoMock()
        {
            _producerList = new List<IProducer>();
            _productList = new List<IProduct>();
            InjectMockData();
        }

        public IProducer GetProducerById()
        {
            throw new NotImplementedException();
        }

        public List<IProducer> GetProducerList()
        {
            return _producerList;
        }

        public IProducer GetProductById()
        {
            throw new NotImplementedException();
        }

        public List<IProduct> GetProductList()
        {
            return _productList;
        }

        public void InsertOrUpdate(IProduct product)
        {
            Remove(product);
            _productList.Add(product);
        }

        public void InsertOrUpdate(IProducer producer)
        {
            Remove(producer);
            _producerList.Add(producer);
        }

        public void Remove(IProduct product)
        {
            _productList.Remove(product);
        }

        public void Remove(IProducer producer)
        {
            _producerList.Remove(producer);
        }

        public void RemoveProducerById(int id)
        {
            foreach (var producer in _producerList)
            {
                if (producer.Id == id)
                {
                    _producerList.Remove(producer);
                    break;
                }
            }
        }

        public void RemoveProductById(int id)
        {
            foreach (var product in _productList)
            {
                if (product.Id == id)
                {
                    _productList.Remove(product);
                    break;
                }
            }
        }

        private void InjectMockData()
        {
            var productBuilder = new ProductBuilder();
            var product = productBuilder.SetName("MBR")
                .SetId(1)
                .SetMaterial(Material.Metal)
                .SetPropulsion(Propulsion.Gas)
                .SetProducerId(1)
                .SetVelocity(400)
                .Build();
            _productList.Add(product);

            product = productBuilder
                .SetName("MP5")
                .SetId(2)
                .SetMaterial(Material.PlasticMetal)
                .SetPropulsion(Propulsion.Electrical)
                .SetProducerId(1)
                .SetVelocity(330)
                .Build();
            _productList.Add(product);

            product = productBuilder
                .SetName("SPAS 12")
                .SetId(3)
                .SetMaterial(Material.PlasticMetal)
                .SetPropulsion(Propulsion.Mechanical)
                .SetProducerId(2)
                .SetVelocity(180)
                .Build();
            _productList.Add(product);

            var producerBuilder = new ProducerBuilder();
            var producer = producerBuilder
                .SetName("HK")
                .SetId(1)
                .SetOriginCountry("China")
                .Build();
            _producerList.Add(producer);

            producer = producerBuilder
                .SetName("ASG")
                .SetId(2)
                .SetOriginCountry("USA")
                .Build();
            _producerList.Add(producer);
        }
    }
}
