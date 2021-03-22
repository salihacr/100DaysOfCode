using AdvancedIdentity.Entities;
using AdvancedIdentity.Models.Accounts;
using AutoMapper;

namespace AdvancedIdentity.Helpers
{
    public class AutoMapperProfile : Profile
    {
        // mappings between model and entity objects
        public AutoMapperProfile()
        {
            CreateMap<Account, AccountResponse>().ReverseMap();
            CreateMap<Account, AuthenticateResponse>().ReverseMap();
            CreateMap<RegisterRequest, Account>().ReverseMap();
            CreateMap<CreateRequest, Account>().ReverseMap();

            CreateMap<UpdateRequest, Account>()
                .ForAllMembers(x => x.Condition((src, dest, prop) =>
                {
                    // ignore null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;
                    // ignore null role
                    if (x.DestinationMember.Name == "Role" && src.Role == null) return false;
                    return true;
                }));
        }
    }
}
