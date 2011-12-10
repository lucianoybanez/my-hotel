using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JLY.Hotel.Model.Entities
{
    public interface IRol
    {
        int Id { get; set; }
        string Descrition { get; set; }
        IList<User> Users { get; set; }
    }
}
