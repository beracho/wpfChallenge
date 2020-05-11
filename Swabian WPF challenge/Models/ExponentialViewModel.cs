using MathNet.Numerics;
using MathNet.Numerics.LinearRegression;
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
    class ExponentialViewModel
    {
        public ExponentialViewModel()
        {
            this.FunctionModel = new PlotModel { Title = "Default exponential regresion" };
            this.FunctionModel.Series.Add(new FunctionSeries((x) => 2 * Math.Exp(3 * x), 0, 10, 0.1));
        }

        public ExponentialViewModel(double[] xdata, double[] ydata, Tuple<double, double> xlimit, Tuple<double, double> ylimit)
        {
            DirectRegressionMethod method = DirectRegressionMethod.QR;
            Tuple<double, double> p = Fit.Exponential(xdata, ydata, method);
            double a = p.Item1;
            double r = p.Item2;
            this.FunctionModel = new PlotModel { Title = "Exponential regresion [ f(x) = " + a + " * exp( " + r + " * x ) ]" };
            Func<double, double> exponentialFunction = (x) => a * Math.Exp(r * x);
            FunctionModel.Series.Add(new FunctionSeries(exponentialFunction, xlimit.Item1, xlimit.Item2, 0.0001));
            // view limits
            FunctionModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Minimum = xlimit.Item1, Maximum = xlimit.Item2 });
            FunctionModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = ylimit.Item1, Maximum = ylimit.Item2 });
        }

        public PlotModel FunctionModel { get; private set; }
    }
}
