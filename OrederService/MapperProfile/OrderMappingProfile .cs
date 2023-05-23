using AutoMapper;
using OrederService.Models;
using OrederService.Models.Entities;
using OrederService.Models.Enums;
using OrederService.Models.RequestModels;
using OrederService.Models.ResponeModes;

namespace OrederService.MapperProfile
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<OrderRequest, OrderModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => OrderStatus.Created));

            CreateMap<OrderModel, Order>();
            CreateMap<Order, OrderModel>();

            CreateMap<OrderModel, OrderResponse>();
        }
    }
}
