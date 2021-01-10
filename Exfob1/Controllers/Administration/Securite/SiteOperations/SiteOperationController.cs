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
{	[Route("api/siteoperations")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class SiteOperationController : ControllerBase
	{

		private readonly ISiteOperationBLL _siteoperationBLL;
		private readonly ILogger<SiteOperationController> _logger;
		public SiteOperationController(ISiteOperationBLL siteoperationBLL, ILogger<SiteOperationController> logger)
		{
			_siteoperationBLL = siteoperationBLL ?? throw new ArgumentNullException(nameof(siteoperationBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<SiteOperationListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _siteoperationBLL.ObtenireSiteOperationListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id siteoperation</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<SiteOperationReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _siteoperationBLL.ObtenireSiteOperationParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<SiteOperationReponse>>> CreationAsync([FromBody] SiteOperationRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SiteOperationReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _siteoperationBLL.CreationSiteOperation(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="siteoperationid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{siteoperationid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SiteOperationReponse>>> MisejourAsync(int siteoperationid, [FromBody] SiteOperationEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SiteOperationReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _siteoperationBLL.MisejourSiteOperation(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="siteoperationid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{siteoperationid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SiteOperationReponse>>> SuppressionAsync(int siteoperationid)
		{
			var response = await _siteoperationBLL.SuppressionSiteOperation(siteoperationid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
