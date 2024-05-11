using Soldi.Core.Base;

namespace Soldi.Application.DTO
{
    public sealed class FaturaDTO:IDTO
    {
        public Guid Id { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
        public bool Ativo { get; set; }
        public Guid UsuarioId { get; set; }

        public string? Descricao { get;  set; }
        public decimal Valor { get;  set; }
        public DateTime Datainicial { get;  set; }
        public Guid CartaoId { get;  set; }
        public Guid CategoriaId { get;  set; }
        public string? Observacoes { get;  set; }
        public Usuario Usuario { get; set; }
    }



}
