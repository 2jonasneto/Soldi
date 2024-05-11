using Soldi.Core.Base;
using Soldi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Application.Commands
{

    public record FaturaAdicionarCommand(Guid usuarioId, string? descricao,decimal valor,DateTime dataInicial,Guid cartaoId,Guid categoriaId,string? observacoes) : ICommand { }
    public record  FaturaAtualizarCommand(Guid id, string? descricao, decimal valor, DateTime datainicial, Guid cartaoId, Guid categoriaId, string? observacoes) :ICommand { }


}
