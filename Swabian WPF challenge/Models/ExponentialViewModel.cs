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

        public ExponentialViewModel(double a, double r)
        {
            this.FunctionModel = new PlotModel { Title = "Exponential regresion [ f(x) = " + a + " * exp( " + r + " * x ) ]" };
            Func<double, double> exponentialFunction = (x) => a * Math.Exp(r * x);
            FunctionModel.Series.Add(new FunctionSeries(exponentialFunction, -10, 10, 0.0001));
            // view limits
            FunctionModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Minimum = -10, Maximum = 10 });
            FunctionModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = -10, Maximum = 10 });
        }

        public PlotModel FunctionModel { get; private set; }
    }
}
