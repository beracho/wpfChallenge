using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swabian_WPF_challenge.Helpers
{
    class PointsToFile
    {
        public static List<DataPoint> parse(string fileData)
        {
            List<string> aux = fileData.Split('|').ToList();
            List<DataPoint> response = new List<DataPoint>();
            foreach(string value in aux)
            {
                string[] point = value.Split(';').ToArray();
                if (point.Length == 2)
                    response.Add(new DataPoint(double.Parse(point[0]), double.Parse(point[1])));
                else
                    return null;
            }

            return response;
        }

        public static string reverseParse(List<DataPoint> Points)
        {
            string newPoints = "";
            foreach (var value in Points)
            {
                if (!newPoints.Equals(""))
                    newPoints += "|";
                newPoints += value.X + ";" + value.Y;
            }
            return newPoints;
        }
    }

}
