using OxyPlot;
using Swabian_WPF_challenge.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Swabian_WPF_challenge
{
    /// <summary>
    /// Interaction logic for LinearWindow.xaml
    /// </summary>
    public partial class FunctionWindow : Window
    {
        LinearViewModel LinearViewModel;
        ExponentialViewModel ExponentialViewModel;
        PowerViewModel PowerViewModel;
        public FunctionWindow()
        {
            InitializeComponent();
            LinearViewModel = new LinearViewModel();
            ExponentialViewModel = new ExponentialViewModel();
            PowerViewModel = new PowerViewModel();
        }
        public FunctionWindow(double a, double b, string functionType)
        {
            InitializeComponent();
            if (functionType == "Lineal")
            {
                LinearViewModel = new LinearViewModel(a, b);
                this.DataContext = LinearViewModel;
            }
            if (functionType == "Exponential")
            {
                ExponentialViewModel = new ExponentialViewModel(a, b);
                this.DataContext = ExponentialViewModel;
            }
            if (functionType == "Power function")
            {
                PowerViewModel = new PowerViewModel(a, b);
                this.DataContext = PowerViewModel;
            }
        }
    }
}
