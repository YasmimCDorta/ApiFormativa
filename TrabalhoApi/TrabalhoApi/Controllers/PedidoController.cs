﻿using Microsoft.AspNetCore.Mvc;
using TrabalhoApi.Models;
using TrabalhoApi.Repositorios.Interfaces;

namespace TrabalhoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        public PedidoController(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidosModel>>> BuscarTodosPedidos()
        {
            List<PedidosModel> pedidos = await _pedidoRepositorio.BuscarTodosPedidos();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<PedidosModel>> BuscarPorId(int id)
        {
            UsuarioModel pedidos = await _pedidoRepositorio.BuscarPorId(id);
            return Ok(pedidos);
        }

        [HttpPost]

        public async Task<ActionResult<PedidosModel>> Adicionar([FromBody] PedidosModel pedidoModel)
        {
            PedidosModel pedido = await _pedidoRepositorio.Adicionar(pedidoModel);
            return Ok(pedido);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<PedidosModel>> Atualizar(int id, [FromBody] PedidosModel pedidoModel)
        {
            pedidoModel.Id = id;
            PedidosModel pedido = await _pedidoRepositorio.Atualizar(pedidoModel, id);
            return Ok(pedido);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PedidosModel>> Apagar(int id)
        {
            bool apagado = await _pedidoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
