using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Application.Queries
{
    public static class CartaoQuery
    {
        public static Expression<Func<Cartao, bool>> GetByName(string nome) {return  x => x.Nome.Contains(nome); }
    }
}
