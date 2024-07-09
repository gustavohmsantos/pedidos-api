using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidosApi.Data;
using PedidosApi.Dtos.Cliente;
using PedidosApi.Models;

namespace PedidosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly PedidosApiContext _context;
        private readonly IMapper _mapper;
        public ClienteController(PedidosApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCliente([FromBody] CreateClienteDto createClienteDto)
        {
            var clienteCriado = _mapper.Map<ClienteModel>(createClienteDto);
            _context.Clientes.Add(clienteCriado);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ReadClientePorId), new {id = clienteCriado.Id}, clienteCriado);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadClienteDto>>> ReadClientes([FromQuery] int skip = 0,
        [FromQuery] int take = 50)
        {
            return Ok(_mapper.Map<List<ReadClienteDto>>(await _context.Clientes.Skip(skip).Take(take).ToListAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadClienteDto>> ReadClientePorId(int id)
        {
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(cliente => cliente.Id == id);
            if (cliente == null) return NotFound();
            var readClienteDto = _mapper.Map<ReadClienteDto>(cliente);
            return Ok(readClienteDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id,[FromBody] UpdateClienteDto updateClienteDto)
        {
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(cliente => cliente.Id == id);
            if (cliente == null) return NotFound();
            _mapper.Map(updateClienteDto, cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialUpdateCliente(int id, JsonPatchDocument<UpdateClienteDto> jsonPatch)
        {
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(cliente => cliente.Id == id);
            if (cliente == null) return NotFound();
            var clienteAtualizado = _mapper.Map<UpdateClienteDto>(cliente);
            jsonPatch.ApplyTo(clienteAtualizado, ModelState);
            if (!TryValidateModel(clienteAtualizado)) return ValidationProblem(ModelState);
            _mapper.Map(clienteAtualizado, cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(cliente => cliente.Id == id);
            if (cliente == null) return NotFound();
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
