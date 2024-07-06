using AutoMapper;
using PedidosApi.Dtos.Pedido;
using PedidosApi.Models;

namespace PedidosApi.Profiles
{
    public class PedidoProfile: Profile
    {
        public PedidoProfile()
        {
            CreateMap<CreatePedidoDto, PedidoModel>();
            CreateMap<PedidoModel, ReadPedidoDto>();
        }
    }
}
