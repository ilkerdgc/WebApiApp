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
            optionsBuilder.UseSqlServer("server=LAPTOP-DMFSLP7H\\SQLEXPRESS;Initial Catalog=HotelDb;Integrated Security=SSPI");

        }
        public DbSet<Hotel> Hotels { get; set; }

    }
}
