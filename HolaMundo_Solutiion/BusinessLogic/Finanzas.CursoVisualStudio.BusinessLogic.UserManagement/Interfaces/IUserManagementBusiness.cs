using Finanzas.CursoVisualStudio.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Interfaces
{
    public interface IUserManagementBusiness
    {
        public Dictionary<string, string>
            CreateOrUpdateUser(User item);
    }
}