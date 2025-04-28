using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly CountriesRepository _countriesRepository;

        public CountriesController()
        {
            _countriesRepository = new CountriesRepository();
        }

        [HttpGet]
        public List<CountryModel> Get()
        {
            var countries = _countriesRepository.GetCountries();
            return countries;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateCountry(CountryModel country)
        {
            try
            {
                if (country == null)
                {
                    return BadRequest();
                }

                CountriesRepository countriesRepository = new CountriesRepository();
                var result = countriesRepository.CreateCountry(country);
                return new JsonResult(result);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creando país");
            }
        }
    }
}
