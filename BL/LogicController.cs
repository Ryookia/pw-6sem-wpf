﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Durczak.AplikacjaWielowarstowa.Dao;
using Durczak.AplikacjaWielowarstowa.Interfaces;
using System.IO;

namespace Durczak.AplikacjaWielowarstowa.BL
{
    public class LogicController : IBusinessLogic
    {

        private readonly IDao _database;
        public static LogicController Instance;

        public static void Init(string databaseName)
        {
            Instance = new LogicController(databaseName);
        }

        private LogicController(string databaseName)
        {
            var dllPath = Directory.GetCurrentDirectory() + @"\" + databaseName;
            Assembly assembly = null;
            try
            {
                assembly = Assembly.LoadFrom(dllPath);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Unable to find database file, add database dll into the release folder");
                Console.WriteLine(e.StackTrace);
                System.Environment.Exit(1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                System.Environment.Exit(1);
            }
             
            var daoFound = false;
            foreach (var type in assembly.GetTypes())
            {
                if(daoFound)
                    break;

                foreach (var interfaceVar in type.GetInterfaces())
                {
                    if (interfaceVar != typeof(Interfaces.IDao))
                        continue;
                   
                    _database = (IDao) Activator.CreateInstance(type, new object[] { });
                    daoFound = true;
                    break;

                }
                
            }
            if (!daoFound)
                throw new Exception("Unable to load database");

        }

        public List<IProducer> GetAllProducers()
        {
            return _database.GetProducerList();
        }

        public List<IProduct> GetAllProducts()
        {
            return _database.GetProductList();
        }

        public List<IProducer> GetProducersSorted()
        {
            throw new NotImplementedException();
        }

        public List<IProducer> GetProductsSorted()
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(IProduct product)
        {
            _database.InsertOrUpdate(product);
        }

        public void InsertOrUpdate(IProducer producer)
        {
            _database.InsertOrUpdate(producer);
        }

        public void Remove(IProduct product)
        {
            _database.Remove(product);
        }

        public void Remove(IProducer producer)
        {
            _database.Remove(producer);
        }

        public void RemoveProducerById(int id)
        {
            _database.RemoveProducerById(id);
        }

        public void RemoveProductById(int id)
        {
            _database.RemoveProductById(id);
        }
    }
}
