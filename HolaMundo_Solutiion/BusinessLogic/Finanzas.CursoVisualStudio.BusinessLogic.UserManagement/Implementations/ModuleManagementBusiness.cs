using Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Interfaces;
using Finanzas.CursoVisualStudio.DataAccess.Repositories.Implementations;
using Finanzas.CursoVisualStudio.Shared.DTOs;
using Finanzas.CursoVisualStudio.Shared.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Sql = Finanzas.CursoVisualStudio.DataAccess.SQLDatabase.Models;

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
                    if (uWork.ModuleRepo.Search(u => u.Id == item.ID).Any() == true)
                    {
                        uWork.ModuleRepo.Modify(this.ConvertModuleDtoToModuleSql(item));

                        message = $"El Módulo \"{item.Name}\" se actualizó correctamente";
                        isSuccess = true;
                    }
                    else
                    {
                        uWork.ModuleRepo.Add(this.ConvertModuleDtoToModuleSql(item));
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

        public ObjectResponse<List<Module>> GetModule(String criteria)
        {
            Expression<Func<Sql.Module, bool>> filter = u => u.Id.ToString() == criteria || u.Name.ToLower().Contains(criteria) || u.Description.ToLower().Contains(criteria);

            var result = this.uWork.ModuleRepo.Search(filter:filter, include: "UserModuleRels.IdUserNavigation");

            List<Module> resultQuery = new List<Module>();
            result.ForEach(item =>
            {
                resultQuery.Add(this.ConvertModuleSqlToModuleDto(item));
            });

            return new ObjectResponse<List<Module>>()
            {
                IsSucess = true,
                Message = result == null || result.Any() == false ? "No se encontraron coincidencias que empaten con el criterio de búsqueda" : $"Se encontraron {result.Count} coincidencias",
                Errors = null,
                ObjectResult = resultQuery
            };
        }

        public ObjectResponse<Module> DeleteModule(int ID)
        {
            var result = uWork.ModuleRepo.Search(u => u.Id == ID);

            if (result.Any())
            {
                this.uWork.ModuleRepo.Delete(result.First());
            }

            return new ObjectResponse<Module>()
            {
                IsSucess = true,
                Message = result == null || result.Any() == false ? "No se encontraron coincidencias que empaten con el criterio de búsqueda" : $"El usuario {result.First().Name} se eliminó correctamente",
                Errors = null,
                ObjectResult = this.ConvertModuleSqlToModuleDto(result.First())
            };
        }

        private Sql.Module ConvertModuleDtoToModuleSql(Module dto)
        {
            Sql.Module sql = new Sql.Module()
            {
                Description = dto.Description,
                Id = dto.ID,
                Name = dto.Name
            };

            if (dto.RelatedUsers != null && dto.RelatedUsers.Any() == true)
            {
                foreach (var item in dto.RelatedUsers)
                {
                    sql.UserModuleRels.Add(
                        new Sql.UserModuleRel()
                        {
                            IsActive = true,
                            IdUser = item.UserDto.ID,
                            IdModule = dto.ID,
                            IdUserNavigation = new Sql.User()
                            {
                                Id = item.UserDto.ID,
                                Email = item.UserDto.Email,
                                NickName = item.UserDto.NickName,
                                Password = item.UserDto.Password,
                            }
                        });
                }
            }

            return sql;
        }

        private Module ConvertModuleSqlToModuleDto(Sql.Module sql)
        {
            Module dto = new Module()
            {
                Description = sql.Description,
                ID = sql.Id,
                Name = sql.Name,
                RelatedUsers = new List<ModuleUserRelDto>()
            };

            if (sql.UserModuleRels != null && sql.UserModuleRels.Any() == true)
            {
                foreach (var item in sql.UserModuleRels)
                {
                    dto.RelatedUsers.Add(
                        new ModuleUserRelDto()
                        {
                            IsActive = item.IsActive,
                            UserDto = new User()
                            {
                                ID = item.IdUser,
                                Email = item.IdUserNavigation.Email,
                                NickName = item.IdUserNavigation.NickName,
                                Password = item.IdUserNavigation.Password,
                                RelatedModules = null
                            }
                        });
                }
            }

            return dto;
        }

        public void Dispose()
        {
            this.uWork.Dispose();
        }

        ~ModuleManagementBusiness()
        {
            this.Dispose();
        }
    }
}