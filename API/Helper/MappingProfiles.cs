using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Entities.OrderAggregate;

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


            CreateMap<Core.Entities.Identity.Address, AddressDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemsDto, BasketItems>();
            CreateMap<AddressDto, Core.Entities.OrderAggregate.Address>();

            CreateMap<Order, OrderToReturnDto>()
            .ForMember(d => d.DeliveryMethod, o => o.MapFrom(src => src.DeliveryMethod.ShortName))
            .ForMember(d => d.ShippingPrice, o => o.MapFrom(src => src.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDto>()
             .ForMember(d => d.ProductId, o => o.MapFrom(src => src.ItemOrdered.ProductItemId))
             .ForMember(d => d.ProductName, o => o.MapFrom(src => src.ItemOrdered.ProductName))
             //  .ForMember(d => d.PictureUrl, o => o.MapFrom(src => src.ItemOrdered.PictureUrl))
             .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());

        }
    }
}