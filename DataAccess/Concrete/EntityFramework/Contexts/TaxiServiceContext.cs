using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class TaxiServiceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=213.238.168.71;Database=InnsbruckTaxi;user id=innsbruck_;password=efbhtlad123$;MultipleActiveResultSets=True;");
           // optionsBuilder.UseSqlServer(@"Server=.\MSSQLSERVER2017;Database=InnsbruckTaxi;user id=innsbruck_;password=efbhtlad123$;MultipleActiveResultSets=True;");

        }


        public DbSet<Resort> Resort { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<BookingInfo> BookingInfo { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
    }
}
