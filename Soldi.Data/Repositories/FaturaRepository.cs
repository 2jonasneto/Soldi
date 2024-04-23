namespace Soldi.Core.Repositories
{
    public class FaturaRepository : GenericRepository<Fatura>, IFaturaRepository
    {
        public FaturaRepository(SoldiDbContext db) : base(db)
        {
        }
    }


}
