using FoxAdmTool.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FoxAdmTool.Tests
{
    public class UserIntegrationTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UserIntegrationTests()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task UserGetAll_Success()
        {
            //Act
            var response = _client.GetAsync("/users/").Result;
           
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetUserProductsInfoByCpf_Success()
        {
            //Arrange
            var body = new { cpf = "12345678911" };
            var jsonBody = JsonConvert.SerializeObject(body);
            var data = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            //Act
            var response = _client.PostAsync("/users/userproducts/allinfo/", data).Result;

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}