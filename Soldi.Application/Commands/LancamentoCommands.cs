using Soldi.Core.Base;
using Soldi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Application.Commands
{

    public record LancamentoAdicionarCommand(Guid usuarioId, string? descricao, string? parcela, decimal valor, DateTime datainicial, Guid contaId,
            Guid categoriaId, ETipoCategoria tipoLancamento, string? observacoes, Guid lancamentoRecorrenteId) : ICommand { }
    public record  LancamentoAtualizarCommand(Guid id, string? descricao, string? parcela, decimal valor, DateTime datainicial, Guid contaId,
          Guid categoriaId, ETipoCategoria tipoLancamento, string? observacoes, Guid lancamentoRecorrenteId) :ICommand { }


}
