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
{	[Route("api/modetransports")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class ModeTransportController : ControllerBase
	{

		private readonly IModeTransportBLL _modetransportBLL;
		private readonly ILogger<ModeTransportController> _logger;
		public ModeTransportController(IModeTransportBLL modetransportBLL, ILogger<ModeTransportController> logger)
		{
			_modetransportBLL = modetransportBLL ?? throw new ArgumentNullException(nameof(modetransportBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<ModeTransportListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _modetransportBLL.ObtenireModeTransportListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id modetransport</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<ModeTransportReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _modetransportBLL.ObtenireModeTransportParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<ModeTransportReponse>>> CreationAsync([FromBody] ModeTransportRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ModeTransportReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _modetransportBLL.CreationModeTransport(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="modetransportid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{modetransportid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ModeTransportReponse>>> MisejourAsync(int modetransportid, [FromBody] ModeTransportEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ModeTransportReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _modetransportBLL.MisejourModeTransport(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="modetransportid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{modetransportid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ModeTransportReponse>>> SuppressionAsync(int modetransportid)
		{
			var response = await _modetransportBLL.SuppressionModeTransport(modetransportid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
