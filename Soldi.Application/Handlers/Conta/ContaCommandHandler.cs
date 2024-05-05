using AutoMapper;
using Soldi.Application.Commands;
using Soldi.Application.Commands;
using Soldi.Application.DTO;
using Soldi.Core.Base;
using Soldi.Core.Entities;
using Soldi.Core.Enums;
using System.Linq.Expressions;


namespace Soldi.Application.Handlers
{
    public class ContaCommandHandler : ICommandHandler<ContaAdicionarCommand>, ICommandHandler<ContaAtualizarCommand>
    {
        private IMapper _mapper;
        private IUnitOfWork _uow;

        public ContaCommandHandler(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }



        public async Task<(bool, string)> Handle(ContaAdicionarCommand command)
        {
            try
            {
                var conta = new Conta(
                            usuarioId: command.usuarioId,
                            nome: command.nome,
                            saldo: command.saldo,
                            imagem: command.imagem,
                            tipoConta: (ETipoConta)command.tipoConta);

                var result = conta.Validar();
                if (result.status == false) return result;


                _uow.ContaRepository.Create(conta);
                return await _uow.Commit();
            }
            catch (Exception ex)
            {

                return (false, ex.Message + "\n\n" + ex.StackTrace);
            }



        }

        public async Task<(bool Success, string Message)> Handle(ContaAtualizarCommand command)
        {
            try
            {
                var conta = await _uow.ContaRepository.GetByIdAsync(command.id);
                conta.Atualizar(
                    nome: command.nome,
                    imagem: command.imagem,
                    tipoConta: (ETipoConta)command.tipoConta);

                var result = conta.Validar();
                if (result.status == false) return result;


                _uow.ContaRepository.Update(conta);
                return await _uow.Commit();
            }
            catch (Exception ex)
            {

                return (false, ex.Message + "\n\n" + ex.StackTrace);
            }

        }

        public async Task<(bool Success, string Message)> Handle(ContaRetiradaCommand command)
        {
            try
            {
                var conta = await _uow.ContaRepository.GetByIdAsync(command.id);
                conta.RetiradaSaldo(saldo: command.saldo);

                var result = conta.Validar();
                if (result.status == false) return result;


                _uow.ContaRepository.Update(conta);
                return await _uow.Commit();
            }
            catch (Exception ex)
            {

                return (false, ex.Message + "\n\n" + ex.StackTrace);
            }

        }

        public async Task<(bool Success, string Message)> Handle(ContaDepositoCommand command)
        {
            try
            {
                var conta = await _uow.ContaRepository.GetByIdAsync(command.id);
                conta.DepositoSaldo(saldo: command.saldo);

                var result = conta.Validar();
                if (result.status == false) return result;


                _uow.ContaRepository.Update(conta);
                return await _uow.Commit();
            }
            catch (Exception ex)
            {

                return (false, ex.Message + "\n\n" + ex.StackTrace);
            }

        }
        public async Task<(bool Success, string Message)> Handle(ContaDefinirSaldoCommand command)
        {
            try
            {
                var conta = await _uow.ContaRepository.GetByIdAsync(command.id);
                conta.DefinirSaldo(saldo: command.saldo);

                var result = conta.Validar();
                if (result.status == false) return result;


                _uow.ContaRepository.Update(conta);
                return await _uow.Commit();
            }
            catch (Exception ex)
            {

                return (false, ex.Message + "\n\n" + ex.StackTrace);
            }

        }
    }
}
