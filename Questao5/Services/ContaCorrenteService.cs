using Questao5.Domain.Entities;
using Questao5.Domain.Enum;
using Questao5.FlowControls;
using Questao5.Infrastructure.Repository.Interface;
using Questao5.Services.Interfaces;

namespace Questao5.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly IContaCorrenteRepository _repository;
        private readonly IMovimentoRepository _movimentoRepository;
        
        public ContaCorrenteService(IContaCorrenteRepository repository, IMovimentoRepository movimentoRepository)
        {
            _repository = repository;
            _movimentoRepository = movimentoRepository;
        }
     
        public async Task<ContaCorrente> ValidaContaCorrente(string idContaCorrente)
        {
            return await _repository.ValidaContaCorrente(idContaCorrente);
        }

        public async Task<ContaCorrente> SaldoConta(string idContaCorrente)
        {
            var contaCorrente = await ValidaContaCorrente(idContaCorrente);

            if (contaCorrente == null)
                throw new CustomException(SimpleResult.Fail(ContaCorrenteNegocio.INVALID_ACCOUNT, "Conta Inválida"));

            contaCorrente.SaldoAtual = await CalculaMovimento(contaCorrente.IdContaCorrente);
            return contaCorrente;
        }

        private async Task<double> CalculaMovimento(string idCorrente)
        {
            var totalMovimento = await _movimentoRepository.SomaMovimento(idCorrente);

            var credito = totalMovimento.Where(tm => tm.TipoMovimento == "C").Sum(x => x.Valor);
            var debito = totalMovimento.Where(tm => tm.TipoMovimento == "D").Sum(x => x.Valor);

            return credito - debito;
        }
    }
}