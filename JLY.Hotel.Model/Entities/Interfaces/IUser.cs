using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JLY.Hotel.Model.Entities
{
    public interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
        string Password { get; set; }
        IList<Rol> Rols { get; set; } 
    }
}
