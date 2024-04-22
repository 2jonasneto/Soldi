﻿namespace Soldi.Core.Entities
{
    public sealed class Fatura:Entity,IValidate
    {
        public Fatura(Guid usuarioId,  string? descricao, decimal valor, DateTime datainicial, Guid cartaoId, Guid categoriaId, string? observacoes) : base(usuarioId)
        {
            Descricao = descricao;
            Valor = valor;
            Datainicial = datainicial;
            CartaoId = cartaoId;
            CategoriaId = categoriaId;
            Observacoes = observacoes;
        }
        public void AtualizarFatura(string? descricao, decimal valor, DateTime datainicial, Guid cartaoId, Guid categoriaId, string? observacoes) 
        {
            Descricao = descricao;
            Valor = valor;
            Datainicial = datainicial;
            CartaoId = cartaoId;
            CategoriaId = categoriaId;
            Observacoes = observacoes;
        }
        public (bool status, string messagem) Validar()
        {
            if (Descricao == null || Descricao.Length < 2) return (false, "Nome deve possuir mais de 2 caracteres!");
                      return (true, "OK");
        }

        public string? Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Datainicial { get; private set; }
        public Guid CartaoId { get; private set; }
        public Guid CategoriaId { get; private set; }
        public string? Observacoes { get; private set; }
        
    }



}
