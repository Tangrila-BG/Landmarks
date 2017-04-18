using AutoMapper;
using DeltaDucks.Models;
using DeltaDucks.Web.Areas.Admin.ViewModels;
using DeltaDucks.Web.Dtos;
using DeltaDucks.Web.ViewModels;
using DeltaDucks.Web.ViewModels.Account;

namespace DeltaDucks.Web
{
    public class AutomapperConfig
    {
        public static void Config()
        {
            // TODO : Add more mappings
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RegisterViewModel, ApplicationUser>()
                    .ForMember(u => u.UserName, map => map.MapFrom(vm => vm.UserName))
                    .ForMember(u => u.FirstName, map => map.MapFrom(vm => vm.FirstName))
                    .ForMember(u => u.LastName, map => map.MapFrom(vm => vm.LastName))
                    .ForMember(u => u.Email, map => map.MapFrom(vm => vm.Email));

                cfg.CreateMap<ApplicationUser, RegisterViewModel>();
                cfg.CreateMap<ApplicationUser, LoginViewModel>();
                cfg.CreateMap<LoginViewModel, ApplicationUser>();
                cfg.CreateMap<ResetPasswordViewModel, ApplicationUser>();
                cfg.CreateMap<Landmark, LandmarkViewModel>();
                cfg.CreateMap<LandmarkViewModel, Landmark>();

                cfg.CreateMap<ApplicationUser, VisitedLandmarksViewModel>();
                cfg.CreateMap<ApplicationUser, NotVisitedLandmarksViewModel>();

                cfg.CreateMap<ApplicationUser, UsersViewModel>();

                cfg.CreateMap<Landmark, LandmarkToMapDto>()
                    .ForMember(dest => dest.title,
                        opt => opt.MapFrom(src =>
                            "<a href=\"/Landmark/Details?number="+ src.Number+ "\">" + src.Name + "</a>"))
                    .ForMember(dest => dest.position,
                        opt => opt.MapFrom(src => src.Location));

                cfg.CreateMap<Location, LocationToMapDto>()
                    .ForMember(dest => dest.lat, opt => opt.MapFrom(src => src.Latitude))
                    .ForMember(dest => dest.lng, opt => opt.MapFrom(src => src.Longitude));

                cfg.CreateMap<CreateLandmarkViewModel, Landmark>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.Information, opt => opt.MapFrom(src => src.Information))
                    .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                    .ForMember(dest => dest.Points, opt => opt.MapFrom(src => src.Points));

                cfg.CreateMap<CreateLandmarkViewModel, Location>()
                    .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                    .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
                    .ForMember(dest => dest.Town, opt => opt.Ignore());

                cfg.CreateMap<ApplicationUser, UserRankingViewModel>();

                cfg.CreateMap<Comment, CommentViewModel>()
                    .ForMember(dest => dest.LandmarkNumber, opt => opt.MapFrom(src => src.Landmark.Number));
                cfg.CreateMap<CommentViewModel, Comment>();
                cfg.CreateMap<Landmark, UpdateLandmarksViewModel>()
                    .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.Information, opt => opt.MapFrom(src => src.Information))
                    .ForMember(dest => dest.Pictures, opt => opt.MapFrom(src => src.Pictures))
                    .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Location.Longitude))
                    .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Location.Latitude))
                    .ForMember(dest => dest.Town, opt => opt.MapFrom(src => src.Location.Town.Name));

                cfg.CreateMap<UpdateLandmarksViewModel, Location>()
                    .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                    .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
                    .ForMember(dest => dest.Town, opt => opt.Ignore());

                cfg.CreateMap<Landmark, NotificationLandmarkDto>();
                cfg.CreateMap<Notification,NotificationDto>();
            });
        }
    }
}