using AutoMapper;
using Soldi.Application.Commands;
using Soldi.Application.DTO;
using Soldi.Core.Base;
using Soldi.Core.Entities;
using Soldi.Core.Enums;


namespace Soldi.Application.Handlers
{
    public class LancamentoRecorrenteCommandHandler : ICommandHandler<LancamentoRecorrenteAdicionarCommand>, ICommandHandler<LancamentoRecorrenteAtualizarCommand>
    {
        private IUnitOfWork _uow;

        public LancamentoRecorrenteCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }



        public async Task<(bool, string)> Handle(LancamentoRecorrenteAdicionarCommand command)
        {
            try
            {

                var conta = new LancamentoRecorrente(
                    usuarioId: command.usuarioId,
                    descricao: command.descricao,
                    valor: command.valor,
                    datainicial: command.datainicial,
                    contaId: command.contaId,
                    tipoLancamento: command.tipoLancamento,
                    observacoes: command.observacoes,
                    categoriaId: command.categoriaId);

                var result = conta.Validar();
                if (result.status == false) return result;


                _uow.LancamentoRecorrenteRepository.Create(conta);
                return await _uow.Commit();
            }
            catch (Exception ex)
            {

                return (false, ex.Message + "\n\n" + ex.StackTrace);
            }


        }

        public async Task<(bool Success, string Message)> Handle(LancamentoRecorrenteAtualizarCommand command)
        {
            try
            {
                var conta = await _uow.LancamentoRecorrenteRepository.GetByIdAsync(command.id);
                if (conta != null)
                {
                    conta.Atualizar(
                                    descricao: command.descricao,
                                    valor: command.valor,
                                    datainicial: command.datainicial,
                                    contaId: command.contaId,
                                    tipoLancamento: command.tipoLancamento,
                                    observacoes: command.observacoes,
                                    categoriaId: command.categoriaId
                                  );

                    var result = conta.Validar();
                    if (result.status == false) return result;


                    _uow.LancamentoRecorrenteRepository.Update(conta);
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
