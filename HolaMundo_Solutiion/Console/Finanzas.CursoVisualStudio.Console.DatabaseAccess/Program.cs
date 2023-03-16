﻿using Finanzas.CursoVisualStudio.DataAccess.SQLDatabase.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.CursoVisualStudio.DatabaseAccess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //QueryUsers();
            //QueryModules();
            QueryADO();
        }

        private static void QueryADO()
        {
            int idUser = 2;
            string connS = "Server=localhost;Database=CursoVisualC#;User ID=sa;Password=Admin123;Trusted_Connection=False;Encrypt=False;MultipleActiveResultSets=true";
            string queryS = $"SELECT * FROM [User]";
            SqlConnection conn =
                new SqlConnection(connS);
            SqlCommand command = null;
            SqlDataReader reader = null;
            try
            {
                queryS = "SELECT * FROM [User]" +
                    "WHERE id = @idUser";
                command = new SqlCommand
                    (queryS, conn);
                command.Parameters
                    .AddWithValue("@idUser", idUser);

                conn.Open();
                reader = command.ExecuteReader();
                ///ExecuteReader sirve para leer el conjunto
                ///de resultados que arroja la consulta
                ///ExecuteNonQuery sirve para ejecutar
                ///sentencias que no regresan un conjunto
                ///de resultados, como insert, update
                ///CREATE TABLE,etc
                //command.ExecuteNonQuery();
                while (reader.Read() == true)
                {
                    Console.WriteLine($"{reader[0]}-" +
                    $"{reader[1]}-{reader["email"]}-" +
                    $"{reader["password"]}");

                    int idU = reader.GetSqlInt32(0).IsNull ? 0 :
                        Convert.ToInt32(reader.GetSqlInt32(
                            reader.GetOrdinal("id")).Value);
                    Console.WriteLine($"El Id del usuario es:" +
                        $"{idU}");
                    string nickName = reader.GetSqlString(1).IsNull?
                    String.Empty:Convert.ToString(reader
                    .GetSqlString(1).Value);

                    Console.WriteLine($"El NickName del usuario es:" +
                        $"{nickName}");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (command != null)
                {
                    command.Dispose();
                }
                if (reader != null)
                {
                    reader.Close();
                    reader.DisposeAsync()
                    .GetAwaiter()
                    .GetResult();
                }
                conn.Close();
                conn.Dispose();
            }
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
                }).OrderByDescending(ob => ob.m.Id);

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