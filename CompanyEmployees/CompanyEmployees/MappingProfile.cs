using AutoMapper;
using CompanyEmployees.Core.Domain.Entities;
using Share.DataTransferObjects;

namespace CompanyEmployees
{
    public class MappingProfile : Profile
    {
       public MappingProfile() { 
            CreateMap<Company, CompanyDto>()
                .ForCtorParam("FullAddress",
                    opt => opt.MapFrom(x => $"{x.Address}  {x.Country}"));
       }
    }
}
