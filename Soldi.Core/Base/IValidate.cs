using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Core.Base
{
    public interface IValidate
    {
        public (bool status, string messagem) Validar();
    }
}
