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
{	[Route("api/classeessences")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class ClasseEssenceController : ControllerBase
	{

		private readonly IClasseEssenceBLL _classeessenceBLL;
		private readonly ILogger<ClasseEssenceController> _logger;
		public ClasseEssenceController(IClasseEssenceBLL classeessenceBLL, ILogger<ClasseEssenceController> logger)
		{
			_classeessenceBLL = classeessenceBLL ?? throw new ArgumentNullException(nameof(classeessenceBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<ClasseEssenceListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _classeessenceBLL.ObtenireClasseEssenceListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id classeessence</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<ClasseEssenceReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _classeessenceBLL.ObtenireClasseEssenceParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<ClasseEssenceReponse>>> CreationAsync([FromBody] ClasseEssenceRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ClasseEssenceReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _classeessenceBLL.CreationClasseEssence(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="classeessenceid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{classeessenceid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ClasseEssenceReponse>>> MisejourAsync(int classeessenceid, [FromBody] ClasseEssenceEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ClasseEssenceReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _classeessenceBLL.MisejourClasseEssence(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="classeessenceid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{classeessenceid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ClasseEssenceReponse>>> SuppressionAsync(int classeessenceid)
		{
			var response = await _classeessenceBLL.SuppressionClasseEssence(classeessenceid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
