using Microsoft.AspNetCore.Mvc;

namespace JayRideTest.Controllers
{
    [ApiController]
    [Route("candidate")]
    public class CandidateController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCandidateData()
        {
            var candidateData = new
            {
                name = "test",
                phone = "test"
            };

            return Ok(candidateData);
        }
    }
}