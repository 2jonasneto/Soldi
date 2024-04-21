using Soldi.Core.Functions;

namespace Soldi.Core.Entities
{
    public sealed class Usuario: Entity,IValidate
    {
        public Usuario(Guid usuarioId, string? nome, string? email, string? senha, DateTime? dataNascimento) : base(usuarioId)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            DataNascimento = dataNascimento;
        }
        public void Atualizar(string? nome, string? email,  DateTime? dataNascimento)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
        }
        public void AlterarSenha( string? senha)
        {
         
            Senha = senha;

          
        }
        public (bool status, string messagem) Validar()
        {
            if (Nome == null || Nome.Length < 3) return (false, "Nome deve possuir mais de 3 caracteres!");
            if (!Validations.IsEmail(Email)) return (false, "Email inválido!");
            if (Senha == null || Senha.Length < 8) return (false, "senha deve possuir no mínimo 8 caracteres!");
            return (true, "OK");
        }
        public string? Nome { get; private set; }

        public string? Email { get; private set; }
        public string? Senha { get; private set; }
        public DateTime? DataNascimento { get; private set; }


        public IReadOnlyCollection<Cartao>? Cartao { get; set;}
    }
}