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
{	[Route("api/categorieessences")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class CategorieEssenceController : ControllerBase
	{

		private readonly ICategorieEssenceBLL _categorieessenceBLL;
		private readonly ILogger<CategorieEssenceController> _logger;
		public CategorieEssenceController(ICategorieEssenceBLL categorieessenceBLL, ILogger<CategorieEssenceController> logger)
		{
			_categorieessenceBLL = categorieessenceBLL ?? throw new ArgumentNullException(nameof(categorieessenceBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<CategorieEssenceListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _categorieessenceBLL.ObtenireCategorieEssenceListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id categorieessence</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<CategorieEssenceReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _categorieessenceBLL.ObtenireCategorieEssenceParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<CategorieEssenceReponse>>> CreationAsync([FromBody] CategorieEssenceRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<CategorieEssenceReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _categorieessenceBLL.CreationCategorieEssence(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="categorieessenceid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{categorieessenceid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<CategorieEssenceReponse>>> MisejourAsync(int categorieessenceid, [FromBody] CategorieEssenceEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<CategorieEssenceReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _categorieessenceBLL.MisejourCategorieEssence(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="categorieessenceid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{categorieessenceid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<CategorieEssenceReponse>>> SuppressionAsync(int categorieessenceid)
		{
			var response = await _categorieessenceBLL.SuppressionCategorieEssence(categorieessenceid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
