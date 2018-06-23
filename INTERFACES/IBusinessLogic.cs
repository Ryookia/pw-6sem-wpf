using System.Collections.Generic;

namespace Durczak.AplikacjaWielowarstowa.Interfaces
{
    public interface IBusinessLogic
    {
        List<IProducer> GetAllProducers();
        List<IProducer> GetProducersSorted();

        List<IProduct> GetAllProducts();
        List<IProducer> GetProductsSorted();

        void InsertOrUpdate(IProduct product);

        void InsertOrUpdate(IProducer producer);

        void Remove(IProduct product);

        void Remove(IProducer producer);

        void RemoveProducerById(int id);

        void RemoveProductById(int id);
    }
}