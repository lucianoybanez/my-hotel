using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JLY.Hotel.Model.Entities;

namespace JLY.Hotel.Model.Repositories
{
    public interface IUserRepository
    {
        IUser GetUserById(int id);
        IUser GetUserByName(string name);
        IUser GetUserByNamePassword(string name, string password);
    }
}
