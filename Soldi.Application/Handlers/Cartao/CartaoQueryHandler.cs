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
    public class CartaoQueryHandler : ICartaoQueryHandler
    {
        private readonly IUnitOfWork query;
        private readonly IMapper mapper;
        public CartaoQueryHandler(IUnitOfWork cartao, IMapper mapper)
        {
            query = cartao;
            this.mapper = mapper;
        }
        public async Task<(bool Success, string Message, IEnumerable<CartaoDTO>? t)> GetByExpression(Expression<Func<Cartao, bool>> expression)
        {
            try
            {
                var data = await query.CartaoRepository.GetEnumerableByQueryAsync(expression);
                return (true, data.Count() > 0 ? $"{data.Count()} Encontrados" : "Sem registros na base", mapper.Map<List<CartaoDTO>>(data)); 
            }
            catch (Exception ex)
            {

                return (false, ex.Message, null);
            }
           ;
        }
        public async Task<(bool Success, string Message, IEnumerable<CartaoDTO>? t)> GetAll()
        {
            try
            {
                var data = await query.CartaoRepository.GetAllAsync();
                return (true, data.Count() > 0 ? $"{data.Count()} Encontrados" : "Sem registros na base", mapper.Map<List<CartaoDTO>>(data));
            }
            catch (Exception ex)
            {

                return (false, ex.Message, null);
            }

        }

        public async Task<(bool Success, string Message, CartaoDTO t)> GetById(Guid id)
        {
            try
            {
                var data = await query.CartaoRepository.GetByIdAsync(id);
                return (true,data is null ?  "Sem registros na base":"", mapper.Map<CartaoDTO>(data));
            }
            catch (Exception ex)
            {

                return (false, ex.Message, null);
            }
        }
    }
}
