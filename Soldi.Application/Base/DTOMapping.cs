using AutoMapper;
using Soldi.Application.Commands.Conta;
using Soldi.Application.DTO;
using Soldi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldi.Application.Base
{
    public class DTOMapping:Profile
    {
        public DTOMapping()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Cartao, CartaoDTO>().ReverseMap();

            CreateMap<Conta, ContaDTO>();
            CreateMap<ContaAdicionarCommand, Conta>();
            CreateMap<ContaAtualizarCommand, Conta>();


            CreateMap<Fatura, FaturaDTO>().ReverseMap();
            CreateMap<Lancamento, LancamentoDTO>().ReverseMap();
            CreateMap<LancamentoRecorrente, LancamentoRecorrenteDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        }
    }
}
