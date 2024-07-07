using AutoMapper;
using PedidosApi.Dtos.Produto;
using PedidosApi.Models;

namespace PedidosApi.Profiles
{
    public class ProdutoProfile: Profile
    {
        public ProdutoProfile()
        {
            CreateMap<CreateProdutoDto, ProdutoModel>();
            CreateMap<ProdutoModel, ReadProdutoDto>();
            CreateMap<UpdateProdutoDto, ProdutoModel>();
        }
    }
}
