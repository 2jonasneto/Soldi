using AutoMapper;
using Soldi.Application.Commands;
using Soldi.Application.DTO;
using Soldi.Core.Base;
using Soldi.Core.Entities;
using Soldi.Core.Enums;


namespace Soldi.Application.Handlers
{
    public class UsuarioCommandHandler : ICommandHandler<UsuarioAdicionarCommand>, ICommandHandler<UsuarioAtualizarCommand>, ICommandHandler<AlterarSenhaCommand>
    {
        private IUnitOfWork _uow;

        public UsuarioCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }



        public async Task<(bool, string)> Handle(UsuarioAdicionarCommand command)
        {

            var conta = new Usuario(
                usuarioId: Guid.Empty,
                email:command.email,
                dataNascimento: command.dataNascimento,
                nome: command.nome,
                senha:command.senha
                );

            var result = conta.Validar();
            if (result.status == false) return result;


            _uow.UsuarioRepository.Create(conta);
            return await _uow.Commit();

        }

        public async Task<(bool Success, string Message)> Handle(UsuarioAtualizarCommand command)
        {
            var conta = await _uow.UsuarioRepository.GetByIdAsync(command.id);
            if (conta != null)
            {
                conta.Atualizar(
                email: command.email,
                dataNascimento: command.dataNascimento,
                nome: command.nome
                              );

                var result = conta.Validar();
                if (result.status == false) return result;


                _uow.UsuarioRepository.Update(conta);
                return await _uow.Commit();
            }
            return (false, "Não encontrado!");
        }

        public async Task<(bool Success, string Message)> Handle(AlterarSenhaCommand command)
        {
            var conta = await _uow.UsuarioRepository.GetByIdAsync(command.id);
            if (conta != null)
            {
                conta.AlterarSenha(senha:command.senha);

                var result = conta.Validar();
                if (result.status == false) return result;


                _uow.UsuarioRepository.Update(conta);
                return await _uow.Commit();
            }
            return (false, "Não encontrado!");
        }


    }
}
