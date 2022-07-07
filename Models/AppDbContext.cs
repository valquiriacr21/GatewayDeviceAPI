using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayDeviceAPI.Models
{
    public class AppDbContext:DbContext
    {
        public static string RouteMapConnection = "Server=(localdb)\\MSSQLLocalDB;Database=GatewayDeviceAPI;Trusted_Connection=True;MultipleActiveResultSets=True;";
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Gateway> Gateways { get; set; }
        public DbSet<Device> Devices { get; set; }
    }
}
