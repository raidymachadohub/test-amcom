using Questao5.Domain.Entities;
using Questao5.Domain.Enum;
using Questao5.FlowControls;
using Questao5.Infrastructure.Repository.Interface;
using Questao5.Services.Interfaces;

namespace Questao5.Services
{
    public class MovimentoService : IMovimentoService
    {
        private readonly IMovimentoRepository _repository;
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public MovimentoService(IMovimentoRepository repository, IContaCorrenteRepository contaCorrenteRepository)
        {
            _repository = repository;
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public async Task<Movimento> InsereMovimento(Movimento movimento)
        {
            var contaCorrente = await _contaCorrenteRepository.ValidaContaCorrente(movimento.IdContaCorrente);

            if (contaCorrente == null)
                throw new CustomException(SimpleResult.Fail(ContaCorrenteNegocio.INVALID_ACCOUNT, "Conta Inválida"));

            if (!contaCorrente.Ativo)
                throw new CustomException(SimpleResult.Fail(ContaCorrenteNegocio.INACTIVE_ACCOUNT, "Conta Inativa"));

            if (movimento.Valor < 0)
                throw new CustomException(SimpleResult.Fail(ContaCorrenteNegocio.INVALID_VALUE, "Valor informado inválido"));

            if (!IsTipoMovimento(movimento.TipoMovimento))
                throw new CustomException(SimpleResult.Fail(ContaCorrenteNegocio.INVALID_TYPE, "Tipo do movimento inválido"));

            return await _repository.AddMovimento(movimento);
        }

        public async Task<IEnumerable<Movimento>> SomaMovimento(string idCorrente)
        {
            return await _repository.SomaMovimento(idCorrente);
        }
        private bool IsTipoMovimento(string movimento)
        {
            return movimento switch
            {
                "D" => true,
                "C" => true,
                _ => false
            };
        }
    }
}