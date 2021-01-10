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
{	[Route("api/typeclients")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class TypeClientController : ControllerBase
	{

		private readonly ITypeClientBLL _typeclientBLL;
		private readonly ILogger<TypeClientController> _logger;
		public TypeClientController(ITypeClientBLL typeclientBLL, ILogger<TypeClientController> logger)
		{
			_typeclientBLL = typeclientBLL ?? throw new ArgumentNullException(nameof(typeclientBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<TypeClientListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _typeclientBLL.ObtenireTypeClientListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id typeclient</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<TypeClientReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _typeclientBLL.ObtenireTypeClientParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<TypeClientReponse>>> CreationAsync([FromBody] TypeClientRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TypeClientReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _typeclientBLL.CreationTypeClient(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="typeclientid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{typeclientid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TypeClientReponse>>> MisejourAsync(int typeclientid, [FromBody] TypeClientEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TypeClientReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _typeclientBLL.MisejourTypeClient(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="typeclientid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{typeclientid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TypeClientReponse>>> SuppressionAsync(int typeclientid)
		{
			var response = await _typeclientBLL.SuppressionTypeClient(typeclientid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
