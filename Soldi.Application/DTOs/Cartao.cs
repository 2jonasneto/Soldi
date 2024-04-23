using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Core.Entities
{
    public sealed class Cartao
    {
      
        public string? Nome { get;  set; }
        public string? Imagem { get;  set; }
        public int DiaFechamento { get;  set; }
        public int DiaVencimento { get;  set; }

        public Guid ContaPagamentoPadrao { get;  set; }

        public Usuario? Usuario { get;  set; }
    }
}
