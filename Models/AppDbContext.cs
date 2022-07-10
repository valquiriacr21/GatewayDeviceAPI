using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GatewayDeviceAPI.Models
{
    public class AppDbContext:DbContext
    {
        public static string RouteMapConnection = "Server=(localdb)\\MSSQLLocalDB;Database=GatewayDeviceAPI;Trusted_Connection=True;MultipleActiveResultSets=True;";
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<Gateway>()
            //   .Property(t => t.SerialNumber)
            //   .HasValueGenerator<IdValueGenerator>();


            //Marca de tiempo de creación
            builder.Entity<Device>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getdate()");

            //builder.Entity<Gateway>()
            //    .Property(p => p.SerialNumber)
            //    .HasComputedColumnSql("[Name] + ', ' + [IPV4]+','+getdate()");
        }
        


        public DbSet<Gateway> Gateways { get; set; }
        public DbSet<Device> Devices { get; set; }
    }

    //public class IdValueGenerator /*: ValueGenerator<string>*/
    //{
    //    public bool GeneratesTemporaryValues => false;

    //    public string Next(EntityEntry entry)
    //    {
    //        if (entry == null)
    //        {
    //            throw new ArgumentNullException(nameof(entry));
    //        }
    //        var context = (AppDbContext)entry.Context;
    //        var id = context.Gateways.LastOrDefault()?.SerialNumber == null ?
    //                "A001"
    //                : Regex.Replace(context.Gateways.LastOrDefault()?.SerialNumber, 
    //                "\\d+", m => (int.Parse(m.Value) + 1).ToString(new string('0', m.Value.Length)));

    //        return id;
    //    }
    //}
}
