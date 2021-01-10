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
{	[Route("api/pilegrumes")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class PileGrumeController : ControllerBase
	{

		private readonly IPileGrumeBLL _pilegrumeBLL;
		private readonly ILogger<PileGrumeController> _logger;
		public PileGrumeController(IPileGrumeBLL pilegrumeBLL, ILogger<PileGrumeController> logger)
		{
			_pilegrumeBLL = pilegrumeBLL ?? throw new ArgumentNullException(nameof(pilegrumeBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<PileGrumeListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _pilegrumeBLL.ObtenirePileGrumeListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id pilegrume</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<PileGrumeReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _pilegrumeBLL.ObtenirePileGrumeParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<PileGrumeReponse>>> CreationAsync([FromBody] PileGrumeRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<PileGrumeReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _pilegrumeBLL.CreationPileGrume(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="pilegrumeid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{pilegrumeid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<PileGrumeReponse>>> MisejourAsync(int pilegrumeid, [FromBody] PileGrumeEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<PileGrumeReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _pilegrumeBLL.MisejourPileGrume(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="pilegrumeid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{pilegrumeid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<PileGrumeReponse>>> SuppressionAsync(int pilegrumeid)
		{
			var response = await _pilegrumeBLL.SuppressionPileGrume(pilegrumeid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
