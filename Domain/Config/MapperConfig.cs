using AutoMapper;
using Domain.DTO;
using Domain.Request;

namespace Domain.Config
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Client, ClientRequest>().ReverseMap();
            CreateMap<Address, AddressRequest>().ReverseMap();
            CreateMap<Phone, PhoneRequest>().ReverseMap();
        }
    }
}
