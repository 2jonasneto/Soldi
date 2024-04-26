using Soldi.Core.Base;
using Soldi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Application.Commands
{

    public record CartaoAdicionarCommand(Guid usuarioId, string? nome, string? imagem, int diaFechamento, int diaVencimento, Guid contaPagamentoPadrao) : ICommand { }
    public record  CartaoAtualizarCommand(Guid id, string? nome, string? imagem, int diaFechamento, int diaVencimento, Guid contaPagamentoPadrao) :ICommand { }


}
