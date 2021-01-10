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
{	[Route("api/conteneurorigines")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class ConteneurOrigineController : ControllerBase
	{

		private readonly IConteneurOrigineBLL _conteneurorigineBLL;
		private readonly ILogger<ConteneurOrigineController> _logger;
		public ConteneurOrigineController(IConteneurOrigineBLL conteneurorigineBLL, ILogger<ConteneurOrigineController> logger)
		{
			_conteneurorigineBLL = conteneurorigineBLL ?? throw new ArgumentNullException(nameof(conteneurorigineBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<ConteneurOrigineListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _conteneurorigineBLL.ObtenireConteneurOrigineListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id conteneurorigine</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<ConteneurOrigineReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _conteneurorigineBLL.ObtenireConteneurOrigineParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<ConteneurOrigineReponse>>> CreationAsync([FromBody] ConteneurOrigineRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ConteneurOrigineReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _conteneurorigineBLL.CreationConteneurOrigine(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="conteneurorigineid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{conteneurorigineid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ConteneurOrigineReponse>>> MisejourAsync(int conteneurorigineid, [FromBody] ConteneurOrigineEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ConteneurOrigineReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _conteneurorigineBLL.MisejourConteneurOrigine(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="conteneurorigineid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{conteneurorigineid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ConteneurOrigineReponse>>> SuppressionAsync(int conteneurorigineid)
		{
			var response = await _conteneurorigineBLL.SuppressionConteneurOrigine(conteneurorigineid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
