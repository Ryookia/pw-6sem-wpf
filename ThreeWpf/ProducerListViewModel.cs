using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Durczak.AplikacjaWielowarstowa.BL;

namespace ThreeWpf
{
    class ProducerListViewModel : BasicViewModel
    {
        private ObservableCollection<ProducerViewModel> _producerList;
        private ListCollectionView _view;

        private LogicController controller;

        private RelayCommand _createProducerCommand;

        public RelayCommand CreateProducerCommand
        {
            get { return _createProducerCommand; }
        }


        private RelayCommand _saveProducerCommand;

        public RelayCommand SaveProducerCommand
        {
            get { return _saveProducerCommand; }
        }

        private RelayCommand _removeProducerCommand;

        public RelayCommand RemoveProducerCommand
        {
            get { return _removeProducerCommand; }
        }

        public ObservableCollection<ProducerViewModel> ProducerList
        {
            get { return _producerList; }
            set
            {
                _producerList = value;
                OnPropertyChanged("ProducerList");
            }

        }

        private int _selectedItem;

        public ProducerViewModel SelectedItem
        {
            get { return _editProducer; }
            set
            {
                if (value == null)
                    EditProducer = null;
                else
                    EditProducer = new ProducerViewModel(value.GetProducer());
                OnPropertyChanged(nameof(SelectedItem));

            }
        }

        public ProducerListViewModel()
        {
            this.controller = LogicController.Instance;

            _producerList = new ObservableCollection<ProducerViewModel>();
            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(_producerList);
            InitViewModels();

            _createProducerCommand = new RelayCommand(param => this.CreateNewProducer(), param => this.CanCreateProducer());
            _removeProducerCommand = new RelayCommand(param => this.DeleteProducer(), param => this.CanRemoveProducer());
            _saveProducerCommand = new RelayCommand(param => this.SaveProducer(), param => this.CanSaveProducer());
        }

        private void InitViewModels()
        {
            var producerList = controller.GetAllProducers();
            ProducerList.Clear();
            foreach (var producer in producerList)
            {
                ProducerList.Add(new ProducerViewModel(producer));
            }
        }


        private ProducerViewModel _editProducer;

        public ProducerViewModel EditProducer
        {
            get { return _editProducer; }
            set
            {
                _editProducer = value;
                OnPropertyChanged(nameof(EditProducer));
            }
        }

        private void CreateNewProducer()
        {
            EditProducer = new ProducerViewModel(new Producer());
            EditProducer.Name = "";
            EditProducer.CountryOrigin = "";
        }

        private bool CanCreateProducer()
        {
            if (EditProducer == null)
            {
                return true;
            }
            else if (!EditProducer.HasErrors)
            {
                return true;
            }

            return false;
        }

        private bool CanSaveProducer()
        {

            if (EditProducer == null)
            {
                return false;
            }
            else if (EditProducer.HasErrors)
            {
                return false;
            }

            return true;
        }

        private bool CanRemoveProducer()
        {

            if (EditProducer == null)
            {
                return false;
            }
            else if (EditProducer.HasErrors)
            {
                return false;
            }

            return true;
        }

        private void SaveProducer()
        {
            controller.InsertOrUpdate(EditProducer.GetProducer());
            InitViewModels();
            EditProducer = null;

        }

        private void DeleteProducer()
        {
            controller.RemoveProducerById(EditProducer.GetProducer().Id);
            InitViewModels();
            EditProducer = null;
        }
    }
}
