using Microsoft.AspNetCore.Mvc;

namespace Motorista.WebApi.Requests.Motorista
{
    /// <summary>
    ///  Classe de Request de Delete de Motorista
    /// </summary>
    public class MotoristaDeleteRequest
    {
        /// <summary>
        /// Id do motorista
        /// </summary>
        [FromRoute(Name = "id")]
        public int Id {
            get; set;
        }
    }
}
