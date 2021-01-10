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
{	[Route("api/densiteboiss")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class DensiteBoisController : ControllerBase
	{

		private readonly IDensiteBoisBLL _densiteboisBLL;
		private readonly ILogger<DensiteBoisController> _logger;
		public DensiteBoisController(IDensiteBoisBLL densiteboisBLL, ILogger<DensiteBoisController> logger)
		{
			_densiteboisBLL = densiteboisBLL ?? throw new ArgumentNullException(nameof(densiteboisBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<DensiteBoisListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _densiteboisBLL.ObtenireDensiteBoisListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id densitebois</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<DensiteBoisReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _densiteboisBLL.ObtenireDensiteBoisParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<DensiteBoisReponse>>> CreationAsync([FromBody] DensiteBoisRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<DensiteBoisReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _densiteboisBLL.CreationDensiteBois(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="densiteboisid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{densiteboisid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<DensiteBoisReponse>>> MisejourAsync(int densiteboisid, [FromBody] DensiteBoisEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<DensiteBoisReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _densiteboisBLL.MisejourDensiteBois(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="densiteboisid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{densiteboisid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<DensiteBoisReponse>>> SuppressionAsync(int densiteboisid)
		{
			var response = await _densiteboisBLL.SuppressionDensiteBois(densiteboisid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
