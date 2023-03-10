using Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Interfaces;
using Finanzas.CursoVisualStudio.DataAccess.Repositories.Implementations;
using Finanzas.CursoVisualStudio.Shared.DTOs;
using Finanzas.CursoVisualStudio.Shared.Utilities;
using System.ComponentModel.DataAnnotations;

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
                    if (uWork.UserRepo.Search(u => u.Id == item.ID).Any() == true)
                    {
                        uWork.UserRepo.Modify(ConvertUserDtoToUserSql(item), u => u.Id == item.ID, (nUser, cUser) =>
                        {
                            cUser.Email = nUser.Email;
                            cUser.NickName = nUser.NickName;
                            cUser.Password = nUser.Password;
                        });

                        message = $"El usuario \"{item.NickName}\" se actualizó correctamente";
                        isSuccess = true;
                    }
                    else
                    {
                        uWork.UserRepo.Add(ConvertUserDtoToUserSql(item));
                        message = $"El usuario \"{item.NickName}\" se insertó correctamente";
                        isSuccess = true;
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

        public ObjectResponse<List<User>>
            GetUser(String criteria)
        {
            var result = this.uWork.UserRepo
            .Search(u => u.Id.ToString() == criteria
            || u.NickName.ToLower().Contains(criteria)
            || u.Email.ToLower().Contains(criteria));


            return new ObjectResponse<List<User>>()
            {
                IsSucess = true,
                Message = result == null || result.Any() == false ?
                "No se encontraron coincidencias que empaten con el criterio de búsqueda"
                : $"Se encontraron {result.Count} coincidencias",
                Errors = null,
                //ObjectResult = result
            };
        }

        public ObjectResponse<User> DeleteUser(int ID)
        {
            var result = uWork.UserRepo.Search(u => u.Id == ID);

            if (result.Any())
            {
                this.uWork.UserRepo.Delete(result.First());
            }

            return new ObjectResponse<User>()
            {
                IsSucess = true,
                Message = result == null || result.Any() == false ?
                "No se encontraron coincidencias que empaten con el criterio de búsqueda"
                : $"El usuario {result.First().NickName} se eliminó correctamente",
                Errors = null,
                //ObjectResult = result.First()
            };
        }

        private Finanzas.CursoVisualStudio.DataAccess.SQLDatabase.Models.User ConvertUserDtoToUserSql(Shared.DTOs.User dto)
        {
            return new DataAccess.SQLDatabase.Models.User()
            {
                Email = dto.Email,
                Id = dto.ID,
                NickName = dto.NickName,
                Password = dto.Password
            };
        }
    }
}