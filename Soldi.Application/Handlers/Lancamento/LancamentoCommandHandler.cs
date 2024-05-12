using AutoMapper;
using Soldi.Application.Commands;
using Soldi.Application.DTO;
using Soldi.Core.Base;
using Soldi.Core.Entities;
using Soldi.Core.Enums;


namespace Soldi.Application.Handlers
{
    public class LancamentoCommandHandler : ICommandHandler<LancamentoAdicionarCommand>, ICommandHandler<LancamentoAtualizarCommand>
    {
        private IUnitOfWork _uow;

        public LancamentoCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }



        public async Task<(bool, string)> Handle(LancamentoAdicionarCommand command)
        {
            try
            {

                var conta = new Lancamento(
                    usuarioId: command.usuarioId,
                    descricao:command.descricao,
                    parcela:command.parcela,
                    valor:command.valor,
                    datainicial:command.datainicial,
                    contaId:command.contaId,
                    tipoLancamento:command.tipoLancamento,
                    observacoes:command.observacoes,
                    lancamentoRecorrenteId:command.lancamentoRecorrenteId,
                    categoriaId:command.categoriaId
                    
                    );

                var result = conta.Validar();
                if (result.status == false) return result;


                _uow.LancamentoRepository.Create(conta);
                return await _uow.Commit();
            }
            catch (Exception ex)
            {

                return (false, ex.Message + "\n\n" + ex.StackTrace);
            }


        }

        public async Task<(bool Success, string Message)> Handle(LancamentoAtualizarCommand command)
        {
            try
            {
                var conta = await _uow.LancamentoRepository.GetByIdAsync(command.id);
                if (conta != null)
                {
                    conta.Atualizar(
                                    descricao: command.descricao,
                                    parcela: command.parcela,
                                    valor: command.valor,
                                    datainicial: command.datainicial,
                                    contaId: command.contaId,
                                    tipoLancamento: command.tipoLancamento,
                                    observacoes: command.observacoes,
                                    lancamentoRecorrenteId: command.lancamentoRecorrenteId,
                                    categoriaId: command.categoriaId
                                  );

                    var result = conta.Validar();
                    if (result.status == false) return result;


                    _uow.LancamentoRepository.Update(conta);
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
