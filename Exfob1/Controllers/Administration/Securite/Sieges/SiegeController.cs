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
{	[Route("api/sieges")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class SiegeController : ControllerBase
	{

		private readonly ISiegeBLL _siegeBLL;
		private readonly ILogger<SiegeController> _logger;
		public SiegeController(ISiegeBLL siegeBLL, ILogger<SiegeController> logger)
		{
			_siegeBLL = siegeBLL ?? throw new ArgumentNullException(nameof(siegeBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<SiegeListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _siegeBLL.ObtenireSiegeListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id siege</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<SiegeReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _siegeBLL.ObtenireSiegeParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<SiegeReponse>>> CreationAsync([FromBody] SiegeRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SiegeReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _siegeBLL.CreationSiege(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="siegeid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{siegeid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SiegeReponse>>> MisejourAsync(int siegeid, [FromBody] SiegeEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SiegeReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _siegeBLL.MisejourSiege(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="siegeid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{siegeid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SiegeReponse>>> SuppressionAsync(int siegeid)
		{
			var response = await _siegeBLL.SuppressionSiege(siegeid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
