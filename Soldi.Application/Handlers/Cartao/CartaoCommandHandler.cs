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

            var conta = new Cartao(
                usuarioId: command.usuarioId,
                contaPagamentoPadrao:command.contaPagamentoPadrao,
                diaFechamento:command.diaFechamento,
                diaVencimento:command.diaVencimento,
                nome: command.nome,
                imagem: command.imagem);

            var result = conta.Validar();
            if (result.status == false) return result;


            _uow.CartaoRepository.Create(conta);
            return await _uow.Commit();

        }

        public async Task<(bool Success, string Message)> Handle(CartaoAtualizarCommand command)
        {
            var conta = await _uow.CartaoRepository.GetByIdAsync(command.id);
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

       
    }
}
