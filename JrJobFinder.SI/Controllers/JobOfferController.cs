using JrJobFinder.Models.Entities;
using JrJobFinder.Models.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using JrJobFinder.BL.Interfaces;

namespace JrJobFinder.SI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOfferController : ControllerBase
    {
        private readonly IJobOfferBL _offerManager;
        private readonly ILogger<JobOfferController> _logger;
        public JobOfferController(IJobOfferBL offerManager, ILogger<JobOfferController> logger)
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

                var jobOffers = await _offerManager.GetAllJobOffers
                    (technology, isRemote, level, location, cancellationToken);

                var result = jobOffers.Select(offer => new ListJobOfferDTO
                {
                    Id = offer.Id,
                    Title = offer.Title,
                    Company = offer.Company,
                    Technologies = offer.Technologies,
                    ExperienceLevel = offer.ExperienceLevel,
                    Location = offer.Location,
                    IsRemote = offer.IsRemote,
                    Source = offer.Source,
                    PostedDate = offer.PostedDate
                });

                return Ok(result);
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

        [HttpPost]
        public async Task<IActionResult> CreatedJobOffer([FromBody] CreateJobOfferDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var jobOffers = new JobOffer
                {
                    Title = dto.Title,
                    Company = dto.Company,
                    Technologies = dto.Technologies,
                    ExperienceLevel = dto.ExperienceLevel,
                    Location = dto.Location ?? "Not specified",
                    IsRemote = dto.IsRemote,
                    Source = dto.Source ?? "User submission",

                };
                _logger.LogInformation(
                    "Received request to create a job offer - " +
                    "Title: {Title}, Company: {Company}, Technologies: {Technologies}, " +
                    "ExperienceLevel: {ExperienceLevel}, Location: {Location}, IsRemote: {IsRemote}, Source: {Source}",
                    jobOffers.Title, jobOffers.Company, jobOffers.Technologies,
                    jobOffers.ExperienceLevel, jobOffers.Location, jobOffers.IsRemote, jobOffers.Source);

                var createdOffer = await _offerManager.CreateJobOffer(jobOffers);

                return CreatedAtAction(nameof(GetAllJobOffers), new { id = createdOffer.Id }, createdOffer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the job offer: {ex.Message}");
            }
        }
    }
}
