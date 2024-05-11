using Soldi.Application.DTO;
using Soldi.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Application.Base
{
    public interface ICartaoQueryHandler : IQueryHandler<CartaoDTO, Cartao> { }
    public interface IUsuarioQueryHandler : IQueryHandler<UsuarioDTO, Usuario> { }
    public interface IFaturaQueryHandler : IQueryHandler<FaturaDTO, Fatura> { }
}
