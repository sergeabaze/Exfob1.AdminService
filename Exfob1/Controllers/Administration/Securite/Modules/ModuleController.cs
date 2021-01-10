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
{	[Route("api/modules")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class ModuleController : ControllerBase
	{

		private readonly IModuleBLL _moduleBLL;
		private readonly ILogger<ModuleController> _logger;
		public ModuleController(IModuleBLL moduleBLL, ILogger<ModuleController> logger)
		{
			_moduleBLL = moduleBLL ?? throw new ArgumentNullException(nameof(moduleBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<ModuleListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _moduleBLL.ObtenireModuleListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id module</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<ModuleReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _moduleBLL.ObtenireModuleParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<ModuleReponse>>> CreationAsync([FromBody] ModuleRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ModuleReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _moduleBLL.CreationModule(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="moduleid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{moduleid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ModuleReponse>>> MisejourAsync(int moduleid, [FromBody] ModuleEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ModuleReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _moduleBLL.MisejourModule(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="moduleid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{moduleid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ModuleReponse>>> SuppressionAsync(int moduleid)
		{
			var response = await _moduleBLL.SuppressionModule(moduleid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
