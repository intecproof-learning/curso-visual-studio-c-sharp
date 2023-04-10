using Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Interfaces;
using Finanzas.CursoVisualStudio.DataAccess.Repositories.Implementations;
using Finanzas.CursoVisualStudio.Shared.DTOs;
using Finanzas.CursoVisualStudio.Shared.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Sql = Finanzas.CursoVisualStudio.DataAccess.SQLDatabase.Models;

namespace Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Implementations
{
    public class UserManagementBusiness : IUserManagementBusiness
    {

        public UserManagementBusiness()
        {
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
                    using (UnitOfWork uWork = new UnitOfWork())
                    {
                        if (item.ID != 0 && uWork.UserRepo.Search(u => u.Id == item.ID).Any() == true)
                        {
                            uWork.UserRepo.Modify(ConvertUserDtoToUserSql(item));

                            message = $"El usuario \"{item.NickName}\" se actualizó correctamente";
                            isSuccess = true;
                        }
                        else if (item.ID == 0)
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

        public ObjectResponse<List<User>> GetUser(String? criteria)
        {
            Expression<Func<Sql.User, bool>> filter = String.IsNullOrEmpty(criteria) == true ? null : u => u.Id.ToString() == criteria || u.NickName.ToLower().Contains(criteria) || u.Email.ToLower().Contains(criteria);

            //Si criteria es nulo o vacío entoces:
            //SELECT * FROM User

            //Si criteria tiene algo entonces: 
            //SELECT * FROM User
            //WHERE id = criteria OR
            //email LIKE "%criteria%" OR
            //nickName LIKE "%criteria%"
            List<Sql.User> result = null;

            using (UnitOfWork uWork = new UnitOfWork())
            {
                result = uWork.UserRepo.Search(filter: filter, include: "UserModuleRels.IdModuleNavigation");
                result.OrderBy(ob => ob.Id);
            }

            List<User> resultDTO = new List<User>();
            result.ForEach(a => resultDTO.Add(this.ConvertUserSqlToUserDto(a)));

            ///Este foreach es lo mismo que el de arriba
            //foreach (var a in result)
            //{
            //    resultDTO.Add(
            //    this.ConvertUserSqlToUserDto(a));
            //}

            return new ObjectResponse<List<User>>()
            {
                IsSucess = true,
                Message = result == null || result.Any() == false ? "No se encontraron coincidencias que empaten con el criterio de búsqueda" : $"Se encontraron {result.Count} coincidencias",
                Errors = null,
                ObjectResult = resultDTO
            };
        }

        public ObjectResponse<User> DeleteUser(int ID)
        {
            List<Sql.User> result = null;
            var response = new ObjectResponse<User>();

            using (UnitOfWork uWork = new UnitOfWork())
            {
                result = uWork.UserRepo.Search(u => u.Id == ID);
                if (result.Any())
                {
                    response.ObjectResult = this.ConvertUserSqlToUserDto(uWork.UserRepo.Delete(result.First()));
                }

            }

            response.IsSucess = result == null || result.Any() == false ? false : true;
            response.Message = result == null || result.Any() == false ? "No se encontraron coincidencias que empaten con el criterio de búsqueda" : $"El usuario {result.First().NickName} se eliminó correctamente";
            response.Errors = null;

            return response;
        }

        private Sql.User ConvertUserDtoToUserSql(Shared.DTOs.User dto)
        {
            Sql.User sql = new Sql.User()
            {
                Email = dto.Email,
                Id = dto.ID,
                NickName = dto.NickName,
                Password = dto.Password
            };

            //if (dto.RelatedModules != null && dto.RelatedModules.Any() == true)
            //{
            //    foreach (var item in dto.RelatedModules)
            //    {
            //        sql.UserModuleRels.Add(
            //            new Sql.UserModuleRel()
            //            {
            //                IsActive = true,
            //                IdUser = dto.ID,
            //                IdModule = item.ModuleDto.ID,
            //                IdModuleNavigation = new Sql.Module()
            //                {
            //                    Description = item.ModuleDto.Description,
            //                    Name = item.ModuleDto.Name,
            //                    Id = item.ModuleDto.ID
            //                }
            //            });
            //    }
            //}

            return sql;
        }

        private User ConvertUserSqlToUserDto(Sql.User sql)
        {
            User dto = new User()
            {
                Email = sql.Email,
                ID = sql.Id,
                NickName = sql.NickName,
                Password = sql.Password,
                RelatedModules = new List<UserModuleRelDto>()
            };

            if (sql.UserModuleRels != null && sql.UserModuleRels.Any() == true)
            {
                foreach (var item in sql.UserModuleRels)
                {
                    dto.RelatedModules.Add(
                        new UserModuleRelDto()
                        {
                            IsActive = item.IsActive,
                            Description = item.IdModuleNavigation.Description,
                            ID = item.IdModule,
                            Name = item.IdModuleNavigation.Name,
                            RelatedUsers = null
                        });
                }
            }

            return dto;
        }

        public void Dispose()
        {
        }

        ~UserManagementBusiness()
        {
            this.Dispose();
        }
    }
}