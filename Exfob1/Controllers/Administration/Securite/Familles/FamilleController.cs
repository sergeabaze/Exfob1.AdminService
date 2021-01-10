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
{	[Route("api/familles")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class FamilleController : ControllerBase
	{

		private readonly IFamilleBLL _familleBLL;
		private readonly ILogger<FamilleController> _logger;
		public FamilleController(IFamilleBLL familleBLL, ILogger<FamilleController> logger)
		{
			_familleBLL = familleBLL ?? throw new ArgumentNullException(nameof(familleBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<FamilleListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _familleBLL.ObtenireFamilleListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id famille</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<FamilleReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _familleBLL.ObtenireFamilleParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<FamilleReponse>>> CreationAsync([FromBody] FamilleRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<FamilleReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _familleBLL.CreationFamille(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="familleid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{familleid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<FamilleReponse>>> MisejourAsync(int familleid, [FromBody] FamilleEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<FamilleReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _familleBLL.MisejourFamille(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="familleid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{familleid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<FamilleReponse>>> SuppressionAsync(int familleid)
		{
			var response = await _familleBLL.SuppressionFamille(familleid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
