using AutoMapper;
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

namespace Soldi.Application.Queries
{
    public class CartaoQueryHandler : IQueryHandler<CartaoDTO>
    {
        private readonly IUnitOfWork query;
        private readonly IMapper mapper;
        public CartaoQueryHandler(IUnitOfWork cartao, IMapper mapper)
        {
            query = cartao;
            this.mapper = mapper;
        }
        public async Task<(bool Success, string Message, IEnumerable<CartaoDTO>? t)> GetByExpression(Expression<Func<CartaoDTO, bool>> expression)
        {


            return (false, "", null);
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

        public Task<(bool Success, string Message, CartaoDTO t)> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
