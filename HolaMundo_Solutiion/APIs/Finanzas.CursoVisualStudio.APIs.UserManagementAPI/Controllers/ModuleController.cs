using Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Implementations;
using Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Interfaces;
using Finanzas.CursoVisualStudio.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Finanzas.CursoVisualStudio.APIs.UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        [HttpDelete("delete/id")]
        public IActionResult
            DeleteUser(int id)
        {
            IModuleManagementBusiness mBusiness =
                new ModuleManagementBusiness();

            var result = mBusiness
                .DeleteModule(id);

            if (result.IsSucess == false)
            {
                return this.StatusCode((int)HttpStatusCode.InternalServerError, result);
            }

            return Ok(result);
        }

        [HttpGet("get/{criteria}")]
        public IActionResult
            GetUser(String criteria)
        {
            IModuleManagementBusiness mBusiness =
                new ModuleManagementBusiness();

            var result = mBusiness
                .GetModule(criteria.ToLower());

            if (result.IsSucess == false)
            {
                return this.StatusCode((int)HttpStatusCode.InternalServerError, result);
            }

            return Ok(result);
        }

        [HttpPost("create")]
        public IActionResult CreateOrUpdateUser(Module item)
        {
            try
            {
                IModuleManagementBusiness mBusiness =
                        new ModuleManagementBusiness();

                var result = mBusiness.CreateOrUpdateModule(item);

                if (result.IsSucess == false)
                {
                    return this.StatusCode((int)HttpStatusCode.InternalServerError, result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                //Registro del error para su control
                return this.StatusCode
                ((int)HttpStatusCode
                .InternalServerError);
            }
            finally
            {
                //Este bloque se ejecutará siempre
                //No importa si se ejecutó correctamente o no
            }
        }
    }
}
