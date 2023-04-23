using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RobotApocalypse.Dtos;
using RobotApocalypse.Enums;

namespace RobotApocalypse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://robotstakeover20210903110417.azurewebsites.net/");
                var response = await client.GetAsync("robotcpu");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<IEnumerable<Robot>>();
                    return Ok(result);
                }
            }

            return BadRequest();
        }

        [HttpGet("{category}")]
        public async Task<IActionResult> GetByCategory(RobotCategories category)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://robotstakeover20210903110417.azurewebsites.net/");
                var response = await client.GetAsync("robotcpu");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<IEnumerable<Robot>>();
                    if (category != RobotCategories.All)
                    {
                        result = result?.Where(r => r.Category == category.ToString());
                    }
                    return Ok(result);
                }
            }

            return BadRequest();
        }
    }
}
