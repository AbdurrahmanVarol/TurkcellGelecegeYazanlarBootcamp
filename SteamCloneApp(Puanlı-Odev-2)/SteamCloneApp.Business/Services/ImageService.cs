using Azure.Core;
using SteamCloneApp.DataAccess.Repositories;
using SteamCloneApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.Business.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task AddRange(IEnumerable<string> images, Guid gameId)
        {
            var addedImages = images.Select(p => new Image
            {
                GameId = gameId,
                ImageUrl = p,
            });
            await _imageRepository.AddRange(addedImages);
        }

        public async Task<IEnumerable<string>> GetImageUrlsBtGameIdAsync(Guid gameId)
        {
            return (await _imageRepository.GetAllAsync(p=>p.GameId == gameId)).Select(x => x.ImageUrl);
        }

        public async Task RemoveRange(IEnumerable<Image> images)
        {
            await _imageRepository.RemoveRange(images);
        }
    }
}
