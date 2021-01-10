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
{	[Route("api/typeoperateurs")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class TypeOperateurController : ControllerBase
	{

		private readonly ITypeOperateurBLL _typeoperateurBLL;
		private readonly ILogger<TypeOperateurController> _logger;
		public TypeOperateurController(ITypeOperateurBLL typeoperateurBLL, ILogger<TypeOperateurController> logger)
		{
			_typeoperateurBLL = typeoperateurBLL ?? throw new ArgumentNullException(nameof(typeoperateurBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<TypeOperateurListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _typeoperateurBLL.ObtenireTypeOperateurListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id typeoperateur</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<TypeOperateurReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _typeoperateurBLL.ObtenireTypeOperateurParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<TypeOperateurReponse>>> CreationAsync([FromBody] TypeOperateurRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TypeOperateurReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _typeoperateurBLL.CreationTypeOperateur(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="typeoperateurid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{typeoperateurid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TypeOperateurReponse>>> MisejourAsync(int typeoperateurid, [FromBody] TypeOperateurEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TypeOperateurReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _typeoperateurBLL.MisejourTypeOperateur(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="typeoperateurid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{typeoperateurid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TypeOperateurReponse>>> SuppressionAsync(int typeoperateurid)
		{
			var response = await _typeoperateurBLL.SuppressionTypeOperateur(typeoperateurid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
