using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Durczak.AplikacjaWielowarstowa.BL;
using Durczak.AplikacjaWielowarstowa.Interfaces;

namespace ThreeWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObservableCollection<IProducer> _producerList = new ObservableCollection<IProducer>();
        private ObservableCollection<IProduct> _productList = new ObservableCollection<IProduct>();


        public ObservableCollection<IProducer> ProducerList
        {
            get { return _producerList; }
            set { _producerList = value; }
        }
        public ObservableCollection<IProduct> ProductList
        {
            get { return _productList; }
            set { _productList = value; }
        }
   
        private LogicController _logicController;

        public MainWindow()
        {
            _logicController = new LogicController("Dao2.dll");
            foreach (var producer in _logicController.GetAllProducers().ToList())
            {
                ProducerList.Add(producer);
            }
            foreach (var product in _logicController.GetAllProducts().ToList())
            {
                ProductList.Add(product);
            }
            InitializeComponent();
        }
    }
}
