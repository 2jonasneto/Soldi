namespace Soldi.Core.Repositories
{
    public class ContaRepository : GenericRepository<Conta>, IContaRepository
    {
        public ContaRepository(SoldiDbContext db) : base(db)
        {
        }
    }


}
