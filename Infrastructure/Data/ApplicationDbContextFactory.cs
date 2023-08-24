//using System.Data.Entity;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;
//using System;

//namespace Infrastructure.Data
//{
//    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
//    {
//        public ApplicationDbContext CreateDbContext(string[] args)
//        {
//            var context = new DesignTimeDbContextBuilder<ApplicationDbContext>()
//                .CreateDbContext(args);

//            return context;
//        }
//    }

//    public class DesignTimeDbContextBuilder<TContext> where TContext : DbContext
//    {
//        public TContext CreateDbContext(string[] args)
//        {
//            var configuration = new ConfigurationBuilder()
//                .AddConfiguration().SetBasePath(Directory.GetCurrentDirectory())
//     .AddJsonFile("appsettings.json")Ico
//     .Build();


//            string connectionString = configuration.GetConnectionString("OracleConnection");

//            if (string.IsNullOrEmpty(connectionString))
//            {
//                connectionString = configuration.GetConnectionString("SQLConnection");
//            }

//            if (connectionString.Contains("Data Source="))
//            {
//                builder.UseOracle(connectionString, options => options.UseOracleSQLCompatibility("11"));
//            }
//            else if (connectionString.Contains("Server="))
//            {
//                builder.UseSqlServer(connectionString);
//            }

//            return (TContext)Activator.CreateInstance(typeof(TContext), builder.Options);
//        }
//    }
//}