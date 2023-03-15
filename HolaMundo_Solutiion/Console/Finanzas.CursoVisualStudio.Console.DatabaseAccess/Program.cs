using Finanzas.CursoVisualStudio.DataAccess.SQLDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.CursoVisualStudio.DatabaseAccess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QueryUsers();
            QueryModules();
        }

        private static void QueryUsers()
        {
            using (CursoVisualCContext context
                = new CursoVisualCContext())
            {
                foreach (var item in context
                    .Users.Include("UserModuleRels.IdModuleNavigation"))
                {
                    Console
                   .WriteLine(item.NickName);

                    foreach (var m in item
                    .UserModuleRels)
                    {
                        Console
                        .WriteLine("\t" + m
                        .IdModuleNavigation.Name);
                    }
                }

                foreach (var um
                        in context.UserModuleRels)
                {
                    Console
                    .WriteLine(um
                    .IdModule);
                }

                var umRels = context.Users
                .Join(context.UserModuleRels,
                u => u.Id,
                umr => umr.IdUser,
                (u, umr) =>
                new { user = u, umr = umr })
                .Join(context.Modules,
                umrel => umrel.umr.IdModule,
                m => m.Id,
                (umrel, m) =>
                new
                {
                    u = umrel.user,
                    m = m,
                    isActive = umrel.umr.IsActive
                });

                foreach (var item in umRels)
                {
                    Console.WriteLine(
                    $"{item.u.NickName}-" +
                    $"{item.m.Name}-" +
                    $"{item.isActive}");
                }

            }//Cuando se ejecuta esta llave de cierre
            //C# manda a llamar a context.Dispose();
        }

        private static void QueryModules()
        {
            using (CursoVisualCContext context
                = new CursoVisualCContext())
            {
                foreach (var item in context
                    .Modules.Include("UserModuleRels.IdUserNavigation"))
                {
                    Console
                   .WriteLine(item.Name);

                    foreach (var u in item
                    .UserModuleRels)
                    {
                        Console
                        .WriteLine("\t" + u
                        .IdUserNavigation.NickName);
                    }
                }

                foreach (var um
                        in context.UserModuleRels)
                {
                    Console
                    .WriteLine(um
                    .IdUser);
                }

                var umRels = context.Modules
                .Join(context.UserModuleRels,
                m => m.Id,
                umr => umr.IdModule,
                (m, umr) =>
                new { module = m, umr = umr })
                .Join(context.Users,
                umrel => umrel.umr.IdUser,
                u => u.Id,
                (umrel, u) =>
                new
                {
                    m = umrel.module,
                    u = u,
                    isActive = umrel.umr.IsActive
                }).OrderByDescending(ob=>ob.m.Id);

                foreach (var item in umRels)
                {
                    Console.WriteLine(
                    $"{item.m.Name}-" +
                    $"{item.u.NickName}-" +
                    $"{item.isActive}");
                }

            }//Cuando se ejecuta esta llave de cierre
            //C# manda a llamar a context.Dispose();
        }
    }
}