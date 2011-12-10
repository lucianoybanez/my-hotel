using System.Collections.Generic;

namespace JLY.Hotel.Model.Entities
{
    public class Rol : IRol
    {
        public int Id { get; set; }
        public string Descrition { get; set; }
        public IList<User> Users { get; set; }
       
    }
}