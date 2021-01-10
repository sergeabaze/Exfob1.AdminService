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
{	[Route("api/navires")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class NavireController : ControllerBase
	{

		private readonly INavireBLL _navireBLL;
		private readonly ILogger<NavireController> _logger;
		public NavireController(INavireBLL navireBLL, ILogger<NavireController> logger)
		{
			_navireBLL = navireBLL ?? throw new ArgumentNullException(nameof(navireBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<NavireListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _navireBLL.ObtenireNavireListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id navire</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<NavireReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _navireBLL.ObtenireNavireParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<NavireReponse>>> CreationAsync([FromBody] NavireRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<NavireReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _navireBLL.CreationNavire(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="navireid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{navireid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<NavireReponse>>> MisejourAsync(int navireid, [FromBody] NavireEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<NavireReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _navireBLL.MisejourNavire(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="navireid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{navireid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<NavireReponse>>> SuppressionAsync(int navireid)
		{
			var response = await _navireBLL.SuppressionNavire(navireid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
