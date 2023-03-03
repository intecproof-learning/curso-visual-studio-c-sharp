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
            ICollection<ValidationResult> vResult = new List<ValidationResult>();
            String message = "Ocurrieron uno o varios errores al validar el modelo";
            bool isSuccess = false;

            if (Utilities.IsValidModel<User>(item, out vResult) == true)
            {
                if (uWork.UserRepo.Search(u => u.ID == item.ID).Any() == true)
                {
                    uWork.UserRepo.Modify(item, u => u.ID == item.ID, (nUser, cUser) =>
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
                    uWork.UserRepo.Add(item);
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

        public ObjectResponse<List<User>>
            GetUser(String criteria)
        {
            var result = this.uWork.UserRepo
            .Search(u => u.ID.ToString() == criteria
            || u.NickName.ToLower().Contains(criteria)
            || u.Email.ToLower().Contains(criteria));


            return new ObjectResponse<List<User>>()
            {
                IsSucess = true,
                Message = result == null || result.Any() == false ?
                "No se encontraron coincidencias que empaten con el criterio de búsqueda"
                : $"Se encontraron {result.Count} coincidencias",
                Errors = null,
                ObjectResult = result
            };
        }
    }
}