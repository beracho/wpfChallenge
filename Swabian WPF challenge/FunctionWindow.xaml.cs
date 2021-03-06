﻿using OxyPlot;
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
        public bool successfullLoad;
        public string errorMessage;
        public FunctionWindow()
        {
            InitializeComponent();
            LinearViewModel = new LinearViewModel();
            ExponentialViewModel = new ExponentialViewModel();
            PowerViewModel = new PowerViewModel();
        }
        public FunctionWindow(double[] xdata, double[] ydata, string functionType)
        {
            InitializeComponent();
            successfullLoad = true;
            try
            {

                if (functionType == "Lineal")
                {
                    LinearViewModel = new LinearViewModel(xdata, ydata, minAndMax(xdata), minAndMax(ydata));
                    if (!LinearViewModel.displayed)
                    {
                        errorMessage = "It was not possible a lineal regression QR";
                        successfullLoad = false;
                    }
                    this.DataContext = LinearViewModel;
                }
                if (functionType == "Exponential")
                {
                    ExponentialViewModel = new ExponentialViewModel(xdata, ydata, minAndMax(xdata), minAndMax(ydata));
                    if (!ExponentialViewModel.displayed)
                    {
                        errorMessage = "It was not possible an exponential regression QR";
                        successfullLoad = false;
                    }
                    this.DataContext = ExponentialViewModel;
                }
                if (functionType == "Power function")
                {
                    PowerViewModel = new PowerViewModel(xdata, ydata, minAndMax(xdata), minAndMax(ydata));
                    if (!PowerViewModel.displayed)
                    {
                        successfullLoad = false;
                    }
                    this.DataContext = PowerViewModel;
                }
            }
            catch (Exception)
            {
                errorMessage = "Unexpected error";
                successfullLoad = false;
            }
        }

        public Tuple<double, double> minAndMax(double[] data)
        {
            double min = double.MaxValue;
            double max = double.MinValue;
            for(int i = 0; i < data.Length; i++)
            {
                if (data[i] > max)
                    max = data[i];
                if (data[i] < min)
                    min = data[i];
            }
            if (max == min)
            {
                max += 2;
                min -= 2;
            }
            return new Tuple<double, double>(min, max);
        }
    }
}
