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
{	[Route("api/redevanceetatiques")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class RedevanceEtatiqueController : ControllerBase
	{

		private readonly IRedevanceEtatiqueBLL _redevanceetatiqueBLL;
		private readonly ILogger<RedevanceEtatiqueController> _logger;
		public RedevanceEtatiqueController(IRedevanceEtatiqueBLL redevanceetatiqueBLL, ILogger<RedevanceEtatiqueController> logger)
		{
			_redevanceetatiqueBLL = redevanceetatiqueBLL ?? throw new ArgumentNullException(nameof(redevanceetatiqueBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<RedevanceEtatiqueListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _redevanceetatiqueBLL.ObtenireRedevanceEtatiqueListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id redevanceetatique</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<RedevanceEtatiqueReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _redevanceetatiqueBLL.ObtenireRedevanceEtatiqueParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<RedevanceEtatiqueReponse>>> CreationAsync([FromBody] RedevanceEtatiqueRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<RedevanceEtatiqueReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _redevanceetatiqueBLL.CreationRedevanceEtatique(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="redevanceetatiqueid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{redevanceetatiqueid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<RedevanceEtatiqueReponse>>> MisejourAsync(int redevanceetatiqueid, [FromBody] RedevanceEtatiqueEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<RedevanceEtatiqueReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _redevanceetatiqueBLL.MisejourRedevanceEtatique(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="redevanceetatiqueid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{redevanceetatiqueid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<RedevanceEtatiqueReponse>>> SuppressionAsync(int redevanceetatiqueid)
		{
			var response = await _redevanceetatiqueBLL.SuppressionRedevanceEtatique(redevanceetatiqueid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
