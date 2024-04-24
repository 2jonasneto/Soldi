using Soldi.Core.Base;
using Soldi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Data.Base
{
    internal class UnitOfWork : IUnitOfWork
    {
        private IContaRepository? _contaRepo;
        private IFaturaRepository? _faturaRepo;
        private ICartaoRepository? _cartaoRepo;
        private ICategoriaReposotory? _categoriaRepo;
        private ILancamentoRecorrenteRepository? _lancamentoRecorrenteRepo;
        private ILancamentoRepository? _lancamentoRepo;
        private IUsuarioRepository? _usuarioRepo;

        private SoldiDbContext _context;

        public IContaRepository ContaRepository
        {
            get { return _contaRepo = _contaRepo ?? new ContaRepository(_context); }
        }

         public IFaturaRepository FaturaRepository
        {
            get { return _faturaRepo = _faturaRepo ?? new FaturaRepository(_context); }
        }

         public ICartaoRepository CartaoRepository
        {
            get { return _cartaoRepo = _cartaoRepo ?? new CartaoRepository(_context); }
        }

         public ICategoriaReposotory CategoriaReposotory
        {
            get { return _categoriaRepo = _categoriaRepo ?? new CategoriaReposotory(_context); }
        }

         public ILancamentoRepository LancamentoRepository
        {
            get { return _lancamentoRepo = _lancamentoRepo ?? new LancamentoRepository(_context); }
        }

         public ILancamentoRecorrenteRepository LancamentoRecorrenteRepository
        {
            get { return _lancamentoRecorrenteRepo = _lancamentoRecorrenteRepo ?? new LancamentoRecorrenteRepository(_context); }
        }

         public IUsuarioRepository UsuarioRepository
        {
            get { return _usuarioRepo = _usuarioRepo ?? new UsuarioRepository(_context); }
        }



        public UnitOfWork(SoldiDbContext context)
        {
            _context = context;
        }

        public async Task<(bool status,string messagem)> Commit()
        {
            try
            {
                return (await _context.SaveChangesAsync()) == 1 ? (true, "Sucesso!") : (false, "Erro ao executar a operação");
            }
            catch (Exception ex)
            {

                return (false, ex.Message);
            }
     
        }
    }
}
