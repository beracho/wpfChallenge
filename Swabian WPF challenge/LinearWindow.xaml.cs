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
    public partial class LinearWindow : Window
    {
        LinearViewModel LinearViewModel;
        public LinearWindow()
        {
            InitializeComponent();
            LinearViewModel = new LinearViewModel();
            this.DataContext = LinearViewModel;
        }
        public LinearWindow(double a, double b)
        {
            InitializeComponent();
            LinearViewModel = new LinearViewModel(a, b);
            this.DataContext = LinearViewModel;
        }
    }
}
