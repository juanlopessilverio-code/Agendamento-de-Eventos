using EventosTeste.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EventosTeste.Data
{
    public class DbContextEventos : DbContext
    {
        public DbContextEventos(DbContextOptions<DbContextEventos> options) : base(options)
        {
        }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Local> Local { get; set; }
    }
}
