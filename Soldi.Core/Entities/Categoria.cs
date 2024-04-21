﻿
namespace Soldi.Core.Entities
{
    public sealed class Categoria:Entity
    {
        public Categoria(string? nome, ETipoCategoria tipoCategoria, string? cor, string? imagem)
        {
            Nome = nome;
            TipoCategoria = tipoCategoria;
            Cor = cor;
            Imagem = imagem;
        }

        public string? Nome { get; private set; }
        public ETipoCategoria TipoCategoria { get; private set; }
        public string? Cor { get; private set; }
        public string? Imagem { get; private set; }

    }
}
