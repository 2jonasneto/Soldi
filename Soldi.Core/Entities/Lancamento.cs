namespace Soldi.Core.Entities
{
    public sealed class Lancamento:Entity,IValidate
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
            Pago = false;
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

        public (bool status, string messagem) Validar()
        {
            if (Descricao == null || Descricao.Length < 2) return (false, "Nome deve possuir mais de 2 caracteres!");
            if (Parcela == null || Parcela.Length < 2) return (false, "Informe a parcela");
            if (CategoriaId == Guid.Empty) return (false, "Informe a categoria!");
            if (ContaId == Guid.Empty) return (false, "Campo Conta é obrigatório!");
            if (TipoLancamento == 0) return (false, "Campo TipoLancamento é obrigatório!");

            return (true, "OK");
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
        public Usuario Usuario { get; set; }
        public bool Pago { get; private set; }
        public LancamentoRecorrente LancamentoRecorrente { get; set; }
    }



}
