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
{	[Route("api/codifications")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class CodificationController : ControllerBase
	{

		private readonly ICodificationBLL _codificationBLL;
		private readonly ILogger<CodificationController> _logger;
		public CodificationController(ICodificationBLL codificationBLL, ILogger<CodificationController> logger)
		{
			_codificationBLL = codificationBLL ?? throw new ArgumentNullException(nameof(codificationBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<CodificationListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _codificationBLL.ObtenireCodificationListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id codification</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<CodificationReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _codificationBLL.ObtenireCodificationParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<CodificationReponse>>> CreationAsync([FromBody] CodificationRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<CodificationReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _codificationBLL.CreationCodification(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="codificationid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{codificationid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<CodificationReponse>>> MisejourAsync(int codificationid, [FromBody] CodificationEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<CodificationReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _codificationBLL.MisejourCodification(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="codificationid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{codificationid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<CodificationReponse>>> SuppressionAsync(int codificationid)
		{
			var response = await _codificationBLL.SuppressionCodification(codificationid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
