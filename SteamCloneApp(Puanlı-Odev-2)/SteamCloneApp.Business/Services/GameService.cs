﻿using SteamCloneApp.Business.Dtos.Requests;
using SteamCloneApp.Business.Dtos.Responses;
using SteamCloneApp.DataAccess.Repositories;
using SteamCloneApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SteamCloneApp.Business.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IImageRepository _imageRepository;
        public GameService(IGameRepository gameRepository, IGenreRepository genreRepository, IImageRepository imageRepository)
        {
            _gameRepository = gameRepository;
            _genreRepository = genreRepository;
            _imageRepository = imageRepository;
        }

        public async Task AddAsync(CreateGameRequest request)
        {
            var genres = await _genreRepository.GetAllAsync(x => request.Genres.Contains(x.Id));
            var game = new Game
            {
                Description = request.Description,
                DevelopedById = request.DevelopedById,
                PublishedById = request.PublishedById,
                ReleaseAt = request.ReleaseAt,
                CoverUrl = request.CoverUrl,
                IconUrl = request.IconUrl,
                Title = request.Title,
                Price = request.Price,
                Genres = genres
            };
            await _gameRepository.AddAsync(game);
            foreach (var imageUrl in request.ImageUrls)
            {
                await _imageRepository.AddAsync(new Image
                {
                    GameId = game.Id,
                    ImageUrl = imageUrl,
                });
            }
        }

        public async Task<List<GameDisplayResponse>> GetAllAsync()
        {
            var games = await _gameRepository.GetAllAsync();

            return games.Select(p => new GameDisplayResponse
            {
                Id = p.Id,
                Description = p.Description,
                Title = p.Title,
                Price = p.Price,
                ReleaseAt = p.ReleaseAt,
                DeveloperName = p.DevelopedBy.Name,
                PublisherName = p.PublishedBy.Name,
                CoverUrl = p.CoverUrl,
                IconUrl = p.IconUrl,
                Genres = p.Genres.Select(p => p.Name).ToList(),
                Images = p.Images.Select(p => p.ImageUrl).ToList()
            }).OrderByDescending(p => p.ReleaseAt).ToList();
        }
        public async Task<List<GameDisplayResponse>> GetGamesByUserIdAsync(Guid userId)
        {

            var games = await _gameRepository.GetAllAsync(g => g.Users.Any(u => u.Id == userId));

            return games.Select(p => new GameDisplayResponse
            {
                Id = p.Id,
                Description = p.Description,
                Title = p.Title,
                Price = p.Price,
                ReleaseAt = p.ReleaseAt,
                DeveloperName = p.DevelopedBy.Name,
                PublisherName = p.PublishedBy.Name,
                CoverUrl = p.CoverUrl,
                IconUrl = p.IconUrl,
                Genres = p.Genres.Select(p => p.Name).ToList(),
                Images = p.Images.Select(p => p.ImageUrl).ToList()
            }).ToList();
        }
        public async Task<GameDisplayResponse> GetGameByIdAsync(Guid id)
        {
            var game = await _gameRepository.GetAsync(p => p.Id == id);
            if (game is null)
            {
                throw new ArgumentNullException("---------");
            }
            var response = new GameDisplayResponse
            {
                Id = game.Id,
                Description = game.Description,
                Title = game.Title,
                Price = game.Price,
                IconUrl = game.IconUrl,
                CoverUrl = game.CoverUrl,
                ReleaseAt = game.ReleaseAt,
                DeveloperName = game.DevelopedBy.Name,
                PublisherName = game.PublishedBy.Name,
                Genres = game.Genres.Select(p => p.Name).ToList(),
                Images = game.Images.Select(p => p.ImageUrl).ToList(),
                Reviews = game.Reviews.Select(p => new ReviewResponse
                {
                    Id = p.Id,
                    GameId = p.GameId,
                    IsRecommend = p.IsRecommend,
                    Post = p.Post,
                    PostedAt = p.PostedAt,
                    UserId = p.UserId
                }).ToList()
            };
            return response;
        }

        public async Task<GameCartResponse> GetGameByIdForCartAsync(Guid id)
        {
            var game = await _gameRepository.GetAsync(p => p.Id == id);
            if (game is null)
            {
                throw new ArgumentNullException("---------");
            }
            var response = new GameCartResponse
            {
                Id = game.Id,
                Title = game.Title,
                Price = game.Price,
                CoverUrl = game.CoverUrl
            };
            return response;
        }
    }
}
