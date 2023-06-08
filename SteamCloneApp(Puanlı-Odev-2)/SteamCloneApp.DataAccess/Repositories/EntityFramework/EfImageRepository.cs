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
        private readonly SteamCloneContext _context;
        public EfImageRepository(SteamCloneContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddRange(IEnumerable<Image> images)
        {
            await _context.Images.AddRangeAsync(images);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<Image> images)
        {
            _context.RemoveRange(images);
            await _context.SaveChangesAsync();
        }
    }
}
