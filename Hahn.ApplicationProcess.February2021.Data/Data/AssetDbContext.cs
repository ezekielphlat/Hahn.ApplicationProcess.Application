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
        public AssetDbContext(DbContextOptions<AssetDbContext> options) : base(options)
        {

        }

        public DbSet<Asset> Assets { get; set; }

        public void LoadDummyAssets()
        {
            Asset asset = new Asset() { ID = 1, AssetName = "My AssetName", Department = "HQ" };
            Assets.Add(asset);
        }
        public List<Asset> GetAssets()
        {
            return Assets.Local.ToList<Asset>();
        }
    }
}
