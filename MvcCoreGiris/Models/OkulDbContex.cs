using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreGiris.Models
{
    public class OkulDbContex : DbContext
    {
        public OkulDbContex(DbContextOptions<OkulDbContex> options) : base (options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=.; database=OkulContex; Integrated Security = true;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kisi>().HasData(
                new Kisi {Id = 1, KisiAd = "Burak" },
                new Kisi {Id = 2, KisiAd = "Osman" },
                new Kisi {Id = 3, KisiAd = "Büşra" }
                );
        }
        public DbSet<Kisi> Kisiler { get; set; }
    }
}
