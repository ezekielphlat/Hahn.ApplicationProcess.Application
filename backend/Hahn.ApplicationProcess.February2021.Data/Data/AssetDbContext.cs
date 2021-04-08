using Hahn.ApplicationProcess.February2021.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Hahn.ApplicationProcess.February2021.Data.Data
{
    public class AssetDbContext : DbContext
    {
        public AssetDbContext()
        {

        } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()                   
                   .Build();
                optionsBuilder.UseInMemoryDatabase("AssetDatabase");
            }
        }

        public DbSet<Asset> Asset { get; set; }
        
    }
}
