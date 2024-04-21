using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Core.Entities
{
    public sealed class Cartao:Entity
    {
        public Cartao(Guid usuarioId,  string? nome, string? imagem, int diaFechamento, int diaVencimento, Guid contaPagamentoPadrao) : base(usuarioId)
        {
            Nome = nome;
            Imagem = imagem;
            DiaFechamento = diaFechamento;
            DiaVencimento = diaVencimento;
            ContaPagamentoPadrao = contaPagamentoPadrao;
        }
        public void AtualizarCartao( string? nome, string? imagem, int diaFechamento, int diaVencimento, Guid contaPagamentoPadrao)
        {
            Nome = nome;
            Imagem = imagem;
            DiaFechamento = diaFechamento;
            DiaVencimento = diaVencimento;
            ContaPagamentoPadrao = contaPagamentoPadrao;
        }


        public string? Nome { get; private set; }
        public string? Imagem { get; private set; }
        public int DiaFechamento { get; private set; }
        public int DiaVencimento { get; private set; }

        public Guid ContaPagamentoPadrao { get; private set; }

        public Usuario? Usuario { get; private set; }
    }
}
