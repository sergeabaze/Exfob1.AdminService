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
{	[Route("api/portarrives")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class PortArriveController : ControllerBase
	{

		private readonly IPortArriveBLL _portarriveBLL;
		private readonly ILogger<PortArriveController> _logger;
		public PortArriveController(IPortArriveBLL portarriveBLL, ILogger<PortArriveController> logger)
		{
			_portarriveBLL = portarriveBLL ?? throw new ArgumentNullException(nameof(portarriveBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<PortArriveListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _portarriveBLL.ObtenirePortArriveListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id portarrive</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<PortArriveReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _portarriveBLL.ObtenirePortArriveParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<PortArriveReponse>>> CreationAsync([FromBody] PortArriveRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<PortArriveReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _portarriveBLL.CreationPortArrive(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="portarriveid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{portarriveid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<PortArriveReponse>>> MisejourAsync(int portarriveid, [FromBody] PortArriveEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<PortArriveReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _portarriveBLL.MisejourPortArrive(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="portarriveid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{portarriveid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<PortArriveReponse>>> SuppressionAsync(int portarriveid)
		{
			var response = await _portarriveBLL.SuppressionPortArrive(portarriveid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
