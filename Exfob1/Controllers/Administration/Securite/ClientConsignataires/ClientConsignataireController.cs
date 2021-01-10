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
{	[Route("api/clientconsignataires")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class ClientConsignataireController : ControllerBase
	{

		private readonly IClientConsignataireBLL _clientconsignataireBLL;
		private readonly ILogger<ClientConsignataireController> _logger;
		public ClientConsignataireController(IClientConsignataireBLL clientconsignataireBLL, ILogger<ClientConsignataireController> logger)
		{
			_clientconsignataireBLL = clientconsignataireBLL ?? throw new ArgumentNullException(nameof(clientconsignataireBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<ClientConsignataireListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _clientconsignataireBLL.ObtenireClientConsignataireListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id clientconsignataire</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<ClientConsignataireReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _clientconsignataireBLL.ObtenireClientConsignataireParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<ClientConsignataireReponse>>> CreationAsync([FromBody] ClientConsignataireRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ClientConsignataireReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _clientconsignataireBLL.CreationClientConsignataire(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="clientconsignataireid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{clientconsignataireid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ClientConsignataireReponse>>> MisejourAsync(int clientconsignataireid, [FromBody] ClientConsignataireEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ClientConsignataireReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _clientconsignataireBLL.MisejourClientConsignataire(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="clientconsignataireid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{clientconsignataireid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ClientConsignataireReponse>>> SuppressionAsync(int clientconsignataireid)
		{
			var response = await _clientconsignataireBLL.SuppressionClientConsignataire(clientconsignataireid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
