using AutoMapper;
using Soldi.Application.Commands;
using Soldi.Application.DTO;
using Soldi.Core.Base;
using Soldi.Core.Entities;
using Soldi.Core.Enums;


namespace Soldi.Application.Handlers
{
    public class FaturaCommandHandler : ICommandHandler<FaturaAdicionarCommand>, ICommandHandler<FaturaAtualizarCommand>
    {
        private IUnitOfWork _uow;

        public FaturaCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }



        public async Task<(bool, string)> Handle(FaturaAdicionarCommand command)
        {
            try
            {

                var conta = new Fatura(
                    usuarioId: command.usuarioId,
                    descricao: command.descricao,
                    valor: command.valor,
                    datainicial:command.dataInicial,
                    cartaoId: command.cartaoId,
                    categoriaId: command.categoriaId,
                    observacoes: command.observacoes);

                var result = conta.Validar();
                if (result.status == false) return result;


                _uow.FaturaRepository.Create(conta);
                return await _uow.Commit();
            }
            catch (Exception ex)
            {

                return (false, ex.Message + "\n\n" + ex.StackTrace);
            }


        }

        public async Task<(bool Success, string Message)> Handle(FaturaAtualizarCommand command)
        {
            try
            {
                var conta = await _uow.FaturaRepository.GetByIdAsync(command.id);
                if (conta != null)
                {
                    conta.Atualizar(
                                   descricao: command.descricao,
                    valor: command.valor,
                    datainicial: command.datainicial,
                    cartaoId: command.cartaoId,
                    categoriaId: command.categoriaId,
                    observacoes: command.observacoes);

                    var result = conta.Validar();
                    if (result.status == false) return result;


                    _uow.FaturaRepository.Update(conta);
                    return await _uow.Commit();
                }
                return (false, "Não encontrado!");
            }
            catch (Exception ex)
            {

                return (false, ex.Message + "\n\n" + ex.StackTrace);
            }

        }


    }
}
