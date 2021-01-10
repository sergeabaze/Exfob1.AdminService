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
{	[Route("api/moyentransports")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class MoyenTransportController : ControllerBase
	{

		private readonly IMoyenTransportBLL _moyentransportBLL;
		private readonly ILogger<MoyenTransportController> _logger;
		public MoyenTransportController(IMoyenTransportBLL moyentransportBLL, ILogger<MoyenTransportController> logger)
		{
			_moyentransportBLL = moyentransportBLL ?? throw new ArgumentNullException(nameof(moyentransportBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<MoyenTransportListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _moyentransportBLL.ObtenireMoyenTransportListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id moyentransport</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<MoyenTransportReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _moyentransportBLL.ObtenireMoyenTransportParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<MoyenTransportReponse>>> CreationAsync([FromBody] MoyenTransportRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<MoyenTransportReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _moyentransportBLL.CreationMoyenTransport(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="moyentransportid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{moyentransportid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<MoyenTransportReponse>>> MisejourAsync(int moyentransportid, [FromBody] MoyenTransportEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<MoyenTransportReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _moyentransportBLL.MisejourMoyenTransport(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="moyentransportid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{moyentransportid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<MoyenTransportReponse>>> SuppressionAsync(int moyentransportid)
		{
			var response = await _moyentransportBLL.SuppressionMoyenTransport(moyentransportid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
