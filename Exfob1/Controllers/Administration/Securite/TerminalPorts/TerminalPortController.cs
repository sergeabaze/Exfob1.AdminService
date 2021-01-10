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
{	[Route("api/terminalports")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class TerminalPortController : ControllerBase
	{

		private readonly ITerminalPortBLL _terminalportBLL;
		private readonly ILogger<TerminalPortController> _logger;
		public TerminalPortController(ITerminalPortBLL terminalportBLL, ILogger<TerminalPortController> logger)
		{
			_terminalportBLL = terminalportBLL ?? throw new ArgumentNullException(nameof(terminalportBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<TerminalPortListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _terminalportBLL.ObtenireTerminalPortListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id terminalport</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<TerminalPortReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _terminalportBLL.ObtenireTerminalPortParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<TerminalPortReponse>>> CreationAsync([FromBody] TerminalPortRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TerminalPortReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _terminalportBLL.CreationTerminalPort(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="terminalportid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{terminalportid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TerminalPortReponse>>> MisejourAsync(int terminalportid, [FromBody] TerminalPortEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TerminalPortReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _terminalportBLL.MisejourTerminalPort(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="terminalportid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{terminalportid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TerminalPortReponse>>> SuppressionAsync(int terminalportid)
		{
			var response = await _terminalportBLL.SuppressionTerminalPort(terminalportid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
