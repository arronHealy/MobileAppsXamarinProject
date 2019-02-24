using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace MobileAppsDev2_XamarinProject
{
    public class NoteDB
    {
        //SQLite connection variable
        readonly SQLiteAsyncConnection database;

        //constructor sets database connection
        public NoteDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Note>().Wait();
        }

        //return notes database as list
        public Task<List<Note>> GetNotesList()
        {
            return database.Table<Note>().ToListAsync();
        }

        //save or update note to database 
        public Task<int> SaveNote(Note n)
        {
            if (n.id != 0)
            {
                return database.UpdateAsync(n);
            }
            else
            {
                return database.InsertAsync(n);
            }
        }

        //delete note from database
        public Task<int> DeleteNote(Note n)
        {
            return database.DeleteAsync(n);
        }
    }
}
