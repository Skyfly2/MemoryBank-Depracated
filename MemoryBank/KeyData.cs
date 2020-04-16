using System;
using System.Threading.Tasks;
using SQLite;

namespace MemoryBank
{
    public class KeyData
    {

        readonly SQLiteAsyncConnection db;

        public KeyData(string path)
        {
            db = new SQLiteAsyncConnection(path);
            db.CreateTableAsync<Key>().Wait();
        }

        public Task<Key> getKey(int id)
        {
            return db.Table<Key>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> addKey(Key key)
        {
            return db.InsertAsync(key);
        }
    }
}
