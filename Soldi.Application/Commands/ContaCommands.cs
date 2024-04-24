using Soldi.Core.Base;
using Soldi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Application.Commands
{

    public record ContaAdicionarCommand(Guid usuarioId, string? nome, decimal saldo, string? imagem, int tipoConta) : ICommand { }
    public record  ContaAtualizarCommand(Guid id, Guid usuarioId, string? nome,  string? imagem, int tipoConta):ICommand { }
    public record  ContaDepositoCommand(Guid id, decimal saldo):ICommand { }
    public record  ContaRetiradaCommand(Guid id, decimal saldo):ICommand { }
    public record  ContaDefinirSaldoCommand(Guid id, decimal saldo):ICommand { }


}
