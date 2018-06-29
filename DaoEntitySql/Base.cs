using System;
using System.Collections.Generic;
using Durczak.AplikacjaWielowarstowa.Interfaces;
using System.Data.Entity;
using System.Data.Linq;
using System.Linq;

namespace DaoEntitySql
{
    public class Base : IDao
    {

        private databaseEntities _databaseContext;

        public Base()
        {
            _databaseContext = new databaseEntities();
            
        }

        public List<IProduct> GetProductList()
        {
            var result = from product in _databaseContext.Products
                         orderby product.Id
                         select product;
            if (result == null) return null;
            return result.ToList<IProduct>();
        }

        public IProduct GetProductById(int id)
        {

            var result = from product in _databaseContext.Products
                         where product.Id == id
                         select product;
 
            return result.FirstOrDefault();
        }

        public void RemoveProductById(int id)
        {
            var product = GetProductById(id);
            if (product == null) return;
            _databaseContext.Products.Remove((Product) product);
            _databaseContext.SaveChanges();

        }

        public void InsertOrUpdate(IProduct product)
        {
            if (product == null) return;
            var productFromDb = GetProductById(product.Id);
            if (productFromDb == null)
            {
                var entity = new Product(product);
                _databaseContext.Products.Add(entity);
            }
            else
            {
                ((Product)productFromDb).Update(product);

            }
            _databaseContext.SaveChanges();

        }

        public void Remove(IProduct product)
        {
            if (product == null) return;
            RemoveProductById(product.Id);

        }

        public List<IProducer> GetProducerList()
        {
            var result = from producer in _databaseContext.Producers
                         orderby producer.Id
                         select producer;

            return result.ToList<IProducer>();
        }

        public IProducer GetProducerById(int id)
        {
            var result = from producer in _databaseContext.Producers
                         where producer.Id == id
                         select producer;
            return result.FirstOrDefault();
        }

        public void RemoveProducerById(int id)
        {
            var producer = GetProducerById(id);
            if (producer == null) return;
            _databaseContext.Producers.Remove((Producer)producer);
            _databaseContext.SaveChanges();

        }

        public void InsertOrUpdate(IProducer producer)
        {
            if(producer == null) return;
            var producerFromDb = GetProducerById(producer.Id);
            if (producerFromDb == null)
            {
                var entity = new Producer(producer);
                _databaseContext.Producers.Add(entity);
            } else
            {
                producerFromDb.Name = producer.Name;
                producerFromDb.CountryOrigin = producer.CountryOrigin;
          
            }
            _databaseContext.SaveChanges();

        }

        public void Remove(IProducer producer)
        {
            if (producer == null) return;
            RemoveProducerById(producer.Id);
        }
    }
}
