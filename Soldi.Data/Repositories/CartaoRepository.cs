namespace Soldi.Core.Repositories
{
    public class CartaoRepository : GenericRepository<Cartao>, ICartaoRepository
    {
        public CartaoRepository(SoldiDbContext db) : base(db)
        {
        }
    }


}
