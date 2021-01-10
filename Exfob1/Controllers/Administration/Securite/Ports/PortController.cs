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
{	[Route("api/ports")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class PortController : ControllerBase
	{

		private readonly IPortBLL _portBLL;
		private readonly ILogger<PortController> _logger;
		public PortController(IPortBLL portBLL, ILogger<PortController> logger)
		{
			_portBLL = portBLL ?? throw new ArgumentNullException(nameof(portBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<PortListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _portBLL.ObtenirePortListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id port</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<PortReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _portBLL.ObtenirePortParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<PortReponse>>> CreationAsync([FromBody] PortRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<PortReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _portBLL.CreationPort(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="portid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{portid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<PortReponse>>> MisejourAsync(int portid, [FromBody] PortEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<PortReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _portBLL.MisejourPort(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="portid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{portid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<PortReponse>>> SuppressionAsync(int portid)
		{
			var response = await _portBLL.SuppressionPort(portid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
