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
{	[Route("api/contratfournisseurs")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class ContratFournisseurController : ControllerBase
	{

		private readonly IContratFournisseurBLL _contratfournisseurBLL;
		private readonly ILogger<ContratFournisseurController> _logger;
		public ContratFournisseurController(IContratFournisseurBLL contratfournisseurBLL, ILogger<ContratFournisseurController> logger)
		{
			_contratfournisseurBLL = contratfournisseurBLL ?? throw new ArgumentNullException(nameof(contratfournisseurBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<ContratFournisseurListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _contratfournisseurBLL.ObtenireContratFournisseurListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id contratfournisseur</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<ContratFournisseurReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _contratfournisseurBLL.ObtenireContratFournisseurParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<ContratFournisseurReponse>>> CreationAsync([FromBody] ContratFournisseurRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ContratFournisseurReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _contratfournisseurBLL.CreationContratFournisseur(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="contratfournisseurid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{contratfournisseurid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ContratFournisseurReponse>>> MisejourAsync(int contratfournisseurid, [FromBody] ContratFournisseurEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ContratFournisseurReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _contratfournisseurBLL.MisejourContratFournisseur(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="contratfournisseurid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{contratfournisseurid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ContratFournisseurReponse>>> SuppressionAsync(int contratfournisseurid)
		{
			var response = await _contratfournisseurBLL.SuppressionContratFournisseur(contratfournisseurid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
