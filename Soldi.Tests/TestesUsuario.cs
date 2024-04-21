using Soldi.Core.Entities;

namespace Soldi.Tests
{
    public class TestesUsuario
    {

        [Fact]
        [Trait("Usuario", "Nome")]
        public void SeNulo_Nome_RetornaFalso()
        {
            var usuario=new Usuario(Guid.NewGuid(),null,null,null,null);
            var result=usuario.Validar();

            Assert.False(result.status, result.messagem);
        }

        [Fact]
        [Trait("Usuario", "Nome")]
        public void SeMenorQue3_Nome_RetornaFalso()
        {
            var usuario = new Usuario(Guid.NewGuid(), "aa", null, null, null);
            var result = usuario.Validar();

            Assert.False(result.status, result.messagem);
        }

        [Fact]
        [Trait("Usuario", "Nome")]
        public void SeMaiorQue2_Nome_RetornaVerdadeiro()
        {
            var usuario = new Usuario(Guid.NewGuid(), "aaa", "ffff@ffff.com", "12345678", null);
            var result = usuario.Validar();

            Assert.True(result.status, result.messagem);
        }

        [Fact]
        [Trait("Usuario", "Email")]
        public void SeNulo_Email_RetornaFalso()
        {
            var usuario = new Usuario(Guid.NewGuid(), "maria", null, "12345678", null);
            var result = usuario.Validar();

            Assert.False(result.status, result.messagem);
        }
        [Fact]
        [Trait("Usuario", "Email")]
        public void SeInvalido_Email_RetornaFalso()
        {
            var usuario = new Usuario(Guid.NewGuid(), "maria", "dsdasdasd", "12345678", null);
            var result = usuario.Validar();

            Assert.False(result.status, result.messagem);
        }
    }
}