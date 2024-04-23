
using Soldi.Core.Enums;

namespace Soldi.Application.DTO
{
    public sealed class CategoriaDTO
    {
        public Guid Id { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
        public bool Ativo { get; set; }
        public Guid UsuarioId { get; set; }
        public string? Nome { get;  set; }
        public ETipoCategoria TipoCategoria { get;  set; }
        public string? Cor { get;  set; }
        public string? Imagem { get;  set; }

    }
}
