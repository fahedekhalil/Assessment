using AutoMapper;
using CustomerOrderServiceAPI.DTOs;
using CustomerOrderServiceAPI.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterDto, Customer>();
        CreateMap<OrderItemDto, CustomerOrderItem>();
        CreateMap<CreateOrderDto, CustomerOrder>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

    }
}