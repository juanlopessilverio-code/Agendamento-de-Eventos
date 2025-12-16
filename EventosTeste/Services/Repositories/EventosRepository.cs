using EventosTeste.Data;
using EventosTeste.Interfaces;
using EventosTeste.Models;
using Microsoft.EntityFrameworkCore;

namespace EventosTeste.Repository
{
    public class EventosRepository : IEventosRepository
    {
        private readonly DbContextEventos _context;

        public EventosRepository(DbContextEventos context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evento>> GetAll() 
        {
            return await _context.Eventos.ToListAsync();
        }

        public async Task<Evento> GetById(int id) 
        {
            return await _context.Eventos.FirstOrDefaultAsync(e => e.IdEvento == id);
        }

        public async Task Add(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Evento evento)
        {
            _context.Eventos.Update(evento);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await GetById(id);
            if (item != null)
            {
                _context.Eventos.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
