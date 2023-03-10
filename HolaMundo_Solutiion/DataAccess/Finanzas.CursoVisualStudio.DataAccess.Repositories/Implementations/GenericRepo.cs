using Finanzas.CursoVisualStudio.DataAccess.Repositories.Interfaces;
using Finanzas.CursoVisualStudio.DataAccess.SQLDatabase.Models;
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
        private CursoVisualCContext context;

        public GenericRepo()
        {
            this.context = new CursoVisualCContext();
        }

        public T Add(T item)
        {
            try
            {
                this.context.Add<T>(item);
                this.context.SaveChanges();
                return item;
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
                this.context.Remove<T>(entity);
                this.context.SaveChanges();
                return entity;
            }
            catch
            {
                throw;
            }
        }

        public T Modify(T item)
        {
            try
            {
                context.Update<T>(item);
                context.SaveChanges();
                return item;
            }
            catch
            {
                throw;
            }
        }

        public List<T> Search(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            try
            {
                IQueryable<T> query = this.context.Set<T>();

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                if (orderBy != null)
                {
                    return orderBy(query).ToList();
                }

                return query.ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}

//Scaffold command
//Scaffold-DbContext "Server=localhost;Database=CursoVisualC#;User ID=sa;Password=Admin123;Trusted_Connection=True;Encrypt=True;" Microsoft.EntityFrameworkCore.SqlServer -Force -OutputDir Models