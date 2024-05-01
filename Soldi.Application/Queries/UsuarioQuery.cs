using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Application.Queries
{
    public static class UsuarioQuery
    {
        public static Expression<Func<Usuario, bool>> GetByEmail(string email) {return  x => x.Email==email; }
    }
}
