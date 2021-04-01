using Hahn.ApplicationProcess.February2021.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Interfaces
{
    public interface IAssetRepository
    {
        Task<List<AssetViewModel>> FindAllAsync();
        Task SaveAsync(AssetViewModel model);
        Task UpdateAsync(AssetViewModel model);
        Task DeleteAsync(int Id);
    }
}
