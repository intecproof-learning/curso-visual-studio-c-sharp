using Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Implementations;
using Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Interfaces;
using Finanzas.CursoVisualStudio.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Finanzas.CursoVisualStudio.APIs.UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpDelete("delete/{id:int}")]
        public IActionResult
            DeleteUser(int id)
        {
            IUserManagementBusiness uBusiness =
                new UserManagementBusiness();

            var result = uBusiness
                .DeleteUser(id);

            if (result.IsSucess == false)
            {
                return this.StatusCode((int)HttpStatusCode.InternalServerError, result);
            }

            return Ok(result);
        }

        [HttpGet("get")]
        public IActionResult
            GetUser(String? criteria)
        {
            IUserManagementBusiness uBusiness =
                new UserManagementBusiness();

            var result = uBusiness
                .GetUser(criteria);

            if (result.IsSucess == false)
            {
                return this.StatusCode((int)HttpStatusCode.InternalServerError, result);
            }

            return Ok(result);
        }

        /*httpClient://localhost:5411/api
        /WeatherForecast/get/user/asdasds */
        [HttpPost("create")]
        public IActionResult CreateOrUpdateUser(User item)
        {
            try
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
            catch (Exception ex)
            {
                //Registro del error para su control
                return this.StatusCode((int)HttpStatusCode.InternalServerError);
            }
            finally
            {
                //Este bloque se ejecutará siempre
                //No importa si se ejecutó correctamente o no
            }
        }
    }
}