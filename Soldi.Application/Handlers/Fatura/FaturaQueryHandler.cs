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
    public class FaturaQueryHandler : IFaturaQueryHandler
    {
        private readonly IUnitOfWork query;
        private readonly IMapper mapper;
        public FaturaQueryHandler(IUnitOfWork Fatura, IMapper mapper)
        {
            query = Fatura;
            this.mapper = mapper;
        }
        public async Task<(bool Success, string Message, IEnumerable<FaturaDTO>? t)> GetByExpression(Expression<Func<Fatura, bool>> expression)
        {
            try
            {
                var data = await query.FaturaRepository.GetEnumerableByQueryAsync(expression);
                return (true, data.Count() > 0 ? $"{data.Count()} Encontrados" : "Sem registros na base", mapper.Map<List<FaturaDTO>>(data)); 
            }
            catch (Exception ex)
            {

                return (false, ex.Message, null);
            }
           ;
        }
        public async Task<(bool Success, string Message, IEnumerable<FaturaDTO>? t)> GetAll()
        {
            try
            {
                var data = await query.FaturaRepository.GetAllAsync();
                return (true, data.Count() > 0 ? $"{data.Count()} Encontrados" : "Sem registros na base", mapper.Map<List<FaturaDTO>>(data));
            }
            catch (Exception ex)
            {

                return (false, ex.Message, null);
            }

        }

        public async Task<(bool Success, string Message, FaturaDTO t)> GetById(Guid id)
        {
            try
            {
                Fatura data = await query.FaturaRepository.GetByIdAsync(id);
                return (true,data is null ?  "Sem registros na base":"", mapper.Map<FaturaDTO>(data));
            }
            catch (Exception ex)
            {

                return (false, ex.Message, null);
            }
        }
    }
}
