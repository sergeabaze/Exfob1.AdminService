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
{	[Route("api/chantiers")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class ChantierController : ControllerBase
	{

		private readonly IChantierBLL _chantierBLL;
		private readonly ILogger<ChantierController> _logger;
		public ChantierController(IChantierBLL chantierBLL, ILogger<ChantierController> logger)
		{
			_chantierBLL = chantierBLL ?? throw new ArgumentNullException(nameof(chantierBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<ChantierListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _chantierBLL.ObtenireChantierListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id chantier</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<ChantierReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _chantierBLL.ObtenireChantierParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<ChantierReponse>>> CreationAsync([FromBody] ChantierRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ChantierReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _chantierBLL.CreationChantier(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="chantierid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{chantierid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ChantierReponse>>> MisejourAsync(int chantierid, [FromBody] ChantierEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ChantierReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _chantierBLL.MisejourChantier(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="chantierid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{chantierid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ChantierReponse>>> SuppressionAsync(int chantierid)
		{
			var response = await _chantierBLL.SuppressionChantier(chantierid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
