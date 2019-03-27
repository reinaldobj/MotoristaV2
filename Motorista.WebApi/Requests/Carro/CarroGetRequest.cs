using Microsoft.AspNetCore.Mvc;

namespace Motorista.WebApi.Requests.Carro
{
    /// <summary>
    /// Entidade de Request do Get de Carros
    /// </summary>
    public class CarroGetRequest
    {
        /// <summary>
        /// Nome do Carro
        /// </summary>
        [FromRoute(Name = "nome")]
        public string Modelo {
            get; set;
        }
    }
}
