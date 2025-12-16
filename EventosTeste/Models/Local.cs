using System.ComponentModel.DataAnnotations;

namespace EventosTeste.Models
{
    public class Local
    {
        [Key]
        public int IdLocal { get; set; }
        public string Nome { get; set; }
        public string Cep { get; set; }
    }
}
