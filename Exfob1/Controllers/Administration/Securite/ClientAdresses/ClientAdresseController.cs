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
{	[Route("api/clientadresses")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class ClientAdresseController : ControllerBase
	{

		private readonly IClientAdresseBLL _clientadresseBLL;
		private readonly ILogger<ClientAdresseController> _logger;
		public ClientAdresseController(IClientAdresseBLL clientadresseBLL, ILogger<ClientAdresseController> logger)
		{
			_clientadresseBLL = clientadresseBLL ?? throw new ArgumentNullException(nameof(clientadresseBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<ClientAdresseListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _clientadresseBLL.ObtenireClientAdresseListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id clientadresse</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<ClientAdresseReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _clientadresseBLL.ObtenireClientAdresseParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<ClientAdresseReponse>>> CreationAsync([FromBody] ClientAdresseRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ClientAdresseReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _clientadresseBLL.CreationClientAdresse(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="clientadresseid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{clientadresseid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ClientAdresseReponse>>> MisejourAsync(int clientadresseid, [FromBody] ClientAdresseEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ClientAdresseReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _clientadresseBLL.MisejourClientAdresse(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="clientadresseid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{clientadresseid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ClientAdresseReponse>>> SuppressionAsync(int clientadresseid)
		{
			var response = await _clientadresseBLL.SuppressionClientAdresse(clientadresseid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
