using JayRideTest.Client;
using JayRideTest.DTO;
using JayRideTest.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace JayRideTest.Controllers
{
    [Route("location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly AppConfig _appConfig;

        public LocationController(AppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        [HttpGet]
        public async Task<IActionResult> GetLocationData(string ip)
        {
            try
            {
                var restClient = new RestClient(_appConfig.IpStockApiBaseUrl);
                var endpoint = $"/{ip}?access_key={_appConfig.IpStackApiAccessKey}";
                var locationData = await restClient.GetAsync<IpStackLocationDto>(endpoint);
                return Ok(new { locationData.city });                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
