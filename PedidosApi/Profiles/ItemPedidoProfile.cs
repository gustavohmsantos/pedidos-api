using AutoMapper;
using PedidosApi.Dtos.ItemPedido;
using PedidosApi.Models;

namespace PedidosApi.Profiles
{
    public class ItemPedidoProfile : Profile
    {
        public ItemPedidoProfile()
        {
            CreateMap<CreateItemPedidoDto, ItemPedidoModel>();
            CreateMap<ItemPedidoModel, ReadItemPedidoDto>();
        }
    }
}
