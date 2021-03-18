using Azure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PetHazardsHKAPI.Data;
using PetHazardsHKAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetHazardsHKAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PetHazardsHKAPI", Version = "v1" });
            });

            
            //services.AddTransient<IDbAuthTokenService, AzureSqlAuthTokenService>();
            //services.AddDbContext<HazardContext>();
            /*
            var connectionString = Configuration.GetConnectionString("HazardContext");
            var connection = (SqlConnection)Database.GetDbConnection();
            connection.AccessToken = (new Microsoft.Azure.Services.AppAuthentication.AzureServiceTokenProvider()).GetAccessTokenAsync("https://database.windows.net/").Result;

            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = Configuration.GetConnectionString("HazardContext");
            sqlConn.AccessToken = 

            
            services.AddTransient(a =>
            {
                var sqlConnection = new SqlConnection(connectionString);
                var credential = new DefaultAzureCredential();
                var token = credential.GetToken(new Azure.Core.TokenRequestContext(new[] { "https://database.windows.net/,default" }));
                sqlConnection.AccessToken = token.Token;
                return sqlConnection;

            });
            

            services.AddDbContext<HazardContext>(a =>
            {
                var sqlConnection = new SqlConnection(connectionString);
                var credential = new DefaultAzureCredential();
                var token = credential.GetToken(new Azure.Core.TokenRequestContext(new[] { "https://database.windows.net/,default" }));
                sqlConnection.AccessToken = token.Token;
                return sqlConnection;

            });*/

            services.AddDbContext<HazardContext>(options => options.UseSqlServer(Configuration.GetConnectionString("HazardContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PetHazardsHKAPI v1"));

        }
    }
}
