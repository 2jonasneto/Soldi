using AutoMapper;
using Soldi.Application.Base;
using Soldi.Application.DTO;
using Soldi.Core.Base;
using Soldi.Core.Entities;
using Soldi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Application.Handlers
{
    public class UsuarioQueryHandler : IUsuarioQueryHandler
    {
        private readonly IUnitOfWork query;
        private readonly IMapper mapper;
        public UsuarioQueryHandler(IUnitOfWork Usuario, IMapper mapper)
        {
            query = Usuario;
            this.mapper = mapper;
        }
        public async Task<(bool Success, string Message, IEnumerable<UsuarioDTO>? t)> GetByExpression(Expression<Func<Usuario, bool>> expression)
        {
            try
            {
                var data = await query.UsuarioRepository.GetEnumerableByQueryAsync(expression);
                return (true, data.Count() > 0 ? $"{data.Count()} Encontrados" : "Sem registros na base", mapper.Map<List<UsuarioDTO>>(data)); 
            }
            catch (Exception ex)
            {

                return (false, ex.Message, null);
            }
           ;
        }
        public async Task<(bool Success, string Message, IEnumerable<UsuarioDTO>? t)> GetAll()
        {
            try
            {
                var data =await query.UsuarioRepository.GetAllAsync() ;
                var model = mapper.Map<IEnumerable<UsuarioDTO>>(data);

                return (true, data.Count() > 0 ? $"{data.Count()} Encontrados" : "Sem registros na base",model);
            }
            catch (Exception ex)
            {

                return (false, ex.Message, null);
            }

        }

        public async Task<(bool Success, string Message, UsuarioDTO t)> GetById(Guid id)
        {
            try
            {
                var data = await query.UsuarioRepository.GetByIdAsync(id);
                return (true,data is null ?  "Sem registros na base":"", mapper.Map<UsuarioDTO>(data));
            }
            catch (Exception ex)
            {

                return (false, ex.Message, null);
            }
        }
    }
}
