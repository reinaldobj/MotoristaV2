using System.ComponentModel.DataAnnotations;

namespace Motorista.Domain.Models
{
    public class Motorista
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string UltimoNome { get; set; }

        public Endereco Endereco { get; set; }

        public Carro Carro { get; set; }
    }
}
