using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Durczak.AplikacjaWielowarstowa.BL;
using Durczak.AplikacjaWielowarstowa.Core;
using Durczak.AplikacjaWielowarstowa.Interfaces;

namespace ThreeWpf
{
    class ProducerViewModel : BasicViewModel
    {
        private IProducer _producer;

        public IProducer GetProducer()
        {
            return _producer;
        }

        public int Id
        {
            get { return _producer.Id; }
            set
            {
                _producer.Id = value;
                OnPropertyChanged(nameof(Id));
                Validate();
            }

        }
        public string Name
        {
            get { return _producer.Name; }
            set
            {
                _producer.Name = value;
                OnPropertyChanged(nameof(Name));
                Validate();
            }

        }
        public string CountryOrigin
        {
            get { return _producer.CountryOrigin; }
            set
            {
                _producer.CountryOrigin = value;
                OnPropertyChanged(nameof(CountryOrigin));
                Validate();
            }

        }
       

        public ProducerViewModel(IProducer producer)
        {
            _producer = new Producer();
            _producer.Id = producer.Id;
            _producer.Name = producer.Name;
            _producer.CountryOrigin = producer.CountryOrigin;
        }

        public void Validate()
        {
            RemoveErrors(nameof(Id));
            RemoveErrors(nameof(Name));
            RemoveErrors(nameof(CountryOrigin));

            if (Id < 0)
            {
                AddError(nameof(Id), "Id can not be negative");
            }

            if (Name.Length < 2)
            {
                AddError(nameof(Name), "Name should contain at least 2 characters");
            }

            if (CountryOrigin == null || CountryOrigin.Length < 2)
            {
                AddError(nameof(CountryOrigin), "Country should contain at least 2 characters");
            }

            OnPropertyChanged(nameof(HasErrors));
        }
    }
}
