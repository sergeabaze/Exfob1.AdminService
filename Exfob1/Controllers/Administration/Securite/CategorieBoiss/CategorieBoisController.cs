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
{	[Route("api/categorieboiss")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class CategorieBoisController : ControllerBase
	{

		private readonly ICategorieBoisBLL _categorieboisBLL;
		private readonly ILogger<CategorieBoisController> _logger;
		public CategorieBoisController(ICategorieBoisBLL categorieboisBLL, ILogger<CategorieBoisController> logger)
		{
			_categorieboisBLL = categorieboisBLL ?? throw new ArgumentNullException(nameof(categorieboisBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<CategorieBoisListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _categorieboisBLL.ObtenireCategorieBoisListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id categoriebois</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<CategorieBoisReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _categorieboisBLL.ObtenireCategorieBoisParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<CategorieBoisReponse>>> CreationAsync([FromBody] CategorieBoisRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<CategorieBoisReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _categorieboisBLL.CreationCategorieBois(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="categorieboisid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{categorieboisid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<CategorieBoisReponse>>> MisejourAsync(int categorieboisid, [FromBody] CategorieBoisEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<CategorieBoisReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _categorieboisBLL.MisejourCategorieBois(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="categorieboisid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{categorieboisid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<CategorieBoisReponse>>> SuppressionAsync(int categorieboisid)
		{
			var response = await _categorieboisBLL.SuppressionCategorieBois(categorieboisid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
