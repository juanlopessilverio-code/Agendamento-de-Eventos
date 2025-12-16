using EventosTeste.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventosTeste.Interfaces
{
    public interface ILocaisRepository
    {
        Task<IEnumerable<Local>> GetAll();
        Task<Local> GetById(int id);
        Task Add(Local local);
        Task Update(Local local);
        Task Delete(int id);
    }
}
