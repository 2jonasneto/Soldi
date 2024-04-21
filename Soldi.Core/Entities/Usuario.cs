namespace Soldi.Core.Entities
{
    public sealed class Usuario:Entity
    {
        public Usuario(Guid usuarioId, string? nome, string? email, string? senha, DateTime dataNascimento) : base(usuarioId)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            DataNascimento = dataNascimento;
        }
        public void Atualizar(string? nome, string? email,  DateTime dataNascimento)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
        }
        public void AlterarSenha( string? senha)
        {
            Senha = senha;
        }
        public string? Nome { get; private set; }

        public string? Email { get; private set; }
        public string? Senha { get; private set; }
        public DateTime DataNascimento { get; private set; }


        public IReadOnlyCollection<Cartao>? Cartao { get; set;}
    }
}