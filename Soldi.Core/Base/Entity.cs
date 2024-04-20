global using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Core.Base
{
    public abstract class Entity
    {
      

        public Guid Id { get; protected set; } = Guid.NewGuid();
        public Guid UsuarioId { get; protected set; }
        public DateTime UltimaAtualizacao { get; protected set; } = DateTime.Now;
        public string? Ip { get; protected set; }
        public bool Ativo { get; protected set; }


    }
}
