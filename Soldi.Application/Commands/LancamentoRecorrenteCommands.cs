using Soldi.Core.Base;
using Soldi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Application.Commands
{

    public record LancamentoRecorrenteAdicionarCommand(Guid usuarioId, string? descricao, decimal valor, DateTime datainicial, Guid contaId,
            Guid categoriaId, ETipoCategoria tipoLancamento, string? observacoes, bool pago) : ICommand { }
    public record  LancamentoRecorrenteAtualizarCommand(Guid id, string? descricao, decimal valor, DateTime datainicial, Guid contaId,
           Guid categoriaId, ETipoCategoria tipoLancamento, string? observacoes, bool pago) :ICommand { }


}
