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
{	[Route("api/loadingnavires")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class LoadingNavireController : ControllerBase
	{

		private readonly ILoadingNavireBLL _loadingnavireBLL;
		private readonly ILogger<LoadingNavireController> _logger;
		public LoadingNavireController(ILoadingNavireBLL loadingnavireBLL, ILogger<LoadingNavireController> logger)
		{
			_loadingnavireBLL = loadingnavireBLL ?? throw new ArgumentNullException(nameof(loadingnavireBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<LoadingNavireListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _loadingnavireBLL.ObtenireLoadingNavireListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id loadingnavire</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<LoadingNavireReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _loadingnavireBLL.ObtenireLoadingNavireParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<LoadingNavireReponse>>> CreationAsync([FromBody] LoadingNavireRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<LoadingNavireReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _loadingnavireBLL.CreationLoadingNavire(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="loadingnavireid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{loadingnavireid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<LoadingNavireReponse>>> MisejourAsync(int loadingnavireid, [FromBody] LoadingNavireEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<LoadingNavireReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _loadingnavireBLL.MisejourLoadingNavire(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="loadingnavireid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{loadingnavireid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<LoadingNavireReponse>>> SuppressionAsync(int loadingnavireid)
		{
			var response = await _loadingnavireBLL.SuppressionLoadingNavire(loadingnavireid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
