using AutoMapper;
using Soldi.Application.Commands;
using Soldi.Application.DTO;
using Soldi.Core.Base;
using Soldi.Core.Entities;
using Soldi.Core.Enums;


namespace Soldi.Application.Handlers
{
    public class CartaoCommandHandler : ICommandHandler<CartaoAdicionarCommand>, ICommandHandler<CartaoAtualizarCommand>
    {
        private IUnitOfWork _uow;

        public CartaoCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }



        public async Task<(bool, string)> Handle(CartaoAdicionarCommand command)
        {
            try
            {

                var conta = new Cartao(
                    usuarioId: command.usuarioId,
                    contaPagamentoPadrao: command.contaPagamentoPadrao,
                    diaFechamento: command.diaFechamento,
                    diaVencimento: command.diaVencimento,
                    nome: command.nome,
                    imagem: command.imagem);

                var result = conta.Validar();
                if (result.status == false) return result;


                _uow.CartaoRepository.Create(conta);
                return await _uow.Commit();
            }
            catch (Exception ex)
            {

                return (false, ex.Message + "\n\n" + ex.StackTrace);
            }


        }

        public async Task<(bool Success, string Message)> Handle(CartaoAtualizarCommand command)
        {
            try
            {
                var conta = await _uow.CartaoRepository.GetByIdAsync(command.id);
                if (conta != null)
                {
                    conta.Atualizar(
                                  contaPagamentoPadrao: command.contaPagamentoPadrao,
                                  diaFechamento: command.diaFechamento,
                                  diaVencimento: command.diaVencimento,
                                  nome: command.nome,
                                  imagem: command.imagem
                                  );

                    var result = conta.Validar();
                    if (result.status == false) return result;


                    _uow.CartaoRepository.Update(conta);
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
