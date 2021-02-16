using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelFinder.DataAccess
{
    public class HotelDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseNpgsql("server=LAPTOP-DMFSLP7H\\SQLEXPRESS;Initial Catalog=HotelDb;Integrated Security=SSPI");
            optionsBuilder.UseNpgsql("Server=localhost;Port=5436;Database=Hoteldb;UserName=postgres;Password=123456");
            

        }
        public DbSet<Hotel> Hotels { get; set; }

    }
}
