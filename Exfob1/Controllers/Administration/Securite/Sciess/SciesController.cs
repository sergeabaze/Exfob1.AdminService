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
{	[Route("api/sciess")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class SciesController : ControllerBase
	{

		private readonly ISciesBLL _sciesBLL;
		private readonly ILogger<SciesController> _logger;
		public SciesController(ISciesBLL sciesBLL, ILogger<SciesController> logger)
		{
			_sciesBLL = sciesBLL ?? throw new ArgumentNullException(nameof(sciesBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<SciesListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _sciesBLL.ObtenireSciesListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id scies</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<SciesReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _sciesBLL.ObtenireSciesParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<SciesReponse>>> CreationAsync([FromBody] SciesRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SciesReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _sciesBLL.CreationScies(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="sciesid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{sciesid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SciesReponse>>> MisejourAsync(int sciesid, [FromBody] SciesEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SciesReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _sciesBLL.MisejourScies(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="sciesid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{sciesid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SciesReponse>>> SuppressionAsync(int sciesid)
		{
			var response = await _sciesBLL.SuppressionScies(sciesid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
