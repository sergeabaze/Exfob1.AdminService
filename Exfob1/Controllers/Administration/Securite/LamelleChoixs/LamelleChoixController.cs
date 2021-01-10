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
{	[Route("api/lamellechoixs")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class LamelleChoixController : ControllerBase
	{

		private readonly ILamelleChoixBLL _lamellechoixBLL;
		private readonly ILogger<LamelleChoixController> _logger;
		public LamelleChoixController(ILamelleChoixBLL lamellechoixBLL, ILogger<LamelleChoixController> logger)
		{
			_lamellechoixBLL = lamellechoixBLL ?? throw new ArgumentNullException(nameof(lamellechoixBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<LamelleChoixListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _lamellechoixBLL.ObtenireLamelleChoixListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id lamellechoix</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<LamelleChoixReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _lamellechoixBLL.ObtenireLamelleChoixParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<LamelleChoixReponse>>> CreationAsync([FromBody] LamelleChoixRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<LamelleChoixReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _lamellechoixBLL.CreationLamelleChoix(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="lamellechoixid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{lamellechoixid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<LamelleChoixReponse>>> MisejourAsync(int lamellechoixid, [FromBody] LamelleChoixEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<LamelleChoixReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _lamellechoixBLL.MisejourLamelleChoix(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="lamellechoixid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{lamellechoixid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<LamelleChoixReponse>>> SuppressionAsync(int lamellechoixid)
		{
			var response = await _lamellechoixBLL.SuppressionLamelleChoix(lamellechoixid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
