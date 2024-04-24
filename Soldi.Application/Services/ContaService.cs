using AutoMapper;
using Soldi.Application.DTO;
using Soldi.Core.Base;
using Soldi.Core.Entities;


namespace Soldi.Application.Services
{
    public class ContaService: IService<ContaDTO>
    {
        private IMapper _mapper;
        private IUnitOfWork _uow;

        public ContaService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<(bool,string)> Adicionar(ContaDTO dto)
        {
            var conta = _mapper.Map<Conta>(dto);
            var result = conta.Validar();
            if (result.status==false)
            {
                return result; 
            }

            _uow.ContaRepository.Create(conta);
         return  await _uow.Commit();
        }

    }
}
