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
{	[Route("api/transporteurs")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class TransporteurController : ControllerBase
	{

		private readonly ITransporteurBLL _transporteurBLL;
		private readonly ILogger<TransporteurController> _logger;
		public TransporteurController(ITransporteurBLL transporteurBLL, ILogger<TransporteurController> logger)
		{
			_transporteurBLL = transporteurBLL ?? throw new ArgumentNullException(nameof(transporteurBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<TransporteurListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _transporteurBLL.ObtenireTransporteurListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id transporteur</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<TransporteurReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _transporteurBLL.ObtenireTransporteurParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<TransporteurReponse>>> CreationAsync([FromBody] TransporteurRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TransporteurReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _transporteurBLL.CreationTransporteur(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="transporteurid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{transporteurid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TransporteurReponse>>> MisejourAsync(int transporteurid, [FromBody] TransporteurEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TransporteurReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _transporteurBLL.MisejourTransporteur(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="transporteurid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{transporteurid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TransporteurReponse>>> SuppressionAsync(int transporteurid)
		{
			var response = await _transporteurBLL.SuppressionTransporteur(transporteurid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
