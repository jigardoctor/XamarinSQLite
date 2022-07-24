using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace XamarinSQLite
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int PersonID { get; set; }
        public DateTime Date { get; set; }
        public string Shift { get; set; }
        public string Name { get; set; }
        public string DesignNo { get; set; }
        public string Machine { get; set; }
        public int Stiches { get; set; }
        public int Frame { get; set; }
        public int Tb { get; set; }
        public double Hajri { get; set; }
        public int Pagar { get; set; }
        public int Bonus { get; set; }
        public int Total { get; set; }
        public string Remark { get; set; }
    }
}
