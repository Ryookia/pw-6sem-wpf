using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel.DataAnnotations;
using Durczak.AplikacjaWielowarstowa.Core;
using Durczak.AplikacjaWielowarstowa.Interfaces;

namespace ThreeWpf
{
    public class ProductViewModel : BasicViewModel
    {
        private IProduct _product;

        public IProduct GetProduct()
        {
            return _product;
        }

        public int Id
        {
            get { return _product.Id; }
            set
            {
                _product.Id = value;
                OnPropertyChanged(nameof(Id));
                Validate();
            }
            
        }
        public string Name
        {
            get { return _product.Name; }
            set
            {
                _product.Name = value;
                OnPropertyChanged(nameof(Name));
                Validate();
            }

        }
        public Propulsion Propulsion
        {
            get { return _product.Propulsion; }
            set
            {
                _product.Propulsion = value;
                OnPropertyChanged(nameof(Propulsion));
                Validate();
            }

        }
        public Material Material
        {
            get { return _product.Material; }
            set
            {
                _product.Material = value;
                OnPropertyChanged(nameof(Material));
                Validate();
            }

        }
        public int Velocity
        {
            get { return _product.Velocity; }
            set
            {
                _product.Velocity = value;
                OnPropertyChanged(nameof(Velocity));
                Validate();
            }

        }
        public int ProducerId
        {
            get { return _product.ProducerId; }
            set
            {
                _product.ProducerId = value;
                OnPropertyChanged(nameof(ProducerId));
                Validate();
            }

        }

        public ProductViewModel(IProduct product)
        {
            _product = new Product();
            _product.Id = product.Id;
            _product.Name = product.Name;
            _product.Propulsion = product.Propulsion;
            _product.Material = product.Material;
            _product.Velocity = product.Velocity;
            _product.ProducerId = product.ProducerId;

        }

        public void Validate()
        {
            RemoveErrors(nameof(Id));
            RemoveErrors(nameof(Name));
            RemoveErrors(nameof(Propulsion));
            RemoveErrors(nameof(Material));
            RemoveErrors(nameof(Velocity));
            RemoveErrors(nameof(ProducerId));

            if (Id < 0)
            {
                AddError(nameof(Id), "Id can not be negative");
            }

            if (Name.Length < 2)
            {
                AddError(nameof(Name), "Name should contain at least 2 characters");
            }

            if (Velocity < 0)
            {
                AddError(nameof(Velocity), "Velocity must be greater than 0");
            }

            if (Velocity >= 800)
            {
                AddError(nameof(Velocity), "That kind of gun is illegal");
            }

            if (ProducerId < 0)
            {
                AddError(nameof(ProducerId), "Producer Id can not be negative");
            }

            OnPropertyChanged(nameof(HasErrors));
        }
    }
}
