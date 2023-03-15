using Finanzas.CursoVisualStudio.DataAccess.SQLDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.CursoVisualStudio.DatabaseAccess
{
    internal class Program
    {
        static void Main(string[] args)
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
                umrel=>umrel.umr.IdModule,
                m=>m.Id,
                (umrel, m)=>
                new
                {
                    u=umrel.user,
                    m = m,
                    isActive = umrel.umr.IsActive
                });



            }//Cuando se ejecuta esta llave de cierre
            //C# manda a llamar a context.Dispose();
        }
    }
}