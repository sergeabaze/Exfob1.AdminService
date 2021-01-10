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
{	[Route("api/sechoirs")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class SechoirController : ControllerBase
	{

		private readonly ISechoirBLL _sechoirBLL;
		private readonly ILogger<SechoirController> _logger;
		public SechoirController(ISechoirBLL sechoirBLL, ILogger<SechoirController> logger)
		{
			_sechoirBLL = sechoirBLL ?? throw new ArgumentNullException(nameof(sechoirBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<SechoirListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _sechoirBLL.ObtenireSechoirListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id sechoir</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<SechoirReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _sechoirBLL.ObtenireSechoirParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<SechoirReponse>>> CreationAsync([FromBody] SechoirRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SechoirReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _sechoirBLL.CreationSechoir(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="sechoirid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{sechoirid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SechoirReponse>>> MisejourAsync(int sechoirid, [FromBody] SechoirEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SechoirReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _sechoirBLL.MisejourSechoir(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="sechoirid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{sechoirid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SechoirReponse>>> SuppressionAsync(int sechoirid)
		{
			var response = await _sechoirBLL.SuppressionSechoir(sechoirid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
