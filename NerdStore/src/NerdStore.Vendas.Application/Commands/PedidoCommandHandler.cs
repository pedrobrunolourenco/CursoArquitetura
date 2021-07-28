﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NerdStore.Core.Messages;
using NerdStore.Vendas.Domain;

namespace NerdStore.Vendas.Application.Commands
{
    public class PedidoCommandHandler : IRequestHandler<AdicionarItemPedidoCommand, bool>
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoCommandHandler(IPedidoRepository pedidoRepository)
        {
            pedidoRepository = _pedidoRepository;
        }

        public async Task<bool> Handle(AdicionarItemPedidoCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;

            var pedido = await _pedidoRepository.ObterPedidoRascunhoPorClienteId(message.ClienteId);
            var pedidoItem = new PedidoItem(message.ProdutoId, message.Nome, message.Quantidade, message.ValorUnitario);

            if(pedido == null)
            {
                Pedido.PedidoFactory.NovoPedidoRascunho(message.ClienteId);
                pedido.AdicionarItem(pedidoItem);
                _pedidoRepository.Adicionar(pedido);
            }
            else
            {
                var pedidoItemExistente = pedido.PedidoItemExistente(pedidoItem);
                pedido.AdicionarItem(pedidoItem); 
                if(pedidoItemExistente)
                {
                    _pedidoRepository.AtualizarItem(pedido.PedidoItems.FirstOrDefault( p => p.ProdutoId == pedidoItem.ProdutoId ));
                }
                else
                {
                    _pedidoRepository.AtualizarItem(pedidoItem);
                }
            }

            return await _pedidoRepository.UnitOfWork.Commit();
        }


        private bool ValidarComando(Command message)
        {
            if (message.EhValido()) return true;
            foreach (var error in message.ValidationResult.Errors)
            {
                // lancar evento de erro
            }

            return false;

        }
    }
}
