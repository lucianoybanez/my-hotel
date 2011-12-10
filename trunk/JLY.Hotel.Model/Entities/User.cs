using System.Collections.Generic;

namespace JLY.Hotel.Model.Entities
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Rol> Rols { get; set; }
    }
}