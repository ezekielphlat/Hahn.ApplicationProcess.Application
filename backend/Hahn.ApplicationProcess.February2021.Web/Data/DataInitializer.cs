using Hahn.ApplicationProcess.February2021.Domain;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using Hahn.ApplicationProcess.February2021.Domain.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Web.Data
{
    public class DataInitializer
    {       
        public static void  SeedData(IAssetRepository asset)
        {
            SeedAsset(asset);
        }
        public static void SeedAsset(IAssetRepository asset)
        {
            if(!asset.FindAllAsync().Result.Any())
            {
                AssetViewModel newAsset = new AssetViewModel()
                {
                    Name = "Laptop",
                    Department = (Department)1,
                    Country = "Nigeria",
                    Email = "hq@hahn.com",
                    Date = DateTime.Now,
                };
                try
                {
                    asset.SaveAsync(newAsset);
                }catch(Exception ex)
                {
                    Console.WriteLine($"Unable to seed data: {ex}");
                }
            }
        }
    }
}
