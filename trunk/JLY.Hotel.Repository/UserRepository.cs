using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using JLY.Hotel.Model.Entities;
using JLY.Hotel.Model.Repositories;
using JLY.Hotel.Repository.DB;

namespace JLY.Hotel.Repository
{
    public class UserRepository : BaseRepository, IUserRepository 
    {

        public UserRepository(DbContext context) : base(context)
        {

        }

        public IUser GetUserById(int id)
        {
            return Single<User>(c => c.Id == id, c=> c.Rols);
        }

        public IUser GetUserByName(string name)
        {
            return Single<User>(c => c.Name == name);
        }

        public IUser GetUserByNamePassword(string name, string password)
        {
            return SingleOrDefault<User>(c => c.Name == name && c.Password == password);
        }
    }
}
