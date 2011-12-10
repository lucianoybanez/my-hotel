using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using JLY.Hotel.Model.Entities;

namespace JLY.Hotel.Repository.DB
{
    public class HotelDB : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Rols { get; set; }
    }
}
