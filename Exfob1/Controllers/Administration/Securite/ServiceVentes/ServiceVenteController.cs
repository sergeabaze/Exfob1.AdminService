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
{	[Route("api/serviceventes")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class ServiceVenteController : ControllerBase
	{

		private readonly IServiceVenteBLL _serviceventeBLL;
		private readonly ILogger<ServiceVenteController> _logger;
		public ServiceVenteController(IServiceVenteBLL serviceventeBLL, ILogger<ServiceVenteController> logger)
		{
			_serviceventeBLL = serviceventeBLL ?? throw new ArgumentNullException(nameof(serviceventeBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<ServiceVenteListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _serviceventeBLL.ObtenireServiceVenteListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id servicevente</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<ServiceVenteReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _serviceventeBLL.ObtenireServiceVenteParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<ServiceVenteReponse>>> CreationAsync([FromBody] ServiceVenteRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ServiceVenteReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _serviceventeBLL.CreationServiceVente(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="serviceventeid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{serviceventeid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ServiceVenteReponse>>> MisejourAsync(int serviceventeid, [FromBody] ServiceVenteEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<ServiceVenteReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _serviceventeBLL.MisejourServiceVente(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="serviceventeid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{serviceventeid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<ServiceVenteReponse>>> SuppressionAsync(int serviceventeid)
		{
			var response = await _serviceventeBLL.SuppressionServiceVente(serviceventeid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
