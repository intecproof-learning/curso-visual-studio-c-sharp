using Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Interfaces;
using Finanzas.CursoVisualStudio.DataAccess.Repositories.Implementations;
using Finanzas.CursoVisualStudio.Shared.DTOs;
using Finanzas.CursoVisualStudio.Shared.Utilities;
using System.ComponentModel.DataAnnotations;
using Sql = Finanzas.CursoVisualStudio.DataAccess.SQLDatabase.Models;

namespace Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Implementations
{
    public class UserManagementBusiness : IUserManagementBusiness
    {
        private UnitOfWork uWork;

        public UserManagementBusiness()
        {
            this.uWork = new UnitOfWork();
        }

        public ObjectResponse<User> CreateOrUpdateUser(User item)
        {
            try
            {
                ICollection<ValidationResult> vResult = new List<ValidationResult>();
                String message = "Ocurrieron uno o varios errores al validar el modelo";
                bool isSuccess = false;

                if (Utilities.IsValidModel<User>(item, out vResult) == true)
                {
                    if (item.ID != 0 && uWork.UserRepo.Search(u => u.Id == item.ID).Any() == true)
                    {
                        uWork.UserRepo.Modify(ConvertUserDtoToUserSql(item));

                        message = $"El usuario \"{item.NickName}\" se actualizó correctamente";
                        isSuccess = true;
                    }
                    else if (item.ID != 0)
                    {
                        uWork.UserRepo.Add(ConvertUserDtoToUserSql(item));
                        message = $"El usuario \"{item.NickName}\" se insertó correctamente";
                        isSuccess = true;
                    }
                    else
                    {
                        message = $"El usuario \"{item.NickName}\" con ID: \"{item.ID}\" que intentas actualizar no existe";
                        isSuccess = false;
                    }
                }

                return new ObjectResponse<User>()
                {
                    Errors = vResult,
                    Message = message,
                    ObjectResult = item,
                    IsSucess = isSuccess
                };
            }
            catch
            {
                throw;
            }
        }

        public ObjectResponse<List<User>> GetUser(String criteria)
        {
            var result = this.uWork.UserRepo
            .Search(u => u.Id.ToString() == criteria
            || u.NickName.ToLower().Contains(criteria)
            || u.Email.ToLower().Contains(criteria), user => user.OrderBy(u => u.NickName));

            List<User> resultDTO = new List<User>();
            result.ForEach(a => resultDTO.Add(this.ConvertUserSqlToUserDto(a)));

            return new ObjectResponse<List<User>>()
            {
                IsSucess = true,
                Message = result == null || result.Any() == false ?
                "No se encontraron coincidencias que empaten con el criterio de búsqueda"
                : $"Se encontraron {result.Count} coincidencias",
                Errors = null,
                ObjectResult = resultDTO
            };
        }

        public ObjectResponse<User> DeleteUser(int ID)
        {
            var result = uWork.UserRepo.Search(u => u.Id == ID);
            var response = new ObjectResponse<User>()
            {
                IsSucess = result == null || result.Any() == false ? false : true,
                Message = result == null || result.Any() == false ?
                "No se encontraron coincidencias que empaten con el criterio de búsqueda"
                : $"El usuario {result.First().NickName} se eliminó correctamente",
                Errors = null,
            };

            if (result.Any())
            {
                response.ObjectResult = this.ConvertUserSqlToUserDto(this.uWork.UserRepo.Delete(result.First()));
            }

            return response;
        }

        private Sql.User ConvertUserDtoToUserSql(Shared.DTOs.User dto)
        {
            return new Sql.User()
            {
                Email = dto.Email,
                Id = dto.ID,
                NickName = dto.NickName,
                Password = dto.Password
            };
        }
        private User ConvertUserSqlToUserDto(Sql.User dto)
        {
            return new User()
            {
                Email = dto.Email,
                ID = dto.Id,
                NickName = dto.NickName,
                Password = dto.Password
            };
        }
    }
}