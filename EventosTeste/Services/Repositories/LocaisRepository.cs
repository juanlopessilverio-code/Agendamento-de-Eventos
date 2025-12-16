using EventosTeste.Data;
using EventosTeste.Interfaces;
using EventosTeste.Models;
using Microsoft.EntityFrameworkCore;

namespace EventosTeste.Repository
{
    public class LocaisRepository : ILocaisRepository
    {
        private readonly DbContextEventos _context;

        public LocaisRepository(DbContextEventos context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Local>> GetAll()
        {          
           return await _context.Local.ToListAsync(); 
        }
  
        public async Task<Local> GetById(int id)
        {
              return await _context.Local.FirstOrDefaultAsync(l => l.IdLocal == id);
        }
        
        public async Task Add(Local local)
        {
            _context.Local.Add(local);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Local local)
        {
            _context.Local.Update(local);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await GetById(id);
            if (item != null)
            {
                _context.Local.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
