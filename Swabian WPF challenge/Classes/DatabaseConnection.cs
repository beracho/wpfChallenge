using OxyPlot;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swabian_WPF_challenge.Classes
{
    class DatabaseConnection
    {
        private static string databaseName = "PointFiles.db";
        private static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string databasePath = System.IO.Path.Combine(folderPath, databaseName);

        static List<PointFile> pointFile;
        public static List<PointFile> ReadDatabase()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(databasePath))
            {
                conn.CreateTable<PointFile>();
                pointFile = conn.Table<PointFile>().ToList();
            }
            return pointFile;
        }

        public static void insertIntoDatabase(string path, List<DataPoint> points)
        {
            List<Tuple<double, double>> newPoints = new List<Tuple<double, double>>();
            foreach(var value in points)
            {
                //Tuple<double, double> My_Tuple2 = new Tuple<double, double>(value.X, value.Y);
                newPoints.Add(new Tuple<double, double>(value.X, value.Y));
            }
            string[] pathSplit = path.Split('\\').ToArray();
            PointFile newPointFile = new PointFile()
            {
                Name = pathSplit[pathSplit.Length - 1],
                Path = path,
                Date = DateTime.Now,
                Points = newPoints
            };

            using (SQLiteConnection connection = new SQLiteConnection(databasePath))
            {
                connection.CreateTable<PointFile>();
                connection.Insert(newPointFile);
            };
        }
    }

}
