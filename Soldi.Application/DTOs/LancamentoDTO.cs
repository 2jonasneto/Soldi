using Soldi.Core.Enums;

namespace Soldi.Application.DTO
{
    public sealed class LancamentoDTO
    {
        public Guid Id { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
        public bool Ativo { get; set; }
        public Guid UsuarioId { get; set; }
        public string? Descricao { get;  set; }
        public string? Parcela { get;  set; }
        public decimal Valor { get;  set; }
        public DateTime Datainicial { get;  set; }
        public Guid ContaId { get;  set; }
        public Guid CategoriaId { get;  set; }
        public ETipoCategoria TipoLancamento { get;  set; }
        public string? Observacoes { get;  set; }
        public Guid LancamentoRecorrenteId { get;  set; }
  
    }



}
