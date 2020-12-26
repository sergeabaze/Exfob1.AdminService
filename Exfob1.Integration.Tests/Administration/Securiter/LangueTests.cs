using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Exfob1.Integration.Tests.Administration.Securiter
{
   public  class LangueTests
         : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public LangueTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnokOnValideListe()
        {
            // Arrange
            var _url = "api/langues/list";
            var _client = _factory.CreateClient();

            // Act
            var response = await _client.GetAsync(_url);

            // Assert
            response.EnsureSuccessStatusCode();

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            
        }

    }
}
