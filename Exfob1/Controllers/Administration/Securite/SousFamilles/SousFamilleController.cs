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
{	[Route("api/sousfamilles")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class SousFamilleController : ControllerBase
	{

		private readonly ISousFamilleBLL _sousfamilleBLL;
		private readonly ILogger<SousFamilleController> _logger;
		public SousFamilleController(ISousFamilleBLL sousfamilleBLL, ILogger<SousFamilleController> logger)
		{
			_sousfamilleBLL = sousfamilleBLL ?? throw new ArgumentNullException(nameof(sousfamilleBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<SousFamilleListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _sousfamilleBLL.ObtenireSousFamilleListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id sousfamille</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<SousFamilleReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _sousfamilleBLL.ObtenireSousFamilleParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<SousFamilleReponse>>> CreationAsync([FromBody] SousFamilleRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SousFamilleReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _sousfamilleBLL.CreationSousFamille(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="sousfamilleid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{sousfamilleid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SousFamilleReponse>>> MisejourAsync(int sousfamilleid, [FromBody] SousFamilleEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<SousFamilleReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _sousfamilleBLL.MisejourSousFamille(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="sousfamilleid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{sousfamilleid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<SousFamilleReponse>>> SuppressionAsync(int sousfamilleid)
		{
			var response = await _sousfamilleBLL.SuppressionSousFamille(sousfamilleid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
