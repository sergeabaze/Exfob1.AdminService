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
{	[Route("api/soustraitances")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class SousTraitanceController : ControllerBase
	{

		private readonly ISousTraitanceBLL _soustraitanceBLL;
		private readonly ILogger<SousTraitanceController> _logger;
		public SousTraitanceController(ISousTraitanceBLL soustraitanceBLL, ILogger<SousTraitanceController> logger)
		{
			_soustraitanceBLL = soustraitanceBLL ?? throw new ArgumentNullException(nameof(soustraitanceBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<SousTraitanceListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _soustraitanceBLL.ObtenireSousTraitanceListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id soustraitance</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<SousTraitanceReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _soustraitanceBLL.ObtenireSousTraitanceParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<SousTraitanceReponse>>> CreationAsync([FromBody] SousTraitanceRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SousTraitanceReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _soustraitanceBLL.CreationSousTraitance(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="soustraitanceid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{soustraitanceid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SousTraitanceReponse>>> MisejourAsync(int soustraitanceid, [FromBody] SousTraitanceEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SousTraitanceReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _soustraitanceBLL.MisejourSousTraitance(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="soustraitanceid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{soustraitanceid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SousTraitanceReponse>>> SuppressionAsync(int soustraitanceid)
		{
			var response = await _soustraitanceBLL.SuppressionSousTraitance(soustraitanceid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
