using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SaveCatch.Models.Sqlite
{
    public class Catch : ISqliteModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }

    }
}
