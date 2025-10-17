using Microsoft.AspNetCore.Mvc;

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProdutos()
        {
            var produtos = new[]
            {
                new { Id = 1, Nome = "Teclado", Preco = 120.50 },
                new { Id = 2, Nome = "Mouse", Preco = 80.00 },
            };
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduto(int id)
        {
            var produto = new { Id = id, Nome = "Monitor", Preco = 950.00 };
            return Ok(produto);
        }
    }
}
