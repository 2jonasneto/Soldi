using Soldi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Core.Base
{
    public interface IUnitOfWork
    {
         IContaRepository ContaRepository { get;  }
         IFaturaRepository FaturaRepository { get;  }
         ICartaoRepository CartaoRepository { get;  }
         ICategoriaReposotory CategoriaReposotory { get;  }
         ILancamentoRecorrenteRepository LancamentoRecorrenteRepository { get;  }
         ILancamentoRepository LancamentoRepository { get;  }
         IUsuarioRepository UsuarioRepository { get;  }

        Task<(bool status, string messagem)> Commit();
    }
}
