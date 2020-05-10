﻿using OxyPlot;
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

        public LinearViewModel(double a, double b)
        {
            this.FunctionModel = new PlotModel { Title = "Linear regresion [ f(x) = " + b + " x + " + a + " ]" };
            Func<double, double> linearFunction = (x) => (b * x) + a;
            FunctionModel.Series.Add(new FunctionSeries(linearFunction, -10, 10, 0.0001));
            // view limits
            FunctionModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Minimum = -10, Maximum = 10 });
            FunctionModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = -10, Maximum = 10 });
        }

        public PlotModel FunctionModel { get; private set; }
    }
}
