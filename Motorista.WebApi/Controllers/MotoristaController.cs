using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Motorista.Application.Motorista.Commands.AtualizarMotorista;
using Motorista.Application.Motorista.Commands.CriarMotorista;
using Motorista.Application.Motorista.Commands.ExcluirMotorista;
using Motorista.Application.Motorista.Queries.ListarMotoristas;
using Motorista.Application.Motorista.Queries.ObterMotorista;
using Motorista.Application.ViewModel;
using Motorista.Domain.Enum;
using Motorista.WebApi.Requests.Motorista;

namespace Motorista.WebApi.Controllers
{
    /// <summary>
    /// API de Motorista
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MotoristaController : ControllerBase
    {
        private readonly ICriarMotoristaCommand criarMotorista;
        private readonly IAtualizarMotoristaCommand atualizarMotorista;
        private readonly IExcluirMotoristaCommand excluirMotorista;
        private readonly IObterMotoristaQuery obterMotorista;
        private readonly IListarMotoristasQuery listarMotoristas;

        /// <summary>
        /// Construtor da Classe
        /// </summary>
        /// <param name="criarMotorista"></param>
        /// <param name="atualizarMotorista"></param>
        /// <param name="excluirMotorista"></param>
        /// <param name="obterMotorista"></param>
        /// <param name="listarMotoristas"></param>
        public MotoristaController(
            ICriarMotoristaCommand criarMotorista,
            IAtualizarMotoristaCommand atualizarMotorista,
            IExcluirMotoristaCommand excluirMotorista,
            IObterMotoristaQuery obterMotorista,
            IListarMotoristasQuery listarMotoristas)
        {
            this.criarMotorista = criarMotorista;
            this.atualizarMotorista = atualizarMotorista;
            this.excluirMotorista = excluirMotorista;
            this.obterMotorista = obterMotorista;
            this.listarMotoristas = listarMotoristas;
        }

        /// <summary>
        /// Retorna o cadastro de um motorista
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Motorista</returns>
        [HttpGet("{id:int}")]
        public ActionResult<MotoristaViewModel> ObterPorId([FromQuery]MotoristaGetRequest request)
        {
            MotoristaViewModel motorista = obterMotorista.Execute(request.Id);

            return motorista != null ? motorista : (ActionResult<MotoristaViewModel>)NotFound();
        }

        /// <summary>
        /// Lista todos os motoristas cadastrado
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Lista de motorista</returns>
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<MotoristaViewModel>> Listar([FromQuery]MotoristaGetListRequest request)
        {
            try {
                IEnumerable<MotoristaViewModel> motoristas = listarMotoristas.Execute(request.Nome, CampoOrdenacaoEnum.Nenhum);

                return Ok(motoristas);
            }
            catch (Exception ex) {
                new TelemetryClient().TrackException(ex);
                string mensagem = $"Ocorreu um erro ao listar motoristas";

                return BadRequest(mensagem);
            }
        }

        /// <summary>
        /// Retorna lista de motorista ordenada pelo nome
        /// </summary>
        /// <returns>Lista ordenada de motoristas</returns>
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<MotoristaViewModel>> ListarOrdenadoPorNome()
        {
            try {
                IEnumerable<MotoristaViewModel> motoristas = listarMotoristas.Execute(ordenacao: CampoOrdenacaoEnum.Nome);

                return Ok(motoristas);
            }
            catch (Exception ex) {
                new TelemetryClient().TrackException(ex);
                string mensagem = $"Ocorreu um erro ao listar motoristas";

                return BadRequest(mensagem);
            }
        }

        /// <summary>
        /// Retorna lista de motorista ordenada pelo último nome
        /// </summary>
        /// <returns>Lista ordenada de motoristas</returns>
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<MotoristaViewModel>> ListarOrdenadoPorUltimoNome()
        {
            try {
                IEnumerable<MotoristaViewModel> motoristas = listarMotoristas.Execute(ordenacao: CampoOrdenacaoEnum.UltimoNome);

                return Ok(motoristas);
            }
            catch (Exception ex) {
                new TelemetryClient().TrackException(ex);

                string mensagem = $"Ocorreu um erro ao listar motoristas";

                return BadRequest(mensagem);
            }
        }

        /// <summary>
        /// Cadastra um novo motorista
        /// </summary>
        /// <param name="motorista">Motorista que será cadastrado</param>
        /// <returns>Motorista cadastrado</returns>
        [HttpPost]
        [ProducesResponseType(typeof(MotoristaViewModel), 201)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public async Task<ActionResult> Incluir([FromBody]MotoristaViewModel motorista)
        {
            try {
                if (ModelState.IsValid) {
                    await criarMotorista.Execute(motorista);

                    return Created($"/api/motorista/{motorista.Id}", motorista);
                }
                else {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex) {
                new TelemetryClient().TrackException(ex);

                string mensagem = $"Ocorreu um erro ao salvar o motorista";

                return BadRequest(mensagem);
            }
        }

        /// <summary>
        /// Atualiza o cadastro de um motorista
        /// </summary>
        /// <param name="motorista">Motorista a ser atualizado</param>
        /// <returns>Indica se o motorista foi encontrado na base para ser atualizado</returns>
        [HttpPut]
        public async Task<ActionResult<MotoristaViewModel>> Alterar([FromBody]MotoristaViewModel motorista)
        {
            try {

                if (ModelState.IsValid) {

                    bool motoristaExiste = obterMotorista.Execute(motorista.Id) != null;

                    if (motoristaExiste) {
                        atualizarMotorista.Execute(motorista);

                        return Ok();
                    }
                    else {
                        return NotFound();
                    }
                }
                else {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex) {
                new TelemetryClient().TrackException(ex);

                string mensagem = $"Ocorreu um erro ao salvar o motorista";

                return BadRequest(mensagem);
            }
        }

        /// <summary>
        /// Exclui o cadastro de um motorista
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Indica se o motorista foi encontrado para ser excluído</returns>
        [HttpDelete("{id:int}")]
        public ActionResult Excluir([FromQuery]MotoristaDeleteRequest request)
        {
            try {
                bool motoristaExiste = obterMotorista.Execute(request.Id) != null;

                if (motoristaExiste) {
                    excluirMotorista.Execute(request.Id);

                    return Ok();
                }
                else {
                    return NotFound();
                }
            }
            catch (Exception ex) {
                new TelemetryClient().TrackException(ex);

                string mensagem = $"Ocorreu um erro ao excluir o motorista";

                return BadRequest(mensagem);
            }
        }
    }
}