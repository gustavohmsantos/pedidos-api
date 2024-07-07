using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidosApi.Data;
using PedidosApi.Dtos.Pedido;
using PedidosApi.Dtos.Produto;
using PedidosApi.Models;

namespace PedidosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly PedidosApiContext _context;
        private readonly IMapper _mapper;

        public ProdutoController(PedidosApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduto([FromBody] CreateProdutoDto createProdutoDto)
        {
            var produtoCriado = _mapper.Map<ProdutoModel>(createProdutoDto);
            _context.Produtos.Add(produtoCriado);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ReadProdutoPorId), new { id = produtoCriado.Id }, createProdutoDto); ;

        }

        [HttpGet]
        public async Task<IEnumerable<ReadProdutoDto>> ReadProdutos([FromQuery] int skip = 0, 
            [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadProdutoDto>>(await _context.Produtos.Skip(skip).Take(take).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadProdutoPorId(int id)
        {
            var produto = await _context.Produtos
                .FirstOrDefaultAsync(produto => produto.Id == id);
            if (produto == null) return NotFound();
            var readProdutoDto = _mapper.Map<ReadProdutoDto>(produto);
            return Ok(readProdutoDto);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduto(int id, [FromBody] UpdateProdutoDto updateProdutoDto)
        {
            var produto = await _context.Produtos
                .FirstOrDefaultAsync(produto => produto.Id == id);
            if (produto == null) return NotFound();
            _mapper.Map(updateProdutoDto, produto);
            await _context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _context.Produtos
                .FirstOrDefaultAsync(produto => produto.Id == id);
            if (produto == null) return NotFound();
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
