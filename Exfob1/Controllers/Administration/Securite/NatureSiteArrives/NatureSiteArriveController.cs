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
{	[Route("api/naturesitearrives")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class NatureSiteArriveController : ControllerBase
	{

		private readonly INatureSiteArriveBLL _naturesitearriveBLL;
		private readonly ILogger<NatureSiteArriveController> _logger;
		public NatureSiteArriveController(INatureSiteArriveBLL naturesitearriveBLL, ILogger<NatureSiteArriveController> logger)
		{
			_naturesitearriveBLL = naturesitearriveBLL ?? throw new ArgumentNullException(nameof(naturesitearriveBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<NatureSiteArriveListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _naturesitearriveBLL.ObtenireNatureSiteArriveListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id naturesitearrive</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<NatureSiteArriveReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _naturesitearriveBLL.ObtenireNatureSiteArriveParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<NatureSiteArriveReponse>>> CreationAsync([FromBody] NatureSiteArriveRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<NatureSiteArriveReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _naturesitearriveBLL.CreationNatureSiteArrive(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="naturesitearriveid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{naturesitearriveid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<NatureSiteArriveReponse>>> MisejourAsync(int naturesitearriveid, [FromBody] NatureSiteArriveEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<NatureSiteArriveReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _naturesitearriveBLL.MisejourNatureSiteArrive(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="naturesitearriveid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{naturesitearriveid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<NatureSiteArriveReponse>>> SuppressionAsync(int naturesitearriveid)
		{
			var response = await _naturesitearriveBLL.SuppressionNatureSiteArrive(naturesitearriveid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
