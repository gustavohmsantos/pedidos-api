using AutoMapper;
using PedidosApi.Dtos.Cliente;
using PedidosApi.Models;

namespace PedidosApi.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<CreateClienteDto, ClienteModel>();
            CreateMap<ClienteModel, ReadClienteDto>();
            CreateMap<UpdateClienteDto, ClienteModel>();
            CreateMap<ClienteModel, UpdateClienteDto>();
        }
    }
}
