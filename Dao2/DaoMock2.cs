﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Durczak.AplikacjaWielowarstowa.Core;
using Durczak.AplikacjaWielowarstowa.Interfaces;

namespace Durczak.AplikacjaWielowarstowa.Dao2
{
    public class DaoMock2 : IDao
    {
        private List<IProducer> _producerList;
        private List<IProduct> _productList;

        public DaoMock2()
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
            RemoveProductById(product.Id);
            _productList.Add(product);
        }

        public void InsertOrUpdate(IProducer producer)
        {
            RemoveProducerById(producer.Id);
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
            var product = productBuilder.SetName("AK-47")
                .SetId(1)
                .SetMaterial(Material.MetalWood)
                .SetPropulsion(Propulsion.Electrical)
                .SetProducerId(1)
                .SetVelocity(330)
                .Build();
            _productList.Add(product);

            product = productBuilder
                .SetName("AUG")
                .SetId(2)
                .SetMaterial(Material.Plastic)
                .SetPropulsion(Propulsion.Electrical)
                .SetProducerId(1)
                .SetVelocity(340)
                .Build();
            _productList.Add(product);

            product = productBuilder
                .SetName("M24")
                .SetId(3)
                .SetMaterial(Material.Metal)
                .SetPropulsion(Propulsion.Mechanical)
                .SetProducerId(2)
                .SetVelocity(420)
                .Build();
            _productList.Add(product);

            product = productBuilder
                .SetName("Desert Eagle")
                .SetId(4)
                .SetMaterial(Material.Metal)
                .SetPropulsion(Propulsion.Gas)
                .SetProducerId(3)
                .SetVelocity(260)
                .Build();
            _productList.Add(product);

            product = productBuilder
                .SetName("P90")
                .SetId(5)
                .SetMaterial(Material.PlasticMetal)
                .SetPropulsion(Propulsion.Electrical)
                .SetProducerId(3)
                .SetVelocity(280)
                .Build();
            _productList.Add(product);

            var producerBuilder = new ProducerBuilder();
            var producer = producerBuilder
                .SetName("Deep Fire")
                .SetId(1)
                .SetOriginCountry("USA")
                .Build();
            _producerList.Add(producer);

            producer = producerBuilder
                .SetName("MadBull Airsoft")
                .SetId(2)
                .SetOriginCountry("USA")
                .Build();
            _producerList.Add(producer);


            producer = producerBuilder
                .SetName("WE")
                .SetId(3)
                .SetOriginCountry("United Kingdom")
                .Build();
            _producerList.Add(producer);
        }
    }
}
