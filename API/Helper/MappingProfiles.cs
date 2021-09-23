using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
            .ForMember(d => d.PictureUrl, opt => opt.MapFrom<ProductUrlResolver>())
            .ForMember(src => src.ProductType, opt => opt.MapFrom(t => t.ProductType.Name))
            .ForMember(src => src.ProductBrand, opt => opt.MapFrom(t => t.ProductBrand.Name));


            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemsDto, BasketItems>();

        }
    }
}