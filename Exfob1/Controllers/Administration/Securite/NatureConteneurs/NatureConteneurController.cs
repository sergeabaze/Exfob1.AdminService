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
{	[Route("api/natureconteneurs")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class NatureConteneurController : ControllerBase
	{

		private readonly INatureConteneurBLL _natureconteneurBLL;
		private readonly ILogger<NatureConteneurController> _logger;
		public NatureConteneurController(INatureConteneurBLL natureconteneurBLL, ILogger<NatureConteneurController> logger)
		{
			_natureconteneurBLL = natureconteneurBLL ?? throw new ArgumentNullException(nameof(natureconteneurBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<NatureConteneurListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _natureconteneurBLL.ObtenireNatureConteneurListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id natureconteneur</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<NatureConteneurReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _natureconteneurBLL.ObtenireNatureConteneurParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<NatureConteneurReponse>>> CreationAsync([FromBody] NatureConteneurRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<NatureConteneurReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _natureconteneurBLL.CreationNatureConteneur(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="natureconteneurid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{natureconteneurid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<NatureConteneurReponse>>> MisejourAsync(int natureconteneurid, [FromBody] NatureConteneurEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<NatureConteneurReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _natureconteneurBLL.MisejourNatureConteneur(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="natureconteneurid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{natureconteneurid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<NatureConteneurReponse>>> SuppressionAsync(int natureconteneurid)
		{
			var response = await _natureconteneurBLL.SuppressionNatureConteneur(natureconteneurid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
