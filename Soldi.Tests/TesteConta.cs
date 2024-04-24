using Soldi.Core.Base;
using Soldi.Core.Entities;

namespace Soldi.Tests
{
    public class TesteConta
    {
       

        [Fact]
        [Trait("Usuario", "Nome")]
        public void SeNulo_Nome_RetornaFalso()
        {
            var usuario=new Usuario(Guid.NewGuid(),null,null,null,null);
            var result=usuario.Validar();

            Assert.False(result.status, result.messagem);
        }

     
    }
}