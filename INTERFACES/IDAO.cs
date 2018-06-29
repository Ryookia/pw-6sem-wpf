using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durczak.AplikacjaWielowarstowa.Interfaces
{
    public interface IDao
    {
        List<IProduct> GetProductList();
        IProduct GetProductById(int id);
        void RemoveProductById(int id);
        void InsertOrUpdate(IProduct product);
        void Remove(IProduct product);

        List<IProducer> GetProducerList();
        IProducer GetProducerById(int id);
        void RemoveProducerById(int id);
        void InsertOrUpdate(IProducer producer);
        void Remove(IProducer producer);

    }
}
