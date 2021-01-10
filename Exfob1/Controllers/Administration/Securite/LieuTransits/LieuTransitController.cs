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
{	[Route("api/lieutransits")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class LieuTransitController : ControllerBase
	{

		private readonly ILieuTransitBLL _lieutransitBLL;
		private readonly ILogger<LieuTransitController> _logger;
		public LieuTransitController(ILieuTransitBLL lieutransitBLL, ILogger<LieuTransitController> logger)
		{
			_lieutransitBLL = lieutransitBLL ?? throw new ArgumentNullException(nameof(lieutransitBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<LieuTransitListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _lieutransitBLL.ObtenireLieuTransitListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id lieutransit</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<LieuTransitReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _lieutransitBLL.ObtenireLieuTransitParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<LieuTransitReponse>>> CreationAsync([FromBody] LieuTransitRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<LieuTransitReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _lieutransitBLL.CreationLieuTransit(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="lieutransitid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{lieutransitid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<LieuTransitReponse>>> MisejourAsync(int lieutransitid, [FromBody] LieuTransitEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<LieuTransitReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _lieutransitBLL.MisejourLieuTransit(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="lieutransitid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{lieutransitid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<LieuTransitReponse>>> SuppressionAsync(int lieutransitid)
		{
			var response = await _lieutransitBLL.SuppressionLieuTransit(lieutransitid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
