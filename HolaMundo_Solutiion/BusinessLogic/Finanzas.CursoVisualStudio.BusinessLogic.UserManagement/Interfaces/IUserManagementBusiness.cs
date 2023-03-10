using Finanzas.CursoVisualStudio.Shared.DTOs;

namespace Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Interfaces
{
    public interface IUserManagementBusiness
    {
        public ObjectResponse<User> CreateOrUpdateUser(User item);

        public ObjectResponse<List<User>> GetUser(String? criteria);

        public ObjectResponse<User> DeleteUser(int ID);
    }
}