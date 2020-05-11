using MathNet.Numerics;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swabian_WPF_challenge.Models
{
    class LinearViewModel
    {
        public LinearViewModel()
        {
            this.FunctionModel = new PlotModel { Title = "Default line regresion" };
            this.FunctionModel.Series.Add(new FunctionSeries((x) => (2 * x) + 3, 0, 10, 0.1));
        }

        public LinearViewModel(double[] xdata, double[] ydata, Tuple<double, double> xlimit, Tuple<double, double> ylimit)
        {
            Tuple<double, double> p = Fit.Line(xdata, ydata);
            double a = p.Item1;
            double b = p.Item2;
            this.FunctionModel = new PlotModel { Title = "Linear regresion [ f(x) = " + b + " x + " + a + " ]" };
            Func<double, double> linearFunction = (x) => (b * x) + a;
            FunctionModel.Series.Add(new FunctionSeries(linearFunction, xlimit.Item1, xlimit.Item2, 0.0001));
            // view limits
            FunctionModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Minimum = xlimit.Item1, Maximum = xlimit.Item2 });
            FunctionModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = ylimit.Item1, Maximum = ylimit.Item2 });
        }

        public PlotModel FunctionModel { get; private set; }
    }
}
