using Questao5.Domain.DTO;
using Questao5.Domain.Entities;
using AutoMapper;

namespace Questao5.Domain.Mappings
{
    public class MovimentoProfile : Profile
    {
        public MovimentoProfile()
        {
            CreateMap<MovimentoDTO, Movimento>()
                .ForMember(x => x.IdContaCorrente, opt => opt.MapFrom(src => src.IdContaCorrente))
                .ForMember(x => x.Valor, opt => opt.MapFrom(src => src.Valor))
                .ForMember(x => x.TipoMovimento, opt => opt.MapFrom(src => src.TipoMovimento))
                .ForMember(x => x.DataMovimento, opt => opt.MapFrom(src => src.DataMovimento))
                .ForMember(x => x.IdMovimento, opt => opt.MapFrom(src => src.IdMovimento))
                .ReverseMap();
        }
    }
}

