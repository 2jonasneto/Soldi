using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Application.Queries
{
    public static class FaturaQuery
    {
        public static Expression<Func<Fatura, bool>> GetByName(string descricao) {return  x => x.Descricao.Contains(descricao); }
    }
}
