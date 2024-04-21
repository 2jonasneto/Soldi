global using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Core.Base
{
    public abstract class Entity
    {
        protected Entity(Guid usuarioId)
        {
            UsuarioId = usuarioId;
        }

        public Guid Id { get; protected set; } = Guid.NewGuid();
        public DateTime UltimaAtualizacao { get; protected set; } = DateTime.Now;
        public bool Ativo { get; protected set; } = true;
        public Guid UsuarioId { get; protected set; }

    
    }

    
}
