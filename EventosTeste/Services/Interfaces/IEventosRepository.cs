using EventosTeste.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventosTeste.Interfaces
{
    public interface IEventosRepository
    {
        Task<IEnumerable<Evento>> GetAll();
        Task<Evento> GetById(int id);
        Task Add(Evento evento);
        Task Update(Evento evento);
        Task Delete(int id);
    }
}
