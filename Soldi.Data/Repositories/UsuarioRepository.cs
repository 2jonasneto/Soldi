

namespace Soldi.Core.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SoldiDbContext db) : base(db)
        {
        }
    }


}
