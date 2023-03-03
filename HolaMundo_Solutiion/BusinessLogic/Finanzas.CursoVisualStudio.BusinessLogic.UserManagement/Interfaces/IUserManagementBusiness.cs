using Finanzas.CursoVisualStudio.Shared.DTOs;

namespace Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Interfaces
{
    public interface IUserManagementBusiness
    {
        public ObjectResponse<User> CreateOrUpdateUser(User item);
    }
}