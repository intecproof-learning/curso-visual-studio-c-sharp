using Finanzas.CursoVisualStudio.Shared.DTOs;

namespace Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Interfaces
{
    public interface IModuleManagementBusiness: IDisposable
    {
        public ObjectResponse<Module> CreateOrUpdateModule(Module item);

        public ObjectResponse<List<Module>> GetModule(String criteria);

        public ObjectResponse<Module> DeleteModule(int ID);
    }
}