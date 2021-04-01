using Hahn.ApplicationProcess.February2021.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicationProcess.February2021.Domain.Repository
{
    public abstract class RepositoryBase
    {
        protected AssetDbContext db = new AssetDbContext();
    }
}
