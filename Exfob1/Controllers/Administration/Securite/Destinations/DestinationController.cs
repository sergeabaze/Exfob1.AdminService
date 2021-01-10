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
{	[Route("api/destinations")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class DestinationController : ControllerBase
	{

		private readonly IDestinationBLL _destinationBLL;
		private readonly ILogger<DestinationController> _logger;
		public DestinationController(IDestinationBLL destinationBLL, ILogger<DestinationController> logger)
		{
			_destinationBLL = destinationBLL ?? throw new ArgumentNullException(nameof(destinationBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<DestinationListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _destinationBLL.ObtenireDestinationListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id destination</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<DestinationReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _destinationBLL.ObtenireDestinationParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<DestinationReponse>>> CreationAsync([FromBody] DestinationRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<DestinationReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _destinationBLL.CreationDestination(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="destinationid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{destinationid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<DestinationReponse>>> MisejourAsync(int destinationid, [FromBody] DestinationEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<DestinationReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _destinationBLL.MisejourDestination(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="destinationid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{destinationid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<DestinationReponse>>> SuppressionAsync(int destinationid)
		{
			var response = await _destinationBLL.SuppressionDestination(destinationid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
