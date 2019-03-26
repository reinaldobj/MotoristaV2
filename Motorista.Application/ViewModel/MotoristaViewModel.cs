using System.ComponentModel.DataAnnotations;

namespace Motorista.Application.ViewModel
{
    /// <summary>
    /// Model de Motorista
    /// </summary>
    public class MotoristaViewModel
    {
        /// <summary>
        /// Identificador do motorista
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Primeiro nome
        /// </summary>
        [Required(ErrorMessage = "Nome do motorista é obrigatório")]
        public string Nome { get; set; }

        /// <summary>
        /// Ultimo nome
        /// </summary>
        [Required(ErrorMessage = "Último nome do motorista é obrigatório")]
        public string UltimoNome { get; set; }

        /// <summary>
        /// Carro
        /// </summary>
        [Required(ErrorMessage = "Carro do motorista é obrigatório")]
        public int IdCarro { get; set; }

        /// <summary>
        /// Endereço do motorista
        /// </summary>
        public EnderecoViewModel Endereco { get; set; }
        /// <summary>
        /// Retorna o Nome e Sobrenome do motorista
        /// </summary>
		public string NomeCompleto => $"{Nome} {UltimoNome}";
    }
}
