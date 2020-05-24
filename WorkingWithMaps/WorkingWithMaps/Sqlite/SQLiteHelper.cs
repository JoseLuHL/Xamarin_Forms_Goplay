using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using WSGOPLAY.Models.red;

namespace XamarinSQLite
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Usuario>().Wait();
        }

        //Insert and Update new record
        public Task<int> SaveItemAsync(Usuario person)
        {
            if (person.Id != 0)
            {
                return db.UpdateAsync(person);
            }
            else
            {
                return db.InsertAsync(person);
            }
        }

        //Delete
        public Task<int> DeleteItemAsync()
        {
            return db.DeleteAllAsync<Usuario>();
        }

        //Read All Items
        public  Task<List<Usuario>> GetItemsAsync()
        {
            return  db.Table<Usuario>().ToListAsync();
        }


        //Read Item
        public Task<Usuario> GetItemAsync(int personId)
        {
            return db.Table<Usuario>().Where(i => i.Id == personId).FirstOrDefaultAsync();
        }
    }
}
