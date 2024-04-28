using Soldi.Core.Entities;
using Soldi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Application.DTO
{
    public sealed class LancamentoRecorrenteDTO
    {
        public Guid Id { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
        public bool Ativo { get; set; }
        public Guid UsuarioId { get; set; }

        public string? Descricao { get;  set; }
        public decimal Valor { get;  set; }
        public DateTime Datainicial { get;  set; }
        public Guid ContaId { get;  set; }
        public Guid CategoriaId { get;  set; }
        public ETipoCategoria TipoLancamento { get;  set; }
        public string? Observacoes { get;  set; }
        public bool Pago { get; set; }

        public Usuario Usuario { get; set; }
        public ICollection<Lancamento> Lancamentos { get; }

    }



}
