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
{	[Route("api/listeserviceventes")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class ListeServiceVenteController : ControllerBase
	{

		private readonly IListeServiceVenteBLL _listeserviceventeBLL;
		private readonly ILogger<ListeServiceVenteController> _logger;
		public ListeServiceVenteController(IListeServiceVenteBLL listeserviceventeBLL, ILogger<ListeServiceVenteController> logger)
		{
			_listeserviceventeBLL = listeserviceventeBLL ?? throw new ArgumentNullException(nameof(listeserviceventeBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<ListeServiceVenteListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _listeserviceventeBLL.ObtenireListeServiceVenteListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id listeservicevente</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<ListeServiceVenteReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _listeserviceventeBLL.ObtenireListeServiceVenteParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<ListeServiceVenteReponse>>> CreationAsync([FromBody] ListeServiceVenteRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ListeServiceVenteReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _listeserviceventeBLL.CreationListeServiceVente(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="listeserviceventeid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{listeserviceventeid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ListeServiceVenteReponse>>> MisejourAsync(int listeserviceventeid, [FromBody] ListeServiceVenteEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ListeServiceVenteReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _listeserviceventeBLL.MisejourListeServiceVente(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="listeserviceventeid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{listeserviceventeid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ListeServiceVenteReponse>>> SuppressionAsync(int listeserviceventeid)
		{
			var response = await _listeserviceventeBLL.SuppressionListeServiceVente(listeserviceventeid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
