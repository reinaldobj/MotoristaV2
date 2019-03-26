using System;
using System.Collections.Generic;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Motorista.Application.Carro.Commands.AtualizarCarro;
using Motorista.Application.Carro.Commands.CriarCarro;
using Motorista.Application.Carro.Commands.ExcluirCarro;
using Motorista.Application.Carro.Queries.ListarCarros;
using Motorista.Application.Carro.Queries.ObterCarro;
using Motorista.WebApi.Requests.Carro;
using Motorista.WebApi.Response.Carro;

namespace Motorista.WebApi.Controllers
{
    /// <summary>
    /// API de carros
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly ICriarCarroCommand criarCarro;
        private readonly IAtualizarCarroCommand atualizarCarro;
        private readonly IExcluirCarroCommand carroCommand;
        private readonly IObterCarrosQuery obterCarros;
        private readonly IListarCarrosQuery listarCarros;

        /// <summary>
        /// Construtor da Classe
        /// </summary>
        /// <param name="criarCarro"></param>
        /// <param name="atualizarCarro"></param>
        /// <param name="carroCommand"></param>
        /// <param name="obterCarros"></param>
        /// <param name="listarCarros"></param>
        public CarroController(
            ICriarCarroCommand criarCarro,
            IAtualizarCarroCommand atualizarCarro,
            IExcluirCarroCommand carroCommand,
            IObterCarrosQuery obterCarros,
            IListarCarrosQuery listarCarros)
        {
            this.criarCarro = criarCarro;
            this.atualizarCarro = atualizarCarro;
            this.carroCommand = carroCommand;
            this.obterCarros = obterCarros;
            this.listarCarros = listarCarros;
        }

        /// <summary>
        /// Lista todos os carros cadastrado
        /// </summary>
        /// <returns>Lista de carros</returns>
        [HttpGet("[action]")]
        public IActionResult Listar(CarroGetRequest request)
        {
            try {
                IEnumerable<Application.ViewModel.CarroViewModel> carros = listarCarros.Execute(request.Modelo);

                return Ok(carros);
            }
            catch (Exception ex) {
                new TelemetryClient().TrackException(ex);
                return BadRequest("Ocorreu um erro ao listar carros");
            }
        }

        /// <summary>
        /// Lista todos os carros cadastrado
        /// </summary>
        /// <returns>Lista de carros</returns>
        [HttpGet("[action]")]
        public IActionResult ListarDropDown()
        {
            try {
                IEnumerable<Application.ViewModel.CarroViewModel> carros = listarCarros.Execute(null);

                var carrosDropdownOptions = new List<CarroListarDropDownResponse>();

                foreach (Application.ViewModel.CarroViewModel item in carros) {
                    var carroListarDropDownResponse = new CarroListarDropDownResponse {
                        Descricao = $"{item.Modelo} - {item.Placa}",
                        Valor = item.Id
                    };
                }

                return Ok(carros);
            }
            catch (Exception ex) {
                new TelemetryClient().TrackException(ex);
                return BadRequest("Ocorreu um erro ao listar carros");
            }
        }
    }
}