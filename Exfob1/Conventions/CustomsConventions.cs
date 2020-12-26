using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Exfob1.Conventions
{
    public static class CustomsConventions
    {
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public static void Insert(
             [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
              [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object model) { }
    }
}
