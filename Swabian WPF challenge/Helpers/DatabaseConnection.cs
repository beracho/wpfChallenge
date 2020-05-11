using OxyPlot;
using SQLite;
using Swabian_WPF_challenge.Helpers;
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
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(databasePath))
                {
                    conn.CreateTable<PointFile>();
                    pointFile = conn.Table<PointFile>().ToList().OrderBy(c => c.Name).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return pointFile;
        }

        public static void insertIntoDatabase(string path, List<DataPoint> points)
        {
            try
            {
                string[] pathSplit = path.Split('\\').ToArray();
                PointFile newPointFile = new PointFile()
                {
                    Name = pathSplit[pathSplit.Length - 1],
                    Path = path,
                    Date = DateTime.Now,
                    Points = PointsToFile.reverseParse(points)
                };

                using (SQLiteConnection connection = new SQLiteConnection(databasePath))
                {
                    connection.CreateTable<PointFile>();
                    connection.Insert(newPointFile);
                };

            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
