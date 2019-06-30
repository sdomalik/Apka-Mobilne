using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace SaveCatch.Models.Sqlite
{
    public class Fish : ISqliteModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Species { get; set; }
        public int Weight { get; set; }
        public int Length { get; set; }
        public int CatchID { get; set; }
    }
}
