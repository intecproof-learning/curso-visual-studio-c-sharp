using Finanzas.CursoVisualStudio.DataAccess.Repositories.Interfaces;
using Finanzas.CursoVisualStudio.DataAccess.SQLDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Finanzas.CursoVisualStudio.DataAccess.Repositories.Implementations
{
    internal class GenericRepo<T> : IGenericRepo<T> where T : class, new()
        ///class -> Objeto tipo T debe ser una clase

        ///new() -> Objeto tipo T debe tener un
        ///constructor sin parámetros

        ///struct -> T debe ser de tipo struct

        ///notnull -> T no debe permitir nulos

        ///[Nombre de la interface] T debe implementar
        ///la interface especificada

        ///https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters
    {

        public GenericRepo()
        {
        }

        public T Add(T item)
        {
            try
            {
                using (CursoVisualCContext context = new CursoVisualCContext())
                {
                    context.Add<T>(item);
                    context.SaveChanges();
                    return item;
                }
            }
            catch
            {
                throw;
            }
        }

        public T Delete(T entity)
        {
            try
            {
                using (CursoVisualCContext context = new CursoVisualCContext())
                {
                    context.Remove<T>(entity);
                    context.SaveChanges();
                    return entity;
                }
            }
            catch
            {
                throw;
            }
        }

        public void Dispose()
        {
        }

        public T Modify(T item)
        {
            try
            {
                using (CursoVisualCContext context = new CursoVisualCContext())
                {
                    context.Update<T>(item);
                    context.SaveChanges();
                    return item;
                }
            }
            catch
            {
                throw;
            }
        }

        public List<T> Search(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, String include = "")
        {
            try
            {
                /*
                 * Recuerda que esta instrucción
                 * primero recupera los datos y
                 * luego los ordena
                this.context.Users
               .Where(u => u.Id == 1).ToList()
               .OrderBy(u=> u.Id);

                * Esta instrucción recupera los datos ya
                * ordenados
                this.context.Users
               .Where(u => u.Id == 1)
               .OrderBy(u => u.Id)
               .ToList();
                */

                using (CursoVisualCContext context = new CursoVisualCContext())
                {
                    //SELECT * FROM User
                    IQueryable<T> query = context.Set<T>();

                    if (filter != null)
                    {
                        //SELECT * FROM User WHERE filtro
                        query = query.Where(filter);
                    }

                    if (String.IsNullOrEmpty(include) == false)
                    {
                        foreach (var includeProperty in include.Split(",", StringSplitOptions.RemoveEmptyEntries))
                        {
                            query = query.Include(includeProperty);
                        }
                    }

                    if (orderBy != null)
                    {
                        //orderBy(query) ->
                        //SELECT * FROM User WHERE filtro
                        //order by columna(s)
                        //.ToList() -> F5 o ejecutar query
                        return orderBy(query).ToList();
                    }

                    //query ->
                    //SELECT * FROM User WHERE filtro
                    //.ToList() -> F5 o ejecutar query
                    return query.ToList();
                }
            }
            catch
            {
                throw;
            }
        }

        ~GenericRepo()
        {
            this.Dispose();
        }
    }
}

//Scaffold command
//Scaffold-DbContext "Server=localhost;Database=CursoVisualC#;User ID=sa;Password=Admin123;Trusted_Connection=True;Encrypt=True;" Microsoft.EntityFrameworkCore.SqlServer -Force -OutputDir Models