using Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Interfaces;
using Finanzas.CursoVisualStudio.DataAccess.Repositories.Implementations;
using Finanzas.CursoVisualStudio.Shared.DTOs;
using Finanzas.CursoVisualStudio.Shared.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Implementations
{
    public class ModuleManagementBusiness : IModuleManagementBusiness
    {
        private UnitOfWork uWork;

        public ModuleManagementBusiness()
        {
            this.uWork = new UnitOfWork();
        }

        public ObjectResponse<Module> CreateOrUpdateModule(Module item)
        {
            try
            {
                ICollection<ValidationResult> vResult = new List<ValidationResult>();
                String message = "Ocurrieron uno o varios errores al validar el modelo";
                bool isSuccess = false;

                if (Utilities.IsValidModel<Module>(item, out vResult) == true)
                {
                    if (uWork.ModuleRepo.Search(u => u.ID == item.ID).Any() == true)
                    {
                        uWork.ModuleRepo.Modify(item, u => u.ID == item.ID, (nUser, cUser) =>
                        {
                            cUser.Name = nUser.Name;
                            cUser.Description = nUser.Description;
                        });

                        message = $"El Módulo \"{item.Name}\" se actualizó correctamente";
                        isSuccess = true;
                    }
                    else
                    {
                        uWork.ModuleRepo.Add(item);
                        message = $"El Módulo \"{item.Name}\" se insertó correctamente";
                        isSuccess = true;
                    }
                }

                return new ObjectResponse<Module>()
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

        public ObjectResponse<List<Module>>
            GetModule(String criteria)
        {
            var result = this.uWork.ModuleRepo
            .Search(u => u.ID.ToString() == criteria
            || u.Name.ToLower().Contains(criteria)
            || u.Description.ToLower().Contains(criteria));


            return new ObjectResponse<List<Module>>()
            {
                IsSucess = true,
                Message = result == null || result.Any() == false ?
                "No se encontraron coincidencias que empaten con el criterio de búsqueda"
                : $"Se encontraron {result.Count} coincidencias",
                Errors = null,
                ObjectResult = result
            };
        }

        public ObjectResponse<Module> DeleteModule(int ID)
        {
            var result = uWork.ModuleRepo.Search(u => u.ID == ID);

            if (result.Any())
            {
                this.uWork.ModuleRepo.Delete(result.First());
            }

            return new ObjectResponse<Module>()
            {
                IsSucess = true,
                Message = result == null || result.Any() == false ?
                "No se encontraron coincidencias que empaten con el criterio de búsqueda"
                : $"El usuario {result.First().Name} se eliminó correctamente",
                Errors = null,
                ObjectResult = result.First()
            };
        }
    }
}