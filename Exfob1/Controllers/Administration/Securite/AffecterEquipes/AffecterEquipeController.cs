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
{	[Route("api/affecterequipes")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class AffecterEquipeController : ControllerBase
	{

		private readonly IAffecterEquipeBLL _affecterequipeBLL;
		private readonly ILogger<AffecterEquipeController> _logger;
		public AffecterEquipeController(IAffecterEquipeBLL affecterequipeBLL, ILogger<AffecterEquipeController> logger)
		{
			_affecterequipeBLL = affecterequipeBLL ?? throw new ArgumentNullException(nameof(affecterequipeBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<AffecterEquipeListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _affecterequipeBLL.ObtenireAffecterEquipeListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id affecterequipe</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<AffecterEquipeReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _affecterequipeBLL.ObtenireAffecterEquipeParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<AffecterEquipeReponse>>> CreationAsync([FromBody] AffecterEquipeRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<AffecterEquipeReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _affecterequipeBLL.CreationAffecterEquipe(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="affecterequipeid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{affecterequipeid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<AffecterEquipeReponse>>> MisejourAsync(int affecterequipeid, [FromBody] AffecterEquipeEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<AffecterEquipeReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _affecterequipeBLL.MisejourAffecterEquipe(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="affecterequipeid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{affecterequipeid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<AffecterEquipeReponse>>> SuppressionAsync(int affecterequipeid)
		{
			var response = await _affecterequipeBLL.SuppressionAffecterEquipe(affecterequipeid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
