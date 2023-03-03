using Finanzas.CursoVisualStudio.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.CursoVisualStudio.DataAccess.Repositories.Implementations
{
    internal class GenericRepo<T> : IGenericRepo<T>
    {
        private static List<T> items;

        public GenericRepo()
        {
            if (items == null)
            {
                items = new List<T>();
            }
        }

        public T Add(T item)
        {
            try
            {
                items.Add(item);

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
                items.Remove(entity);

                return entity;
            }
            catch
            {
                throw;
            }
        }

        public T Modify(T item, Func<T, bool> predicateSearch, Action<T, T> predicateMod)
        {
            try
            {
                T current =
                    this.Search(predicateSearch).First();
                predicateMod(item, current);

                return current;
            }
            catch
            {
                throw;
            }
        }

        public List<T> Search(Func<T, bool> predicate)
        {
            try
            {
                return items.Where(predicate).ToList();
            }
            catch
            {
                throw;
            }
        }

        public void Sort(Func<T, T, int> predicate, bool isAsc = true)
        {
            T pivot;

            for (int a = 1; a < items.Count; a++)
            {
                for (int b = items.Count - 1; b >= a; b--)
                {
                    if (predicate(items[b - 1], items[b])
                        == (isAsc == true ? 1 : -1))
                    {
                        pivot = items[b - 1];
                        items[b - 1] = items[b];
                        items[b] = pivot;
                    }
                }
            }
        }
    }
}