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
{	[Route("api/siteautorises")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class SiteAutoriseController : ControllerBase
	{

		private readonly ISiteAutoriseBLL _siteautoriseBLL;
		private readonly ILogger<SiteAutoriseController> _logger;
		public SiteAutoriseController(ISiteAutoriseBLL siteautoriseBLL, ILogger<SiteAutoriseController> logger)
		{
			_siteautoriseBLL = siteautoriseBLL ?? throw new ArgumentNullException(nameof(siteautoriseBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<SiteAutoriseListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _siteautoriseBLL.ObtenireSiteAutoriseListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id siteautorise</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<SiteAutoriseReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _siteautoriseBLL.ObtenireSiteAutoriseParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<SiteAutoriseReponse>>> CreationAsync([FromBody] SiteAutoriseRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SiteAutoriseReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _siteautoriseBLL.CreationSiteAutorise(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="siteautoriseid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{siteautoriseid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SiteAutoriseReponse>>> MisejourAsync(int siteautoriseid, [FromBody] SiteAutoriseEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SiteAutoriseReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _siteautoriseBLL.MisejourSiteAutorise(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="siteautoriseid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{siteautoriseid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SiteAutoriseReponse>>> SuppressionAsync(int siteautoriseid)
		{
			var response = await _siteautoriseBLL.SuppressionSiteAutorise(siteautoriseid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
