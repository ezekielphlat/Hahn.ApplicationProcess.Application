using Hahn.ApplicationProcess.February2021.Data.Data;
using Hahn.ApplicationProcess.February2021.Data.Models;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using Hahn.ApplicationProcess.February2021.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Repository
{
    public class AssetRepository : RepositoryBase, IAssetRepository
    {

        public async Task DeleteAsync(int Id)
        {
            using (AssetDbContext context = new AssetDbContext())
            {
                var entity = await context.Asset.FirstOrDefaultAsync(p => p.ID == Id);
                if (entity != null)
                {
                    context.Asset.Remove(entity);

                }
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Update Profile Error: {ex}");
                }
            }
        }

        public async Task<List<AssetViewModel>> FindAllAsync()
        {
            return await db.Asset.Select(d => new AssetViewModel
            {
                Id = d.ID,
                Name = d.AssetName,
                Department =  (Department)Enum.Parse(typeof(Department), d.Department),
                DepartmentString =  d.Department,
                Country = d.CountryOfDepartment,
                Email = d.EmailAddressOfDepartment,
                Date = d.PurchaseDate,
                DateString = d.PurchaseDate.ToString("MM-dd-yy"),
                isBroken = d.Broken
            }).ToListAsync();
        }

        public async Task<AssetViewModel> FindByIdAsync(int Id)
        {
            return await db.Asset.Where(i => i.ID == Id)
                .Select(a => new AssetViewModel
                {
                    Id = a.ID,
                    Name = a.AssetName,
                    Department = (Department)Enum.Parse(typeof(Department), a.Department),
                    DepartmentString = Enum.GetName(typeof(Department), a.Department),
                    Country = a.CountryOfDepartment,
                    Email = a.EmailAddressOfDepartment,
                    Date = a.PurchaseDate,
                    isBroken = a.Broken
                }).FirstOrDefaultAsync();
        }

        public async Task<bool> IsCountryValid(string country)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://restcountries.eu/rest/v2/name/")
            };
            var result = await httpClient.GetAsync($"{country}?fullText=true");
            //TODO: Revisit this method. to know why i could not manipulate responses
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task SaveAsync(AssetViewModel model)
        {
            using (var context = new AssetDbContext())
            {
                var newAsset = new Asset
                {
                    AssetName = model.Name,
                    Department = model.Department.ToString(),
                    CountryOfDepartment = model.Country,
                    EmailAddressOfDepartment = model.Email,
                    PurchaseDate = model.Date,
                    Broken = model.isBroken
                };
                if (model.Name.Any())
                {
                    context.Asset.Add(newAsset);
                    try
                    {
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Implement logs here: {ex}");
                    }
                }
            }
        }

        public async Task UpdateAsync(int Id, AssetViewModel model)
        {
            using (AssetDbContext context = new AssetDbContext())
            {
                var entity = await context.Asset.FirstOrDefaultAsync(p => p.ID == Id);
                if (entity != null)
                {
                    entity.AssetName = model.Name;
                    entity.Department = model.Department.ToString();
                    entity.CountryOfDepartment = model.Country;
                    entity.EmailAddressOfDepartment = model.Email;
                    entity.PurchaseDate = model.Date;
                    entity.Broken = model.isBroken;
                }
                context.Asset.Update(entity);
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Update Profile Error: {ex}");
                }
            }
        }
    }
}
