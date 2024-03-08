using Questao5.Domain.Entities;
using Questao5.Infrastructure.Context;
using Questao5.Infrastructure.Repository.Interface;

namespace Questao5.Infrastructure.Repository
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly Q5Context _context;

        public ContaCorrenteRepository(Q5Context context)
        {
            _context = context;
        }
        
        public async Task<ContaCorrente> ValidaContaCorrente(string idContaCorrente)
        {
            return await _context.ContaCorrente.FindAsync(idContaCorrente);
        }

        public async Task<ContaCorrente> SaldoConta(string idContaCorrente)
        {
            return await _context.ContaCorrente.FindAsync(idContaCorrente);
        }
    }
}