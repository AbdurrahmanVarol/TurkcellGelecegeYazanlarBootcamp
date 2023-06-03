using SteamCloneApp.DataAccess.Repositories.EntityFramework.Contexts;
using SteamCloneApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.DataAccess.Repositories.EntityFramework
{
    public class EfImageRepository : EfEntityRepositoryBase<Image, SteamCloneContext>, IImageRepository
    {
        public EfImageRepository(SteamCloneContext context) : base(context)
        {
        }
    }
}
