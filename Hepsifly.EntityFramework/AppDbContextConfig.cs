using Hepsifly.Core;
using Hepsifly.EntityFramework.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsifly.EntityFramework
{
    public partial class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableDetailedErrors();


                //.UseSqlServer(Settings.Database.ConnectionString);
                //optionsBuilder.UseLazyLoadingProxies();

            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            MapperCategory.Initialize(builder);
        }
    }
}
