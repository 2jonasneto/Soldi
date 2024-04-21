
using Soldi.Core.Functions;

namespace Soldi.Core.Entities
{
    public sealed class Categoria:Entity, IValidate
    {
        public Categoria(Guid usuarioId, string? nome, ETipoCategoria tipoCategoria, string? cor, string? imagem):base(usuarioId)
        {
            Nome = nome;
            TipoCategoria = tipoCategoria;
            Cor = cor;
            Imagem = imagem;
        }
        public void AlterarCategoria(string? nome, ETipoCategoria tipoCategoria, string? cor, string? imagem)
        {
            Nome = nome;
            TipoCategoria = tipoCategoria;
            Cor = cor;
            Imagem = imagem;
        }

        public (bool status, string messagem) Validar()
        {
            if (Nome == null || Nome.Length < 3) return (false, "Nome deve possuir mais de 3 caracteres!");
            return (true, "OK");
        }

        public string? Nome { get; private set; }
        public ETipoCategoria TipoCategoria { get; private set; }
        public string? Cor { get; private set; }
        public string? Imagem { get; private set; }

    }
}
