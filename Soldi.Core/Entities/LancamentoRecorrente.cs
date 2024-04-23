using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Core.Entities
{
    public sealed class LancamentoRecorrente:Entity,IValidate
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

        public void Atualizar(string? descricao, decimal valor, DateTime datainicial, Guid contaId,
           Guid categoriaId, ETipoCategoria tipoLancamento, string? observacoes, bool pago) 
        {
            Descricao = descricao;
            Valor = valor;
            Datainicial = datainicial;
            ContaId = contaId;
            CategoriaId = categoriaId;
            TipoLancamento = tipoLancamento;
            Observacoes = observacoes;
            Pago = pago;
            UltimaAtualizacao = DateTime.Now;
        }

        public (bool status, string messagem) Validar()
        {
            if (Descricao == null || Descricao.Length < 2) return (false, "Nome deve possuir mais de 2 caracteres!");
            if (CategoriaId == Guid.Empty) return (false, "Informe a categoria!");
            if (ContaId == Guid.Empty) return (false, "Campo Conta é obrigatório!");
            if (TipoLancamento == 0) return (false, "Campo TipoLancamento é obrigatório!");

            return (true, "OK");
        }

        public string? Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Datainicial { get; private set; }
        public Guid ContaId { get; private set; }
        public Guid CategoriaId { get; private set; }
        public ETipoCategoria TipoLancamento { get; private set; }
        public string? Observacoes { get; private set; }
        public bool Pago { get;private set; }

        public Usuario Usuario { get; set; }
        public ICollection<Lancamento> Lancamentos { get; }

    }



}
