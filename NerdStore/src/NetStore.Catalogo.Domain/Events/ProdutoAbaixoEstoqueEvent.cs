using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NedStore.Core.DomainObjects;

namespace NetStore.Catalogo.Domain.Events
{
    public class ProdutoAbaixoEstoqueEvent : DomainEvent
    {
        public int QuantidadeRestante { get; private set; }
        public ProdutoAbaixoEstoqueEvent(Guid aggregateId, int quantidaderestante) : base(aggregateId)
        {
            QuantidadeRestante = quantidaderestante;
        }
    }
}
