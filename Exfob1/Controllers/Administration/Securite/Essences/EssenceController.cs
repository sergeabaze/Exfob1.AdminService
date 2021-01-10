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
{	[Route("api/essences")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class EssenceController : ControllerBase
	{

		private readonly IEssenceBLL _essenceBLL;
		private readonly ILogger<EssenceController> _logger;
		public EssenceController(IEssenceBLL essenceBLL, ILogger<EssenceController> logger)
		{
			_essenceBLL = essenceBLL ?? throw new ArgumentNullException(nameof(essenceBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<EssenceListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _essenceBLL.ObtenireEssenceListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id essence</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<EssenceReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _essenceBLL.ObtenireEssenceParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<EssenceReponse>>> CreationAsync([FromBody] EssenceRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<EssenceReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _essenceBLL.CreationEssence(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="essenceid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{essenceid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<EssenceReponse>>> MisejourAsync(int essenceid, [FromBody] EssenceEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<EssenceReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _essenceBLL.MisejourEssence(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="essenceid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{essenceid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<EssenceReponse>>> SuppressionAsync(int essenceid)
		{
			var response = await _essenceBLL.SuppressionEssence(essenceid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
