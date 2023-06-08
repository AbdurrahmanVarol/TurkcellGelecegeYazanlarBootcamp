using AutoMapper;
using SteamCloneApp.Business.Dtos.Requests;
using SteamCloneApp.Business.Dtos.Responses;
using SteamCloneApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.Business.Mapping.AutoMapper
{
    public class DefaultMapper : Profile
    {
        public DefaultMapper()
        {
            CreateMap<User,UserResponse>()
                .ForMember(p=>p.Roles,q=>q.MapFrom(r=>r.Roles.Select(role=>role.Name)));

            CreateMap<GenreResponse, Genre>().ReverseMap();

            CreateMap<PublisherResponse, Publisher>().ReverseMap();

            CreateMap<DeveloperResponse, Developer>().ReverseMap();

            CreateMap<ReviewResponse, Review>().ReverseMap()
                .ForMember(p=>p.UserName,q=>q.MapFrom(r=>r.User.NickName));

            CreateMap<Game, GameDisplayResponse>()
                .ForMember(g => g.Reviews, r => r.MapFrom(p => p.Reviews))
                .ForMember(g => g.PublishedById, r => r.MapFrom(p => p.PublishedBy.Id))
                .ForMember(g => g.PublisherName, r => r.MapFrom(p => p.PublishedBy.Name))
                .ForMember(g => g.DevelopedById, r => r.MapFrom(p => p.DevelopedBy.Id))
                .ForMember(g => g.DeveloperName, r => r.MapFrom(p => p.DevelopedBy.Name))
                .ForMember(g => g.Genres, r => r.MapFrom(p => p.Genres.Select(q=>q.Name).ToList()))
                .ForMember(g => g.Images, r => r.MapFrom(p => p.Images.Select(q=>q.ImageUrl).ToList()))
                .ForMember(g => g.ReleaseAt, r => r.MapFrom(p => DateTime.Parse(p.ReleaseAt.ToString("dd/MM/yyy"))));

            CreateMap<Game, GameCartResponse>();

            CreateMap<CreateGameRequest, Game>();

            CreateMap<CreateReviewRequest, Review>();

            CreateMap<Game,UpdateGameRequest>()
                 .ForMember(g => g.Genres, r => r.MapFrom(p => p.Genres.Select(q => q.Name).ToList()))
                .ForMember(g => g.ImageUrls, r => r.MapFrom(p => p.Images.Select(q => q.ImageUrl).ToList()))
                .ReverseMap();
            


        }
    }
}
