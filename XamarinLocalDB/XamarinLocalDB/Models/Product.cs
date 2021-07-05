using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinLocalDB.Models
{
    [Table("LogientProducts")]
    public class Product
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }

        [MaxLength(100), Unique]
        public string Name { get; set; }
        public int quantitie { get; set; } = 1;
    }
}
