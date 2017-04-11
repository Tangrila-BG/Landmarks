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
                cfg.CreateMap<RegisterViewModel, ApplicationUser>()
                    .ForMember(u => u.UserName, map => map.MapFrom(vm => vm.UserName))
                    .ForMember(u => u.FirstName, map => map.MapFrom(vm => vm.FirstName))
                    .ForMember(u => u.LastName, map => map.MapFrom(vm => vm.LastName))
                    .ForMember(u => u.Email, map => map.MapFrom(vm => vm.Email));

                cfg.CreateMap<ApplicationUser, RegisterViewModel>();
                cfg.CreateMap<ApplicationUser, LoginViewModel>();
                cfg.CreateMap<LoginViewModel, ApplicationUser>();
            });
        }
    }
}