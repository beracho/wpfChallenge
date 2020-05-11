using MathNet.Numerics;
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
    /// Interaction logic for GraphWindow.xaml
    /// </summary>
    public partial class GraphWindow : System.Windows.Window
    {
        public IList<DataPoint> Points;
        PointsViewModel PointsViewModel;
        public GraphWindow(List<DataPoint> points)
        {
            InitializeComponent();
            Points = points;
            PointsViewModel = new PointsViewModel(points);
            this.DataContext = PointsViewModel;
        }

        private void FunctionButton_Click(object sender, RoutedEventArgs e)
        {
            Button functionButton = sender as Button;
            double[] xdata = Points.Select(d => d.X).ToArray();
            double[] ydata = Points.Select(d => d.Y).ToArray(); ;

            FunctionWindow functionWindow = new FunctionWindow(xdata, ydata, functionButton.Content.ToString());
            functionWindow.ShowDialog();
        }
    }
}
