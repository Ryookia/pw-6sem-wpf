using System;
using System.Collections.Generic;
using Durczak.AplikacjaWielowarstowa.Interfaces;

namespace DaoEntity
{
    public class Base : IDao
    {

        public Base()
        {

        }

    public List<IProduct> GetProductList()
        {
            throw new NotImplementedException();
        }

        public IProducer GetProductById()
        {
            throw new NotImplementedException();
        }

        public void RemoveProductById(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(IProduct product)
        {
            throw new NotImplementedException();
        }

        public void Remove(IProduct product)
        {
            throw new NotImplementedException();
        }

        public List<IProducer> GetProducerList()
        {
            throw new NotImplementedException();
        }

        public IProducer GetProducerById()
        {
            throw new NotImplementedException();
        }

        public void RemoveProducerById(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(IProducer producer)
        {
            throw new NotImplementedException();
        }

        public void Remove(IProducer producer)
        {
            throw new NotImplementedException();
        }
    }
}
