using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SaveCatch.Models.Sqlite;
using System.Threading.Tasks;

namespace SaveCatch.Data
{
    class LocalDB
    {
        readonly SQLiteAsyncConnection database;

        public LocalDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Catch>().Wait();
            database.CreateTableAsync<Fish>().Wait();
        }

        private async void Init()
        {
            await database.CreateTableAsync<Catch>();
            await database.CreateTableAsync<Fish>();

        }
        public async Task<int> SaveItemAsync<T>(T item)
        {
            var result = await database.UpdateAsync(item);

            if (result == 0)
                result = await database.InsertAsync(item);

            return result;
        }

        public async Task<int> DeleteItemAsync<T>(T item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<List<Fish>> GetFishes(int catchID)
        {
            return await database.Table<Fish>().Where(x => x.CatchID == catchID).ToListAsync();
        }

        internal async Task<List<T>> GetItems<T>() where T : class, new()
        {
            return await database.Table<T>().ToListAsync();

        }
    }
}
