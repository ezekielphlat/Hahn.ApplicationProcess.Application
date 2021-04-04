using Hahn.ApplicationProcess.February2021.Data.Data;

namespace Hahn.ApplicationProcess.February2021.Domain.Repository
{
    public abstract class RepositoryBase
    {
        protected AssetDbContext db = new AssetDbContext();
    }
}
