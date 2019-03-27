using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Motorista.WebApi.Requests.Motorista
{
    /// <summary>
    /// Request de Get List de Motorista
    /// </summary>
    public class MotoristaGetListRequest
    {
        /// <summary>
        /// Nome do motorista
        /// </summary>
        [FromRoute(Name = "nome")]
        public string Nome { get; set; }
    }
}