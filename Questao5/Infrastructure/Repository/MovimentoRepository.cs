using Microsoft.EntityFrameworkCore;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Context;
using Questao5.Infrastructure.Repository.Interface;

namespace Questao5.Infrastructure.Repository
{
    public class MovimentoRepository : IMovimentoRepository
    {
        private readonly Q5Context _context;
        
        public MovimentoRepository(Q5Context context)
        {
            _context = context;
        }
        
        public async Task<Movimento> AddMovimento(Movimento movimento)
        {
            var result = await _context.AddAsync(movimento);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<Movimento>> SomaMovimento(string idCorrente)
        {
            return await _context.Movimento.Where(x => x.IdContaCorrente == idCorrente).ToListAsync();
        }
    }
}