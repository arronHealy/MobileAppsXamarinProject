using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppsDev2_XamarinProject
{
    public class ContactDB
    {
        //SQLite database connection variable
        readonly SQLiteAsyncConnection database;

        //constructor sets database connection
        public ContactDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Contact>().Wait();
        }

        //return database contacts as list 
        public Task<List<Contact>> GetContactsList()
        {
            return database.Table<Contact>().ToListAsync();
        }

        //save or update contact to database
        public Task<int> SaveContact(Contact c)
        {
            if (c.id != 0)
            {
                return database.UpdateAsync(c);
            }
            else
            {
                return database.InsertAsync(c);
            }
        }

        //delete contact from database
        public Task<int> DeleteContact(Contact c)
        {
            return database.DeleteAsync(c);
        }
    }
}
