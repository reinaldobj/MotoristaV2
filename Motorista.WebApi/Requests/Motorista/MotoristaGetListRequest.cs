using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        [MinLength(0)]
        public string Nome { get; set; }
    }
}