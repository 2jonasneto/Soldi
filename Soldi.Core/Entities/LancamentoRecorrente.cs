using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Core.Entities
{
    public sealed class LancamentoRecorrente:Entity
    {
        public string? Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Datainicial { get; private set; }
        public Guid ContaId { get; private set; }
        public Guid CategoriaId { get; private set; }
        public ETipoCategoria TipoLancamento { get; private set; }
        public string? Observacoes { get; private set; }
        
    }



}
