using Soldi.Core.Functions;

namespace Soldi.Application.DTO
{
    public sealed class UsuarioDTO
    {
        public Guid Id { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
        public bool Ativo { get; set; }
        public Guid UsuarioId { get; set; }
        public string? Nome { get;  set; }

        public string? Email { get;  set; }
        public string? Senha { get;  set; }
        public DateTime? DataNascimento { get;  set; }


       



    }
}