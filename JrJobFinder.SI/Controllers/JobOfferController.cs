using Microsoft.AspNetCore.Mvc;

namespace JrJobFinder.SI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOfferController : ControllerBase
    {
        private readonly BL.IJobOfferBL _offerManager;
        private readonly ILogger<JobOfferController> _logger;
        public JobOfferController(BL.IJobOfferBL offerManager, ILogger<JobOfferController> logger)
        {
            _offerManager = offerManager;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllJobOffers(
            [FromQuery] string? technology,
            [FromQuery] bool? isRemote,
            [FromQuery] string? level,
            [FromQuery] string? location,
            CancellationToken cancellationToken
            )
        {
            try
            {
                _logger.LogInformation(
                    "Received request to get job offers with filters - " +
                    "Technology: {Technology}, IsRemote: {IsRemote}, Level: {Level}, Location: {Location}",
                    technology, isRemote, level, location);

                var jobOffers = await _offerManager.GetAllJobOffers(technology, isRemote, level, location, cancellationToken);

                return Ok(jobOffers);
            }
            catch (OperationCanceledException)
            {
                return StatusCode(499, "Request was cancelled by the client.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving job offers: {ex.Message}");
            }
            
         }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
