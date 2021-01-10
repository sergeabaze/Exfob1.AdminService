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
{	[Route("api/sitearrives")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class SiteArriveController : ControllerBase
	{

		private readonly ISiteArriveBLL _sitearriveBLL;
		private readonly ILogger<SiteArriveController> _logger;
		public SiteArriveController(ISiteArriveBLL sitearriveBLL, ILogger<SiteArriveController> logger)
		{
			_sitearriveBLL = sitearriveBLL ?? throw new ArgumentNullException(nameof(sitearriveBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<SiteArriveListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _sitearriveBLL.ObtenireSiteArriveListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id sitearrive</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<SiteArriveReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _sitearriveBLL.ObtenireSiteArriveParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<SiteArriveReponse>>> CreationAsync([FromBody] SiteArriveRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SiteArriveReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _sitearriveBLL.CreationSiteArrive(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="sitearriveid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{sitearriveid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SiteArriveReponse>>> MisejourAsync(int sitearriveid, [FromBody] SiteArriveEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SiteArriveReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _sitearriveBLL.MisejourSiteArrive(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="sitearriveid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{sitearriveid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SiteArriveReponse>>> SuppressionAsync(int sitearriveid)
		{
			var response = await _sitearriveBLL.SuppressionSiteArrive(sitearriveid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
