using JayRideTest.Client;
using JayRideTest.DTO;
using JayRideTest.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace JayRideTest.Controllers
{
    [Route("listings")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly AppConfig _appConfig;

        public ListingController(AppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        [HttpGet]
        public async Task<IActionResult> GetListingData(int numberOfPassengers)
        {
            try
            {
                if (numberOfPassengers <= 0) return BadRequest("Number of passengers need to be greater than 0");
                var restClient = new RestClient(_appConfig.JayRideBaseUrl);
                var endpoint = "/api/QuoteRequest";

                var listingData = await restClient.GetAsync<QuoteRequestDto>(endpoint);
                if (listingData == null || listingData.listings == null || !listingData.listings.Any())
                {
                    return NotFound("No listings found.");
                }
                //1. Filter the listing that support >= to numberOfPassengers
                //2. Create a filtered listing with appropriate listing object
                //3. Order by total price 
                var filtertedListing = listingData.listings
                                        .Where(listing => listing.vehicleType.maxPassengers >= numberOfPassengers)
                                        .Select(listing =>
                                        new FilteredListingDto(listing.name, listing.pricePerPassenger,
                                        listing.vehicleType, new decimal(listing.pricePerPassenger * numberOfPassengers)))
                                        .ToList().OrderBy(listing => listing.TotalPrice);

                if (!filtertedListing.Any())
                {
                    return NotFound("No listing supports the number of passengers.");
                }

                return Ok(new { filtertedListing });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
