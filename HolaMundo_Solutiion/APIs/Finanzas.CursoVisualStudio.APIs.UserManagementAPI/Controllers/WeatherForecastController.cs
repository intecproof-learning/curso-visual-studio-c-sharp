using Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Implementations;
using Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Interfaces;
using Finanzas.CursoVisualStudio.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Finanzas.CusroVisualStudio.APIs.UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[] {"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"};

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("get/user/{criteria}")]
        public IActionResult
            GetUSer(String criteria)
        {
            IUserManagementBusiness uBusiness =
                new UserManagementBusiness();

            var result = uBusiness
                .GetUser(criteria.ToLower());

            if (result.IsSucess == false)
            {
                return this.StatusCode((int)HttpStatusCode.InternalServerError, result);
            }

            return Ok(result);
        }

        /*httpClient://localhost:5411/api
        /WeatherForecast/get/user/asdasds */
        [HttpPost("create/user")]
        public IActionResult CreateOrUpdateUSer(User item)
        {
            IUserManagementBusiness uBusiness =
                new UserManagementBusiness();

            var result = uBusiness.CreateOrUpdateUser(item);

            if (result.IsSucess == false)
            {
                return this.StatusCode((int)HttpStatusCode.InternalServerError, result);
            }

            return Ok(result);
        }
    }
}