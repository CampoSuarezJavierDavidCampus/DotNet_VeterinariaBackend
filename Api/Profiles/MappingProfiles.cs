using AutoMapper;
using Core.Entities;
using Models.Dtos;

namespace Api.Profiles;
public class MappingProfiles: Profile{
    public MappingProfiles(){
        CreateMap<ProductCategory,ProductCategoryDto>().ReverseMap();
        CreateMap<Product,ProductDto>().ReverseMap();
        CreateMap<Role,RoleDto>().ReverseMap();
        CreateMap<User,UserDto>().ReverseMap();
    }
}
