using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JLY.Hotel.Model.Entities
{
    public class User : IUser
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(20)] 
        public string Password { get; set; }
        public IList<Rol> Rols { get; set; }
    }
}