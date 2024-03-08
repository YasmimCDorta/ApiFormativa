using Microsoft.AspNetCore.Mvc;
using TrabalhoApi.Models;
using TrabalhoApi.Repositorios;
using TrabalhoApi.Repositorios.Interfaces;

namespace TrabalhoApi.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class ProdutoController : ControllerBase
        {
            private readonly IProdutoRepositorio _produtoRepositorio;
            public ProdutoController(IProdutoRepositorio produtoRepositorio)
            {
                _produtoRepositorio = produtoRepositorio;
            }

            [HttpGet]
            public async Task<ActionResult<List<ProdutoModel>>> BuscarTodosProduto()
            {
                List<ProdutoModel> produto = await _produtoRepositorio.BuscarTodosProduto();
                return Ok(produto);
            }

            [HttpGet("{id}")]

            public async Task<ActionResult<ProdutoModel>> BuscarPorId(int id)
            {
            ProdutoModel produto = await _produtoRepositorio.BuscarPorId(id);
                return Ok(produto);
            }

            [HttpPost]

            public async Task<ActionResult<ProdutoModel>> Adicionar([FromBody] ProdutoModel produtoModel)
            {
                ProdutoModel produto = await _produtoRepositorio.Adicionar(produtoModel);
                return Ok(produto);
            }

            [HttpPut("{id}")]

            public async Task<ActionResult<ProdutoModel>> Atualizar(int id, [FromBody] ProdutoModel produtoModel)
            {
                produtoModel.Id = id;
                ProdutoModel produto = await _produtoRepositorio.Atualizar(produtoModel, id);
                return Ok(produto);
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult<ProdutoModel>> Apagar(int id)
            {
                bool apagado = await _produtoRepositorio.Apagar(id);
                return Ok(apagado);
            }
        }
    }
