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
    class PowerViewModel
    {
        public PowerViewModel()
        {
            this.FunctionModel = new PlotModel { Title = "Default power regresion" };
            this.FunctionModel.Series.Add(new FunctionSeries((x) => (2 * x) + 3, 0, 10, 0.1));
        }

        public PowerViewModel(double[] xdata, double[] ydata, Tuple<double, double> xlimit, Tuple<double, double> ylimit)
        {
            DirectRegressionMethod method = DirectRegressionMethod.QR;
            Tuple<double, double> p = Fit.Power(xdata, ydata, method);
            double a = p.Item1;
            double b = p.Item2;
            if (!Double.IsNaN(a) && !Double.IsNaN(b))
            {
                this.FunctionModel = new PlotModel { Title = "Power regresion [ f(x) = " + a + " x ^ " + b + " ]" };
                Func<double, double> powerFunction = (x) => a * Math.Pow(x, b);
                FunctionModel.Series.Add(new FunctionSeries(powerFunction, xlimit.Item1, xlimit.Item2, 0.0001));
                // view limits
                FunctionModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Minimum = xlimit.Item1, Maximum = xlimit.Item2 });
                FunctionModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = ylimit.Item1, Maximum = ylimit.Item2 });
            }
            else
                displayed = false;
        }

        public PlotModel FunctionModel { get; private set; }
        public bool displayed;
    }
}
