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
{	[Route("api/periodeclotures")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class PeriodeClotureController : ControllerBase
	{

		private readonly IPeriodeClotureBLL _periodeclotureBLL;
		private readonly ILogger<PeriodeClotureController> _logger;
		public PeriodeClotureController(IPeriodeClotureBLL periodeclotureBLL, ILogger<PeriodeClotureController> logger)
		{
			_periodeclotureBLL = periodeclotureBLL ?? throw new ArgumentNullException(nameof(periodeclotureBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<PeriodeClotureListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _periodeclotureBLL.ObtenirePeriodeClotureListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id periodecloture</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<PeriodeClotureReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _periodeclotureBLL.ObtenirePeriodeClotureParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<PeriodeClotureReponse>>> CreationAsync([FromBody] PeriodeClotureRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<PeriodeClotureReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _periodeclotureBLL.CreationPeriodeCloture(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="periodeclotureid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{periodeclotureid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<PeriodeClotureReponse>>> MisejourAsync(int periodeclotureid, [FromBody] PeriodeClotureEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<PeriodeClotureReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _periodeclotureBLL.MisejourPeriodeCloture(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="periodeclotureid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{periodeclotureid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<PeriodeClotureReponse>>> SuppressionAsync(int periodeclotureid)
		{
			var response = await _periodeclotureBLL.SuppressionPeriodeCloture(periodeclotureid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
