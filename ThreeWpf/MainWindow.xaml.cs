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

   
        private LogicController _logicController;

        public LogicController LogicController
        {
            get { return _logicController; }
            set { _logicController = value;  }
        }

        public MainWindow()
        {
            LogicController.Init(Properties.Settings.Default.database_name);
            _logicController = LogicController.Instance;
        }
    }
}
