using Soldi.Core.Base;
using Soldi.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Application.Commands
{

    public record UsuarioAdicionarCommand(string? nome, string? email, string? senha, DateTime? dataNascimento) : ICommand { }
    public record UsuarioAtualizarCommand(Guid id,string? nome, string? email, DateTime? dataNascimento) :ICommand { }
    public record AlterarSenhaCommand(Guid id, string? senha) :ICommand { }


}
