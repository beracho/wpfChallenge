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
        //List<DataPoint> _points;
        public LinearViewModel()
        {
            this.LinearModel = new PlotModel { Title = "Example 1" };
            this.LinearModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
        }

        public LinearViewModel(double a, double b)
        {
            this.LinearModel = new PlotModel { Title = "Linear regresion" };
            Func<double, double> linearFunction = (x) => (b * x) + a;
            LinearModel.Series.Add(new FunctionSeries(linearFunction, -10, 10, 0.0001));
            // view limits
            LinearModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Minimum = -10, Maximum = 10 });
            LinearModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = -10, Maximum = 10 });
        }

        public PlotModel LinearModel { get; private set; }
    }
}
