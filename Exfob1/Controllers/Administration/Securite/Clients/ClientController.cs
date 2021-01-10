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
{	[Route("api/clients")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class ClientController : ControllerBase
	{

		private readonly IClientBLL _clientBLL;
		private readonly ILogger<ClientController> _logger;
		public ClientController(IClientBLL clientBLL, ILogger<ClientController> logger)
		{
			_clientBLL = clientBLL ?? throw new ArgumentNullException(nameof(clientBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<ClientListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _clientBLL.ObtenireClientListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id client</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<ClientReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _clientBLL.ObtenireClientParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<ClientReponse>>> CreationAsync([FromBody] ClientRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ClientReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _clientBLL.CreationClient(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="clientid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{clientid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ClientReponse>>> MisejourAsync(int clientid, [FromBody] ClientEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ClientReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _clientBLL.MisejourClient(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="clientid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{clientid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ClientReponse>>> SuppressionAsync(int clientid)
		{
			var response = await _clientBLL.SuppressionClient(clientid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
