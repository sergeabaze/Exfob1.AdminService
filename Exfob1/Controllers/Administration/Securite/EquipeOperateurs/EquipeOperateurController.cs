using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Exfob1.Models.Adminstrations;
using Exfob1.Conventions;
using Exfob1.Models;
namespace Exfob1.Controllers.Administration
{	[Route("api/equipeoperateurs")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class EquipeOperateurController : ControllerBase
	{

		private readonly IEquipeOperateurBLL _equipeoperateurBLL;
		private readonly ILogger<EquipeOperateurController> _logger;
		public EquipeOperateurController(IEquipeOperateurBLL equipeoperateurBLL, ILogger<EquipeOperateurController> logger)
		{
			_equipeoperateurBLL = equipeoperateurBLL ?? throw new ArgumentNullException(nameof(equipeoperateurBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<EquipeOperateurListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _equipeoperateurBLL.ObtenireEquipeOperateurListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id equipeoperateur</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<EquipeOperateurReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _equipeoperateurBLL.ObtenireEquipeOperateurParId(id)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de création
		/// </summary>
		/// <param name="request">objet</param>
		/// <returns>objet créer</returns>
		[HttpPost("creation")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<EquipeOperateurReponse>>> CreationAsync([FromBody] EquipeOperateurRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<EquipeOperateurReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _equipeoperateurBLL.CreationEquipeOperateur(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="equipeoperateurid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{equipeoperateurid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<EquipeOperateurReponse>>> MisejourAsync(int equipeoperateurid, [FromBody] EquipeOperateurEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<EquipeOperateurReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _equipeoperateurBLL.MisejourEquipeOperateur(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="equipeoperateurid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{equipeoperateurid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<EquipeOperateurReponse>>> SuppressionAsync(int equipeoperateurid)
		{
			var response = await _equipeoperateurBLL.SuppressionEquipeOperateur(equipeoperateurid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
