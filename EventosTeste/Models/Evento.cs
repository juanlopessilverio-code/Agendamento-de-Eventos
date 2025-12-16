using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventosTeste.Models
{
    public class Evento
    {
        [Key]
        public int IdEvento { get; set; }
        public string Nome_Evento { get; set; }
        public string Descricao { get; set; }
        public DateTime Data_Inicial { get; set; }
        public DateTime Data_Final { get; set; }
        public int Local { get; set; }
        public bool Status { get; set; }

        [NotMapped]
        public string? NomeLocal { get; set; }
    }
}
