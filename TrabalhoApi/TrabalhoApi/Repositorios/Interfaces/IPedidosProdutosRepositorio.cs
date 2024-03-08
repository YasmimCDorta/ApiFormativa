﻿using TrabalhoApi.Models;

namespace TrabalhoApi.Repositorios
{
    public interface IPedidosProdutosRepositorio
    {
            Task<List<PedidosProdutosModel>> BuscarTodosPedidosProdutos();

            Task<PedidosProdutosModel> BuscarPorId(int id);

            Task<PedidosProdutosModel> Adicionar(PedidosProdutosModel pedidosProdutos);

            Task<PedidosProdutosModel> Atualizar(PedidosProdutosModel pedidosProdutos, int id);

            Task<bool> Apagar(int id);
        }
    }
