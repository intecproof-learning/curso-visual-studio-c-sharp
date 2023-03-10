using System.Linq.Expressions;

namespace Finanzas.CursoVisualStudio.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepo<T> where T : class, new()
    {
        public T Add(T item);

        public List<T> Search(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

        public T Modify(T item);

        public T Delete(T entity);
    }
}