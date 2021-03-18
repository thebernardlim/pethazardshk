using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetHazardsHKAPI.Models;
using PetHazardsHKAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetHazardsHKAPI.Data
{
    public class HazardContext : DbContext
    {
        public HazardContext (DbContextOptions<HazardContext> options): base(options)
        {
            /*
            var connection = new SqlConnection();
            connection.ConnectionString = Configuration.GetConnectionString("HazardContext");
            connection.AccessToken = (new Microsoft.Azure.Services.AppAuthentication.AzureServiceTokenProvider()).GetAccessTokenAsync("https://database.windows.net/").Result;
            */
        }

        public IConfiguration Configuration { get; }
        public IDbAuthTokenService authTokenService { get; set; }

        /*
        public HazardContext(IConfiguration configuration, IDbAuthTokenService tokenService, DbContextOptions<HazardContext> options)
            : base(options)
        {
            Configuration = configuration;
            authTokenService = tokenService;
        }*/

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Configuration.GetConnectionString("HazardContext"); //"Server=tcp:pethazardshk.database.windows.net,1433;Database=pethazardshk;"; //Configuration.GetConnectionString("HazardContext");
            //connection.AccessToken = (new Microsoft.Azure.Services.AppAuthentication.AzureServiceTokenProvider()).GetAccessTokenAsync("https://database.windows.net/").Result;

            optionsBuilder.UseSqlServer(connection);
        }*/

        public DbSet<Reporting> Reporting { get; set; }
    }
}
