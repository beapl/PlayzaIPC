using SQLite;
using Playza.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace Playza.Services
{
    public class UserDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public UserDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        public Task<List<User>> GetUsersAsync() =>
            _database.Table<User>().ToListAsync();

        public Task<User> GetUserByUsernameAsync(string username) =>
            _database.Table<User>().FirstOrDefaultAsync(u => u.Username == username);

        public Task<int> SaveUserAsync(User user) =>
            _database.InsertAsync(user);

        public Task<int> DeleteUserAsync(User user) =>
            _database.DeleteAsync(user);
    }
}

