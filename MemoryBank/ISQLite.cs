using System;
using SQLite;
namespace MemoryBank
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
