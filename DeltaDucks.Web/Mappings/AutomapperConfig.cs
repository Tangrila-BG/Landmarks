using AutoMapper;
using DeltaDucks.Models;
using DeltaDucks.Web.ViewModels;

namespace DeltaDucks.Web.Mappings
{
    public class AutomapperConfig
    {
        public static void Config()
        {
            // TODO : Add more mappings
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RegisterViewModel, User>()
                .ForMember(u => u.Username, map => map.MapFrom(vm => vm.Username))
                .ForMember(u => u.FirstName, map => map.MapFrom(vm => vm.FirstName))
                .ForMember(u => u.LastName, map => map.MapFrom(vm => vm.LastName))
                .ForMember(u => u.Email, map => map.MapFrom(vm => vm.Email))
                .ForMember(u => u.Password, map => map.MapFrom(vm => vm.Password)); ;
                cfg.CreateMap<User, RegisterViewModel>();
                cfg.CreateMap<User, LoginViewModel>();
                cfg.CreateMap<LoginViewModel, User>();
            });
        }
    }
}