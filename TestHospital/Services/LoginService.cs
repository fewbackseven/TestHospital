using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace TestHospital.Services
{
    public class LoginService
    {
        SQLiteAsyncConnection db;
        async Task init()
        {
            if (db != null)
                return;
            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<User>();
        }

        public async Task AddUser(string name, string Email, string Phone)
        {
            await init();
            var User = new User()
            {
                FullName = name,
                EmailID = Email,
                PhoneNumber = Phone
            };

            var id = await db.InsertAsync(User);
        }

        public async Task<User> GetUser(int id)
        {
            await init();
            var user = await db.Table<User>()
              .FirstOrDefaultAsync(c => c.Id == id);

            return user;
        }
        
        public async Task<IEnumerable<User>> GetAllUser()
        {
            await init();
            var user = await db.Table<User>().ToListAsync();
            return user;
        }
    }

    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmailID { get; set; }
        public string PhoneNumber { get; set; }
    }


}
