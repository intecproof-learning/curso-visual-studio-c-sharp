using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.CursoVisualStudio.Shared.Repositories.Interfaces
{
    public interface IGenericRepo<T>
    {
        public T Add(T item);

        public List<T> Search(Func<T, bool> predicate);

        public T Modify(T item,
            Func<T, bool> predicateSearch,
            Action<T, T> predicateMod);

        public T Delete(T entity);

        public void Sort(Func<T, T, int> predicate,
            bool isAsc = true,
            int x = 0, float y = 9, String w = "Hola");
    }
}