using Microsoft.AspNetCore.Mvc;
using TrabalhoApi.Models;
using TrabalhoApi.Repositorios.Interfaces;

namespace TrabalhoApi.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class CategoriaController : ControllerBase
        {
            private readonly ICategoriaRepositorio _CategoriaRepositorio;
            public CategoriaController(ICategoriaRepositorio CategoriaRepositorio)
            {
                _CategoriaRepositorio = CategoriaRepositorio;
            }

            [HttpGet]
            public async Task<ActionResult<List<CategoriaModel>>> BuscarTodasCategoria()
            {
                List<CategoriaModel> categoria = await _CategoriaRepositorio.BuscarTodasCategoria();
                return Ok(categoria);
            }

            [HttpGet("{id}")]

            public async Task<ActionResult<CategoriaModel>> BuscarPorId(int id)
            {
                CategoriaModel categoria = await _CategoriaRepositorio.BuscarPorId(id);
                return Ok(categoria);
            }

            [HttpPost]

            public async Task<ActionResult<CategoriaModel>> Adicionar([FromBody] CategoriaModel CategoriaModel)
            {
                CategoriaModel categoria = await _CategoriaRepositorio.Adicionar(CategoriaModel);
                return Ok(categoria);
            }

            [HttpPut("{id}")]

            public async Task<ActionResult<CategoriaModel>> Atualizar(int id, [FromBody] CategoriaModel CategoriaModel)
            {
                CategoriaModel.Id = id;
                CategoriaModel categoria = await _CategoriaRepositorio.Atualizar(CategoriaModel, id);
                return Ok(categoria);
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult<CategoriaModel>> Apagar(int id)
            {
                bool apagado = await _CategoriaRepositorio.Apagar(id);
                return Ok(apagado);
            }
        }
    }

