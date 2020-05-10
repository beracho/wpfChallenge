using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swabian_WPF_challenge.Models
{
    class PointsViewModel
    {
        public PointsViewModel()
        {
            this.Title = "Display Points";
            this.Points = new List<DataPoint>
            {
                new DataPoint(0, 4),
                new DataPoint(10, 13),
                new DataPoint(20, 15)
            };
        }
        public PointsViewModel(List<DataPoint> points)
        {
            this.Title = "Display Points";
            this.Points = points;
        }

        public string Title { get; private set; }
        public IList<DataPoint> Points { get; private set; }
    }
}
