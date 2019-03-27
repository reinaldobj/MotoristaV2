using Microsoft.AspNetCore.Mvc;

namespace Motorista.WebApi.Requests.Motorista
{
    /// <summary>
    /// Classe de Request do Get de Motorista
    /// </summary>
    public class MotoristaGetRequest
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
