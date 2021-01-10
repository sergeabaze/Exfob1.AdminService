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
{	[Route("api/naturesites")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class NatureSiteController : ControllerBase
	{

		private readonly INatureSiteBLL _naturesiteBLL;
		private readonly ILogger<NatureSiteController> _logger;
		public NatureSiteController(INatureSiteBLL naturesiteBLL, ILogger<NatureSiteController> logger)
		{
			_naturesiteBLL = naturesiteBLL ?? throw new ArgumentNullException(nameof(naturesiteBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<NatureSiteListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _naturesiteBLL.ObtenireNatureSiteListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id naturesite</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<NatureSiteReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _naturesiteBLL.ObtenireNatureSiteParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<NatureSiteReponse>>> CreationAsync([FromBody] NatureSiteRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<NatureSiteReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _naturesiteBLL.CreationNatureSite(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="naturesiteid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{naturesiteid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<NatureSiteReponse>>> MisejourAsync(int naturesiteid, [FromBody] NatureSiteEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<NatureSiteReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _naturesiteBLL.MisejourNatureSite(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="naturesiteid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{naturesiteid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<NatureSiteReponse>>> SuppressionAsync(int naturesiteid)
		{
			var response = await _naturesiteBLL.SuppressionNatureSite(naturesiteid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
