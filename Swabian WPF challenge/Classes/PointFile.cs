using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swabian_WPF_challenge.Classes
{
    public class PointFile
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name;
        public string Path;
        public DateTime Date;
        public string Points;
        public PointFile()
        {
            Name = "file.json";
            Path= "C:\\\\";
            Date = DateTime.Now;
            Points = "2,3|1,5";
        }
    }
}
