using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularCOMP584.Server.Models2;
using DataModel.Models2;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataModel
{
    public partial class DataBaseWrapperContext : IdentityDbContext<AppUser> 
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

        // DbSet for Companies
        public virtual DbSet<GameCompanies> gameCompaniesDBSet { get; set; }

        public virtual DbSet<VideoGames> videoGamesDBSet { get; set; }

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

        public async Task<GameCompanies> testDBContext()
        {

            GameCompanies g1 = await gameCompaniesDBSet.FindAsync(1);

            List<GameConsole> temp = await gameConsoleDBSet.ToListAsync();

            return g1;
        }

        public async Task<VideoGames> TestTheDBContext()
        {

            VideoGames g3 = await videoGamesDBSet.FindAsync(1);

            List<GameConsole> temp = await gameConsoleDBSet.ToListAsync();

            return g3;
        }

    }
}
