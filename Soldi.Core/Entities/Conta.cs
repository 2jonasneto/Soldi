﻿

using Soldi.Core.Enums;

namespace Soldi.Core.Entities
{
    public sealed class Conta : Entity,IValidate
    {
        public Conta(Guid usuarioId, string? nome, decimal saldo, string? imagem, ETipoConta tipoConta):base(usuarioId)
        {
            Ativo = true;
            Nome = nome;
            Saldo = saldo;
            Imagem = imagem;
            TipoConta = tipoConta;
        }
        public void AlterarConta( string? nome, decimal saldo, string? imagem, ETipoConta tipoConta)
        {
          
            Nome = nome;
            Saldo = saldo;
            Imagem = imagem;
            TipoConta = tipoConta;
        }
        public void DepositoSaldo(decimal saldo)
        {
            Saldo += saldo;
        }
        public void RetiradaSaldo(decimal saldo)
        {
            Saldo -= saldo;
        }

        public (bool status, string messagem) Validar()
        {
            if (Nome == null || Nome.Length < 2) return (false, "Nome deve possuir mais de 2 caracteres!");
            return (true, "OK");
        }

        public string? Nome { get; private set; }
        public decimal Saldo { get; private set; }
        public string? Imagem { get; private set; }
        public ETipoConta TipoConta { get; private set; }

        public Usuario? Usuario { get; set; }
    }
}
