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
        public string Name { get; set; }
        public string Path { get; set; }
        public DateTime Date { get; set; }
        public string Points { get; set; }
        public PointFile()
        {
        }
    }
}
