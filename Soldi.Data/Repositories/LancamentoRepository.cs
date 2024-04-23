namespace Soldi.Core.Repositories
{
    public class LancamentoRepository : GenericRepository<Lancamento>, ILancamentoRepository
    {
        public LancamentoRepository(SoldiDbContext db) : base(db)
        {
        }
    }


}
