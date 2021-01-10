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
{	[Route("api/clientcontacts")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class ClientContactController : ControllerBase
	{

		private readonly IClientContactBLL _clientcontactBLL;
		private readonly ILogger<ClientContactController> _logger;
		public ClientContactController(IClientContactBLL clientcontactBLL, ILogger<ClientContactController> logger)
		{
			_clientcontactBLL = clientcontactBLL ?? throw new ArgumentNullException(nameof(clientcontactBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<ClientContactListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _clientcontactBLL.ObtenireClientContactListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id clientcontact</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<ClientContactReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _clientcontactBLL.ObtenireClientContactParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<ClientContactReponse>>> CreationAsync([FromBody] ClientContactRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ClientContactReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _clientcontactBLL.CreationClientContact(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="clientcontactid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{clientcontactid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ClientContactReponse>>> MisejourAsync(int clientcontactid, [FromBody] ClientContactEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ClientContactReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _clientcontactBLL.MisejourClientContact(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="clientcontactid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{clientcontactid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ClientContactReponse>>> SuppressionAsync(int clientcontactid)
		{
			var response = await _clientcontactBLL.SuppressionClientContact(clientcontactid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
