using Durczak.AplikacjaWielowarstowa.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Durczak.AplikacjaWielowarstowa.Core;

namespace DaoEntitySql
{
    public partial class Product : IProduct
    {

        public Product()
        {

        }

        public Product(IProduct product)
        {
            Id = product.Id;
            Name = product.Name;
            Material = MaterialToString(product.Material);
            Propulsion = PropulsionToString(product.Propulsion);
            ProducerId = product.ProducerId;
            Velocity = product.Velocity;
        }

        int IProduct.Id
        {
            get
            {
                return (int)this.Id;
            }

            set
            {
                this.Id = value;
            }
        }

        Material IProduct.Material
        {
            get
            {
                return MaterialToEnum(Material);
            }

            set
            {
                Material = MaterialToString(value);
            }
        }

        int IProduct.ProducerId
        {
            get
            {
                return (int)ProducerId;
            }

            set
            {
                ProducerId = value;
            }
        }

        Propulsion IProduct.Propulsion
        {
            get
            {
                return PropulsionToEnum(Propulsion);
            }

            set
            {
                Propulsion = PropulsionToString(value);
            }
        }

        int IProduct.Velocity
        {
            get
            {
                return (int)Velocity;
            }

            set
            {
                Velocity = value;
            }
        }


        private Material MaterialToEnum(string material) {
            switch (material)
            {
                case "Plastic":
                    return Durczak.AplikacjaWielowarstowa.Core.Material.Plastic;
                case "Metal":
                    return Durczak.AplikacjaWielowarstowa.Core.Material.Metal;
                case "PlasticMetal":
                    return Durczak.AplikacjaWielowarstowa.Core.Material.PlasticMetal;
                case "MetalWood":
                    return Durczak.AplikacjaWielowarstowa.Core.Material.MetalWood;
            }
            return Durczak.AplikacjaWielowarstowa.Core.Material.Plastic;
        }

        private string MaterialToString(Material material)
        {
            return material.ToString();      
        }

        private Propulsion PropulsionToEnum(string propulsion)
        {
            switch (propulsion)
            {
                case "Gas":
                    return Durczak.AplikacjaWielowarstowa.Core.Propulsion.Gas;
                case "Mechanical":
                    return Durczak.AplikacjaWielowarstowa.Core.Propulsion.Mechanical;
                case "Electrical":
                    return Durczak.AplikacjaWielowarstowa.Core.Propulsion.Electrical;
            }
            return Durczak.AplikacjaWielowarstowa.Core.Propulsion.Gas;
        }

        private string PropulsionToString(Propulsion propulsion)
        {
            return propulsion.ToString();
        }

        public void Update(IProduct product)
        {
            Name = product.Name;
            Velocity = product.Velocity;
            Material = MaterialToString(product.Material);
            Propulsion = PropulsionToString(product.Propulsion);
            ProducerId = product.ProducerId;
        }

    }

    
}
