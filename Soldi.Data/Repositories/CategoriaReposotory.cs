namespace Soldi.Core.Repositories
{
    public class CategoriaReposotory : GenericRepository<Categoria>, ICategoriaReposotory
    {
        public CategoriaReposotory(SoldiDbContext db) : base(db)
        {
        }
    }


}
