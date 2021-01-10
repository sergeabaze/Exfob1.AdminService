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
{	[Route("api/modeenvoies")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class ModeEnvoieController : ControllerBase
	{

		private readonly IModeEnvoieBLL _modeenvoieBLL;
		private readonly ILogger<ModeEnvoieController> _logger;
		public ModeEnvoieController(IModeEnvoieBLL modeenvoieBLL, ILogger<ModeEnvoieController> logger)
		{
			_modeenvoieBLL = modeenvoieBLL ?? throw new ArgumentNullException(nameof(modeenvoieBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<ModeEnvoieListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _modeenvoieBLL.ObtenireModeEnvoieListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id modeenvoie</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<ModeEnvoieReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _modeenvoieBLL.ObtenireModeEnvoieParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<ModeEnvoieReponse>>> CreationAsync([FromBody] ModeEnvoieRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ModeEnvoieReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _modeenvoieBLL.CreationModeEnvoie(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="modeenvoieid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{modeenvoieid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ModeEnvoieReponse>>> MisejourAsync(int modeenvoieid, [FromBody] ModeEnvoieEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ModeEnvoieReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _modeenvoieBLL.MisejourModeEnvoie(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="modeenvoieid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{modeenvoieid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ModeEnvoieReponse>>> SuppressionAsync(int modeenvoieid)
		{
			var response = await _modeenvoieBLL.SuppressionModeEnvoie(modeenvoieid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
