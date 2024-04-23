namespace Soldi.Core.Entities
{
    public sealed class Lancamento:Entity
    {
        public Lancamento(Guid usuarioId, string? descricao, string? parcela, decimal valor, DateTime datainicial, Guid contaId,
            Guid categoriaId, ETipoCategoria tipoLancamento, string? observacoes, Guid lancamentoRecorrenteId) : base(usuarioId)
        {
            Descricao = descricao;
            Parcela = parcela;
            Valor = valor;
            Datainicial = datainicial;
            ContaId = contaId;
            CategoriaId = categoriaId;
            TipoLancamento = tipoLancamento;
            Observacoes = observacoes;
            LancamentoRecorrenteId = lancamentoRecorrenteId;
        }
        public void Atualizar( string? descricao, string? parcela, decimal valor, DateTime datainicial, Guid contaId,
          Guid categoriaId, ETipoCategoria tipoLancamento, string? observacoes, Guid lancamentoRecorrenteId) 
        {
            Descricao = descricao;
            Parcela = parcela;
            Valor = valor;
            Datainicial = datainicial;
            ContaId = contaId;
            CategoriaId = categoriaId;
            TipoLancamento = tipoLancamento;
            Observacoes = observacoes;
            LancamentoRecorrenteId = lancamentoRecorrenteId;
            UltimaAtualizacao = DateTime.Now;
        }

        public string? Descricao { get; private set; }
        public string? Parcela { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Datainicial { get; private set; }
        public Guid ContaId { get; private set; }
        public Guid CategoriaId { get; private set; }
        public ETipoCategoria TipoLancamento { get; private set; }
        public string? Observacoes { get; private set; }
        public Guid LancamentoRecorrenteId { get; private set; }
    }



}
