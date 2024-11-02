using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularCOMP584.Server.Models2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataModel
{
    public partial class DataBaseWrapperContext : DbContext
    {
        public DataBaseWrapperContext()
        {
        }

        public DataBaseWrapperContext(DbContextOptions<DataBaseWrapperContext> options)
            : base(options)
        {
        }

        // DbSet for Games
        public virtual DbSet<GameConsole> gameConsoleDBSet { get; set; }

        // DbSet for Genres
        //public virtual DbSet<Companies> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {



            if (optionsBuilder.IsConfigured)
            {
                return;
            }
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false);

            IConfigurationRoot configuration = builder.Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<GameConsole> testMyDBContext()
        {
     
           GameConsole g2 = await gameConsoleDBSet.FindAsync(1);

           List<GameConsole> temp = await gameConsoleDBSet.ToListAsync();

           return g2;
        }

    }
}
