using Soldi.Core.Entities;
using Soldi.Data.Base;

namespace Soldi.Core.Repositories
{
    public class LancamentoRecorrenteRepository : GenericRepository<LancamentoRecorrente>, ILancamentoRecorrenteRepository
    {
        public LancamentoRecorrenteRepository(SoldiDbContext db) : base(db)
        {
        }
    }


}
