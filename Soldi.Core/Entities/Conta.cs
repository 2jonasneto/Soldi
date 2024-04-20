

namespace Soldi.Core.Entities
{
    public sealed class Conta : Entity
    {
        public Conta(Guid usuarioId,  string? ip,  string? nome, decimal saldo, string? imagem) 
        {
            UsuarioId = usuarioId;
            Ip = ip;
            Ativo = true;
            Nome = nome;
            Saldo = saldo;
            Imagem = imagem;
        }
        public void AlterarConta( string? ip, bool ativo, string? nome, decimal saldo, string? imagem)
        {
            Ip = ip;
            Ativo &= ativo;
            Nome = nome;
            Saldo = saldo;
            Imagem = imagem;
        }
        public void DepositoSaldo(decimal saldo)
        {
            Saldo += saldo;
        }
        public void RetiradaSaldo(decimal saldo)
        {
            Saldo -= saldo;
        }
        public string? Nome { get; private set; }
        public decimal Saldo { get; private set; }
        public string? Imagem { get; private set; }


        public Usuario? Usuario { get; set; }
    }
}
