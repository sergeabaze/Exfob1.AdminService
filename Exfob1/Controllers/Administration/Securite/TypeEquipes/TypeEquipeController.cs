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
{	[Route("api/typeequipes")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class TypeEquipeController : ControllerBase
	{

		private readonly ITypeEquipeBLL _typeequipeBLL;
		private readonly ILogger<TypeEquipeController> _logger;
		public TypeEquipeController(ITypeEquipeBLL typeequipeBLL, ILogger<TypeEquipeController> logger)
		{
			_typeequipeBLL = typeequipeBLL ?? throw new ArgumentNullException(nameof(typeequipeBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<TypeEquipeListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _typeequipeBLL.ObtenireTypeEquipeListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id typeequipe</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<TypeEquipeReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _typeequipeBLL.ObtenireTypeEquipeParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<TypeEquipeReponse>>> CreationAsync([FromBody] TypeEquipeRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TypeEquipeReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _typeequipeBLL.CreationTypeEquipe(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="typeequipeid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{typeequipeid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TypeEquipeReponse>>> MisejourAsync(int typeequipeid, [FromBody] TypeEquipeEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TypeEquipeReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _typeequipeBLL.MisejourTypeEquipe(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="typeequipeid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{typeequipeid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TypeEquipeReponse>>> SuppressionAsync(int typeequipeid)
		{
			var response = await _typeequipeBLL.SuppressionTypeEquipe(typeequipeid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
