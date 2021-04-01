using Hahn.ApplicationProcess.February2021.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hahn.ApplicationProcess.February2021.Data.Data
{
    public class AssetDbContext : DbContext
    {
        public AssetDbContext()
        {

        }
        public AssetDbContext(DbContextOptions<AssetDbContext> options) : base(options)
        {

        }

        public DbSet<Asset> Asset { get; set; }
        
    }
}
