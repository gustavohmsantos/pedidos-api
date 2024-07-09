using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidosApi.Data;
using PedidosApi.Dtos.ItemPedido;
using PedidosApi.Models;

namespace PedidosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPedidoController : ControllerBase
    {
        private readonly PedidosApiContext _context;
        private readonly IMapper _mapper;

        public ItemPedidoController(PedidosApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ReadItemPedidoDto>> CreateItemPedido([FromBody] CreateItemPedidoDto createItemPedidoDto)
        {
            var itemPedido = _mapper.Map<ItemPedidoModel>(createItemPedidoDto);
            _context.ItensPedidos.Add(itemPedido);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ReadItemPedido), new { pedidoId = itemPedido.PedidoId, produtoId = itemPedido.ProdutoId}, itemPedido);
        }

        [HttpGet("{pedidoId}")]
        public async Task<ActionResult<ICollection<ReadItemPedidoDto>>> ReadItemPedidoPorIdPedido(int pedidoId)
        {
            var itensPedido = await _context.ItensPedidos.Where(itemPedido => itemPedido.PedidoId == pedidoId).ToListAsync();
            if (itensPedido == null) return NotFound();
            var readItemPedidoDto = _mapper.Map<List<ReadItemPedidoDto>>(itensPedido);
            return Ok(readItemPedidoDto);
        }


        [HttpGet("{pedidoId}/{produtoId}")]
        public async Task<ActionResult<ReadItemPedidoDto>> ReadItemPedido(int pedidoId, int produtoId)
        {
            var itemPedido = await _context.ItensPedidos
                .FirstOrDefaultAsync(itemPedido => itemPedido.PedidoId == pedidoId && itemPedido.ProdutoId == produtoId);
            if (itemPedido == null) return NotFound();
            var readItemPedidoDto = _mapper.Map<ReadItemPedidoDto>(itemPedido);
            return Ok(readItemPedidoDto);
        }

        [HttpDelete("{pedidoId}/{produtoId}")]
        public async Task<IActionResult> DeleteProduto(int pedidoId, int produtoId)
        {
            var itemPedido = await _context.ItensPedidos
                .FirstOrDefaultAsync(itemPedido => itemPedido.PedidoId == pedidoId && itemPedido.ProdutoId == produtoId);
            if (itemPedido == null) return NotFound();
            _context.ItensPedidos.Remove(itemPedido);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
