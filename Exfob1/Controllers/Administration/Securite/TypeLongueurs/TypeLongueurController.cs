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
{	[Route("api/typelongueurs")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class TypeLongueurController : ControllerBase
	{

		private readonly ITypeLongueurBLL _typelongueurBLL;
		private readonly ILogger<TypeLongueurController> _logger;
		public TypeLongueurController(ITypeLongueurBLL typelongueurBLL, ILogger<TypeLongueurController> logger)
		{
			_typelongueurBLL = typelongueurBLL ?? throw new ArgumentNullException(nameof(typelongueurBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<TypeLongueurListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _typelongueurBLL.ObtenireTypeLongueurListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id typelongueur</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<TypeLongueurReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _typelongueurBLL.ObtenireTypeLongueurParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<TypeLongueurReponse>>> CreationAsync([FromBody] TypeLongueurRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TypeLongueurReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _typelongueurBLL.CreationTypeLongueur(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="typelongueurid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{typelongueurid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TypeLongueurReponse>>> MisejourAsync(int typelongueurid, [FromBody] TypeLongueurEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TypeLongueurReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _typelongueurBLL.MisejourTypeLongueur(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="typelongueurid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{typelongueurid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TypeLongueurReponse>>> SuppressionAsync(int typelongueurid)
		{
			var response = await _typelongueurBLL.SuppressionTypeLongueur(typelongueurid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
