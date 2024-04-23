using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Core.Entities
{
    public sealed class Cartao:Entity,IValidate
    {
        public Cartao(Guid usuarioId,  string? nome, string? imagem, int diaFechamento, int diaVencimento, Guid contaPagamentoPadrao) : base(usuarioId)
        {
            Nome = nome;
            Imagem = imagem;
            DiaFechamento = diaFechamento;
            DiaVencimento = diaVencimento;
            ContaPagamentoPadrao = contaPagamentoPadrao;
        }
        public void Atualizar( string? nome, string? imagem, int diaFechamento, int diaVencimento, Guid contaPagamentoPadrao)
        {
            Nome = nome;
            Imagem = imagem;
            DiaFechamento = diaFechamento;
            DiaVencimento = diaVencimento;
            ContaPagamentoPadrao = contaPagamentoPadrao;
            UltimaAtualizacao=DateTime.Now;
        }
        public void desativar()
        {
            Ativo = false;
            UltimaAtualizacao = DateTime.Now;
        }
        public (bool status, string messagem) Validar()
        {
            if (Nome == null || Nome.Length < 2) return (false, "Nome deve possuir mais de 2 caracteres!");
            if (DiaFechamento== 0) return (false, "Informe o dia de fechamento!");
            if (DiaVencimento== 0) return (false, "Informe o dia de vencimento!");
            if (UsuarioId == Guid.Empty) return (false, "Usuário não informado!");

            return (true, "OK");
        }

        public string? Nome { get; private set; }
        public string? Imagem { get; private set; }
        public int DiaFechamento { get; private set; }
        public int DiaVencimento { get; private set; }

        public Guid ContaPagamentoPadrao { get; private set; }

        public Usuario? Usuario { get; private set; }
    }
}
