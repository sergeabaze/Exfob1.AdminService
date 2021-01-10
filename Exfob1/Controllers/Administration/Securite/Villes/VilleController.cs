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
{	[Route("api/villes")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class VilleController : ControllerBase
	{

		private readonly IVilleBLL _villeBLL;
		private readonly ILogger<VilleController> _logger;
		public VilleController(IVilleBLL villeBLL, ILogger<VilleController> logger)
		{
			_villeBLL = villeBLL ?? throw new ArgumentNullException(nameof(villeBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<VilleListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _villeBLL.ObtenireVilleListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id ville</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<VilleReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _villeBLL.ObtenireVilleParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<VilleReponse>>> CreationAsync([FromBody] VilleRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<VilleReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _villeBLL.CreationVille(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="villeid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{villeid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<VilleReponse>>> MisejourAsync(int villeid, [FromBody] VilleEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<VilleReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _villeBLL.MisejourVille(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="villeid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{villeid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<VilleReponse>>> SuppressionAsync(int villeid)
		{
			var response = await _villeBLL.SuppressionVille(villeid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
