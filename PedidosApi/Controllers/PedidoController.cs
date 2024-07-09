using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidosApi.Data;
using PedidosApi.Dtos.Pedido;
using PedidosApi.Models;

namespace PedidosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidosApiContext _context;
        private readonly IMapper _mapper;

        public PedidoController(PedidosApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePedido([FromBody] CreatePedidoDto createPedidoDto)
        {
            var cliente = _context.Clientes
                .FirstOrDefault(cliente => cliente.Id == createPedidoDto.ClienteId);
            if (cliente == null) return NotFound();
            var pedidoCriado = _mapper.Map<PedidoModel>(createPedidoDto);
            _context.Pedidos.Add(pedidoCriado);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ReadPedidoPorId), new { id = pedidoCriado.Id }, createPedidoDto);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ReadPedidoDto>>> ReadPedidos([FromQuery] int skip = 0,
            [FromQuery] int take = 50)
        {
            return Ok(_mapper
                .Map<List<ReadPedidoDto>>(await _context.Pedidos
                .Skip(skip).Take(take).ToListAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadPedidoDto>> ReadPedidoPorId(int id)
        {
            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(pedido => pedido.Id == id);
            if (pedido == null) return NotFound();
            var readPedidoDto = _mapper.Map<ReadPedidoDto>(pedido);
            return Ok(readPedidoDto);
        }

        [HttpGet("BuscarPorIdCliente/{id}")]
        public async Task<ActionResult<ICollection<ReadPedidoDto>>> ReadPedidosPorIdCliente(int id)
        {
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(cliente => cliente.Id == id);
            if (cliente == null) return NotFound();
            var pedidos = await _context.Pedidos.Include(db => db.Cliente)
                .Where(pedido => pedido.Cliente.Id == id)
                .ToListAsync();

            return Ok(_mapper.Map<List<ReadPedidoDto>>(pedidos));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePedido(int id, [FromBody] UpdatePedidoDto updatePedidoDto)
        {
            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(pedido => pedido.Id == id);
            if (pedido == null) return NotFound();

            _mapper.Map(updatePedidoDto, pedido);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(pedido => pedido.Id == id);
            if(pedido == null) return NotFound();
            _context.Remove(pedido);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
