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
{	[Route("api/transitaires")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class TransitaireController : ControllerBase
	{

		private readonly ITransitaireBLL _transitaireBLL;
		private readonly ILogger<TransitaireController> _logger;
		public TransitaireController(ITransitaireBLL transitaireBLL, ILogger<TransitaireController> logger)
		{
			_transitaireBLL = transitaireBLL ?? throw new ArgumentNullException(nameof(transitaireBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<TransitaireListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _transitaireBLL.ObtenireTransitaireListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id transitaire</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<TransitaireReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _transitaireBLL.ObtenireTransitaireParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<TransitaireReponse>>> CreationAsync([FromBody] TransitaireRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TransitaireReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _transitaireBLL.CreationTransitaire(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="transitaireid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{transitaireid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TransitaireReponse>>> MisejourAsync(int transitaireid, [FromBody] TransitaireEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TransitaireReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _transitaireBLL.MisejourTransitaire(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="transitaireid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{transitaireid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TransitaireReponse>>> SuppressionAsync(int transitaireid)
		{
			var response = await _transitaireBLL.SuppressionTransitaire(transitaireid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
