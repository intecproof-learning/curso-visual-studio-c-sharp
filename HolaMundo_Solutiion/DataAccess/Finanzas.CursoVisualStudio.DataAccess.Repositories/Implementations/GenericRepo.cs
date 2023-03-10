﻿using Finanzas.CursoVisualStudio.DataAccess.Repositories.Interfaces;
using Finanzas.CursoVisualStudio.DataAccess.SQLDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.context= new CursoVisualCContext();
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
                return new List<T>();
            }
            catch
            {
                throw;
            }
        }

        public void Sort(Func<T, T, int> predicate, bool isAsc = true)
        {
            //T pivot;

            //for (int a = 1; a < items.Count; a++)
            //{
            //    for (int b = items.Count - 1; b >= a; b--)
            //    {
            //        if (predicate(items[b - 1], items[b])
            //            == (isAsc == true ? 1 : -1))
            //        {
            //            pivot = items[b - 1];
            //            items[b - 1] = items[b];
            //            items[b] = pivot;
            //        }
            //    }
            //}
        }
    }
}

//Scaffold command
//Scaffold-DbContext "Server=localhost;Database=CursoVisualC#;User ID=sa;Password=Admin123;Trusted_Connection=True;Encrypt=True;" Microsoft.EntityFrameworkCore.SqlServer -Force -OutputDir Models