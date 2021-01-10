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
{	[Route("api/naturemouvements")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class NatureMouvementController : ControllerBase
	{

		private readonly INatureMouvementBLL _naturemouvementBLL;
		private readonly ILogger<NatureMouvementController> _logger;
		public NatureMouvementController(INatureMouvementBLL naturemouvementBLL, ILogger<NatureMouvementController> logger)
		{
			_naturemouvementBLL = naturemouvementBLL ?? throw new ArgumentNullException(nameof(naturemouvementBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<NatureMouvementListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _naturemouvementBLL.ObtenireNatureMouvementListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id naturemouvement</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<NatureMouvementReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _naturemouvementBLL.ObtenireNatureMouvementParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<NatureMouvementReponse>>> CreationAsync([FromBody] NatureMouvementRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<NatureMouvementReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _naturemouvementBLL.CreationNatureMouvement(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="naturemouvementid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{naturemouvementid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<NatureMouvementReponse>>> MisejourAsync(int naturemouvementid, [FromBody] NatureMouvementEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<NatureMouvementReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _naturemouvementBLL.MisejourNatureMouvement(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="naturemouvementid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{naturemouvementid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<NatureMouvementReponse>>> SuppressionAsync(int naturemouvementid)
		{
			var response = await _naturemouvementBLL.SuppressionNatureMouvement(naturemouvementid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
