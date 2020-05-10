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

        public PowerViewModel(double a, double b)
        {
            this.FunctionModel = new PlotModel { Title = "Power regresion [ f(x) = " + a + " x ^ " + b + " ]" };
            Func<double, double> powerFunction = (x) => a * Math.Pow(x, b);
            FunctionModel.Series.Add(new FunctionSeries(powerFunction, -10, 10, 0.0001));
            // view limits
            FunctionModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Minimum = -10, Maximum = 10 });
            FunctionModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = -10, Maximum = 10 });
        }

        public PlotModel FunctionModel { get; private set; }
    }
}
