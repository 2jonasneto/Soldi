using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Core.Entities
{
    public sealed class LancamentoRecorrente:Entity
    {
        public LancamentoRecorrente(Guid usuarioId, string? descricao, decimal valor, DateTime datainicial, Guid contaId,
            Guid categoriaId, ETipoCategoria tipoLancamento, string? observacoes, bool pago) : base(usuarioId)
        {
            Descricao = descricao;
            Valor = valor;
            Datainicial = datainicial;
            ContaId = contaId;
            CategoriaId = categoriaId;
            TipoLancamento = tipoLancamento;
            Observacoes = observacoes;
            Pago = pago;
        }

        public string? Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Datainicial { get; private set; }
        public Guid ContaId { get; private set; }
        public Guid CategoriaId { get; private set; }
        public ETipoCategoria TipoLancamento { get; private set; }
        public string? Observacoes { get; private set; }
        public bool Pago { get;private set; }
    }



}
