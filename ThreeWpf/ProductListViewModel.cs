using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Durczak.AplikacjaWielowarstowa.BL;
using Durczak.AplikacjaWielowarstowa.Interfaces;

namespace ThreeWpf
{
    public class ProductListViewModel : BasicViewModel
    {
        private ObservableCollection<ProductViewModel> _productList;
        private ListCollectionView _view;

        private LogicController controller;

        private RelayCommand _createProductCommand;

        public RelayCommand CreateProductCommand
        {
            get => _createProductCommand;
        }


        private RelayCommand _saveProductCommand;

        public RelayCommand SaveProductCommand
        {
            get => _saveProductCommand;
        }

        private RelayCommand _removeProductCommand;

        public RelayCommand RemoveProductCommand
        {
            get => _removeProductCommand;
        }

        public ObservableCollection<ProductViewModel> ProductList
        {
            get { return _productList; }
            set
            {
                _productList = value;
                OnPropertyChanged("ProductList");
            }

        }

        private int _selectedItem;

        public ProductViewModel SelectedItem
        {
            get { return _editProduct; }
            set
            {
                if (value == null)
                    EditProduct = null;
                else
                    EditProduct = new ProductViewModel(value.GetProduct());
                OnPropertyChanged(nameof(SelectedItem));

            }
        }

        public ProductListViewModel(String databaseName)
        {
            this.controller = new LogicController(databaseName);

            _productList = new ObservableCollection<ProductViewModel>();
            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(_productList);
            InitViewModels();

            _createProductCommand = new RelayCommand(param => this.CreateNewProduct(), param => this.CanCreateProduct());
            _removeProductCommand = new RelayCommand(param => this.DeleteProduct(), param => this.CanRemoveProduct());
            _saveProductCommand = new RelayCommand(param => this.SaveProduct(), param => this.CanSaveProduct());
        }

        private void InitViewModels()
        {
            var productList = controller.GetAllProducts();
            ProductList.Clear();
            foreach (var product in productList)
            {
                ProductList.Add(new ProductViewModel(product));
            }
        }


        private ProductViewModel _editProduct;

        public ProductViewModel EditProduct
        {
            get => _editProduct;
            set
            {
                _editProduct = value;
                OnPropertyChanged(nameof(EditProduct));
            }
        }

        private void CreateNewProduct()
        {
            EditProduct = new ProductViewModel(new Product());
            EditProduct.Name = "";
        }

        private bool CanCreateProduct()
        {
            if (EditProduct == null)
            {
                return true;
            }
            else if (!EditProduct.HasErrors)
            {
                return true;
            }

            return false;
        }

        private bool CanSaveProduct()
        {

            if (EditProduct == null)
            {
                return false;
            }
            else if (EditProduct.HasErrors)
            {
                return false;
            }

            return true;
        }

        private bool CanRemoveProduct()
        {

            if (EditProduct == null)
            {
                return false;
            }
            else if (EditProduct.HasErrors)
            {
                return false;
            }

            return true;
        }

        private void SaveProduct()
        {
            controller.InsertOrUpdate(EditProduct.GetProduct());
            InitViewModels();
            EditProduct = null;
        
        }

        private void DeleteProduct()
        {
            controller.RemoveProductById(EditProduct.GetProduct().Id);
            InitViewModels();
            EditProduct = null;
        }
        
    }
}
