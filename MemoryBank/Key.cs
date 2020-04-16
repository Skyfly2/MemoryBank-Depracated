using System;
using SQLite;
namespace MemoryBank
{
    public class Key
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string key { get; set; }
        public string iv { get; set; }
    }
}
