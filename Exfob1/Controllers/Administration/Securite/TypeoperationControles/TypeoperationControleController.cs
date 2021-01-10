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
{	[Route("api/typeoperationcontroles")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public class TypeoperationControleController : ControllerBase
	{

		private readonly ITypeoperationControleBLL _typeoperationcontroleBLL;
		private readonly ILogger<TypeoperationControleController> _logger;
		public TypeoperationControleController(ITypeoperationControleBLL typeoperationcontroleBLL, ILogger<TypeoperationControleController> logger)
		{
			_typeoperationcontroleBLL = typeoperationcontroleBLL ?? throw new ArgumentNullException(nameof(typeoperationcontroleBLL));
			_logger = logger;
		}

		/// <summary>
		/// liste
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>retourne collection</returns>
		[HttpGet("list")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiListResponse<TypeoperationControleListe>>> obtenireListeAsync(CancellationToken cancellationToken)
		{
			var response = await _typeoperationcontroleBLL.ObtenireTypeoperationControleListe()
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// obtenire par id
		/// </summary>
		/// <param name="id">id typeoperationcontrole</param>
		/// <returns>retourne objet</returns>
		/// <response code="200">Si retourne un objet </response>
		/// <response code="404">Si le l'objet n'existe pas</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<WebApiSingleResponse<TypeoperationControleReponse>>> obtenireParIdAsync(int id)
		{
			var response = await _typeoperationcontroleBLL.ObtenireTypeoperationControleParId(id)
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
		public async Task<ActionResult<WebApiSingleResponse<TypeoperationControleReponse>>> CreationAsync([FromBody] TypeoperationControleRequest request)
		{

			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TypeoperationControleReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};

				return repo.ToHttpResponse();
			}
			var response = await _typeoperationcontroleBLL.CreationTypeoperationControle(request)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de mise à jour
		/// </summary>
		/// <param name="typeoperationcontroleid">id</param>
		/// <param name="request">objet</param>
		[HttpPut("edition/{typeoperationcontroleid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
			nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TypeoperationControleReponse>>> MisejourAsync(int typeoperationcontroleid, [FromBody] TypeoperationControleEdit request)
		{
			if (!ModelState.IsValid)
			{
				var repo = new WebApiListResponse<TypeoperationControleReponse>
				{
					CodeMessage = StatusCodes.Status400BadRequest,
					IsError = true,
					ErrorMessage = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
				};
				return repo.ToHttpResponse();
			}
			var response = await _typeoperationcontroleBLL.MisejourTypeoperationControle(request)
			    .ConfigureAwait(false);

			return response.ToHttpResponse();
		}

		/// <summary>
		/// fonction de suppression
		/// </summary>
		/// <param name="typeoperationcontroleid">id</param>
		/// <returns>status</returns>
		[HttpDelete("suppression/{typeoperationcontroleid}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ApiConventionMethod(typeof(CustomsConventions),
		       nameof(CustomsConventions.Insert))]
		public async Task<ActionResult<WebApiSingleResponse<TypeoperationControleReponse>>> SuppressionAsync(int typeoperationcontroleid)
		{
			var response = await _typeoperationcontroleBLL.SuppressionTypeoperationControle(typeoperationcontroleid)
				.ConfigureAwait(false);

			return response.ToHttpResponse();
		}
	}
}
