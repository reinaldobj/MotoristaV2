using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
