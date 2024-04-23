using Soldi.Core.Enums;

namespace Soldi.Application.DTO
{
    public sealed class ContaDTO
    {
        public Guid Id { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
        public bool Ativo { get; set; }
        public Guid UsuarioId { get; set; }

        public string? Nome { get;  set; }
        public decimal Saldo { get;  set; }
        public string? Imagem { get;  set; }
        public ETipoConta TipoConta { get;  set; }

    }
}
