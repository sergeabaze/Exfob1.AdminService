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
{	[Route("api/sepbcs")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class SepbcController : ControllerBase
	{

		private readonly ISepbcBLL _sepbcBLL;
		private readonly ILogger<SepbcController> _logger;
		public SepbcController(ISepbcBLL sepbcBLL, ILogger<SepbcController> logger)
		{
			_sepbcBLL = sepbcBLL ?? throw new ArgumentNullException(nameof(sepbcBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<SepbcListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _sepbcBLL.ObtenireSepbcListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id sepbc</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<SepbcReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _sepbcBLL.ObtenireSepbcParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<SepbcReponse>>> CreationAsync([FromBody] SepbcRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SepbcReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _sepbcBLL.CreationSepbc(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="sepbcid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{sepbcid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SepbcReponse>>> MisejourAsync(int sepbcid, [FromBody] SepbcEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SepbcReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _sepbcBLL.MisejourSepbc(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="sepbcid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{sepbcid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SepbcReponse>>> SuppressionAsync(int sepbcid)
		{
			var response = await _sepbcBLL.SuppressionSepbc(sepbcid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
