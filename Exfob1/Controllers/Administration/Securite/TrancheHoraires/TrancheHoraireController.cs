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
{	[Route("api/tranchehoraires")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class TrancheHoraireController : ControllerBase
	{

		private readonly ITrancheHoraireBLL _tranchehoraireBLL;
		private readonly ILogger<TrancheHoraireController> _logger;
		public TrancheHoraireController(ITrancheHoraireBLL tranchehoraireBLL, ILogger<TrancheHoraireController> logger)
		{
			_tranchehoraireBLL = tranchehoraireBLL ?? throw new ArgumentNullException(nameof(tranchehoraireBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<TrancheHoraireListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _tranchehoraireBLL.ObtenireTrancheHoraireListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id tranchehoraire</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<TrancheHoraireReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _tranchehoraireBLL.ObtenireTrancheHoraireParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<TrancheHoraireReponse>>> CreationAsync([FromBody] TrancheHoraireRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TrancheHoraireReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _tranchehoraireBLL.CreationTrancheHoraire(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="tranchehoraireid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{tranchehoraireid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TrancheHoraireReponse>>> MisejourAsync(int tranchehoraireid, [FromBody] TrancheHoraireEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TrancheHoraireReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _tranchehoraireBLL.MisejourTrancheHoraire(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="tranchehoraireid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{tranchehoraireid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TrancheHoraireReponse>>> SuppressionAsync(int tranchehoraireid)
		{
			var response = await _tranchehoraireBLL.SuppressionTrancheHoraire(tranchehoraireid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
