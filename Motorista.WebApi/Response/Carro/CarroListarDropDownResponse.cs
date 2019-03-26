using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motorista.WebApi.Response.Carro
{
    public class CarroListarDropDownResponse
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public int Valor { get; set; }

        /// <summary>
        /// Texto a ser exibido
        /// </summary>
        public string Descricao { get; set; }
    }
}
