using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RepositoryModel.Model;
using RepositoryModel.response;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NexusApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> LoginAsync(UserData model)
        {
            var url = "https://courierdemo.azurewebsites.net/api/membership/login";
            var jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            using (var httpClient = new HttpClient()) { 
                var UserSerialized = System.Text.Json.JsonSerializer.Serialize(model);
                var content = new StringContent(UserSerialized, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, content);

            var responseString = await response.Content.ReadAsStringAsync();

            return Content(responseString);
            }

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> getPackage()
        {

            var url = "https://courierdemo.azurewebsites.net/api/packages/getPending?username={}";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(url);
                return Content(response);
            }
        }
    }
}
