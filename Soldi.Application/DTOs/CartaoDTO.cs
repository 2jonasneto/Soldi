using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Application.DTO
{
    public sealed class CartaoDTO
    {
        public Guid Id { get;  set; } 
        public DateTime UltimaAtualizacao { get;  set; } 
        public bool Ativo { get;  set; }
        public Guid UsuarioId { get; set; }
        public string? Nome { get;  set; }
        public string? Imagem { get;  set; }
        public int DiaFechamento { get;  set; }
        public int DiaVencimento { get;  set; }
        public Guid ContaPagamentoPadrao { get;  set; }

    }
}
