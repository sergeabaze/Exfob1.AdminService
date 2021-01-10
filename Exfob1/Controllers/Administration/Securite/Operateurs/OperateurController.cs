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
{	[Route("api/operateurs")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class OperateurController : ControllerBase
	{

		private readonly IOperateurBLL _operateurBLL;
		private readonly ILogger<OperateurController> _logger;
		public OperateurController(IOperateurBLL operateurBLL, ILogger<OperateurController> logger)
		{
			_operateurBLL = operateurBLL ?? throw new ArgumentNullException(nameof(operateurBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<OperateurListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _operateurBLL.ObtenireOperateurListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id operateur</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<OperateurReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _operateurBLL.ObtenireOperateurParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<OperateurReponse>>> CreationAsync([FromBody] OperateurRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<OperateurReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _operateurBLL.CreationOperateur(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="operateurid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{operateurid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<OperateurReponse>>> MisejourAsync(int operateurid, [FromBody] OperateurEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<OperateurReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _operateurBLL.MisejourOperateur(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="operateurid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{operateurid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<OperateurReponse>>> SuppressionAsync(int operateurid)
		{
			var response = await _operateurBLL.SuppressionOperateur(operateurid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
