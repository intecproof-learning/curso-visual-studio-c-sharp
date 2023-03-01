using System.Numerics;
using Finanzas.CursoVisualStudio.Shared.DTOs;

namespace UserManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*bool finishExecution = false;
            UserRepo uRepo = new UserRepo();
            do
            {
                Console.WriteLine("Bienvenido al manejador de usuarios");
                Console.WriteLine("Por favor ingrese una se las siguientes opciones:");
                Console.WriteLine("1.- Consultar usuarios");
                Console.WriteLine("2.- Agregar un usuario");
                Console.WriteLine("3.- Modificar usuarios");
                Console.WriteLine("4.- Eliminar usuarios");
                Console.WriteLine("5.- Salir");

                String selectedOption = Console.ReadLine();
                Console.Clear();

                switch (selectedOption)
                {
                    case "1":
                        Console.WriteLine("*****Consulta de usuarios*****");
                        Console.WriteLine("Por favor ingrese el apodo o correo electrónico del usuario a buscar");
                        String searchValue = Console.ReadLine();

                        var matches = uRepo.SearchUser(searchValue);
                        Console.WriteLine("Los usuarios que empatan con el criterio de búsqueda son:");
                        foreach (var item in matches)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        break;
                    case "2":
                        Console.WriteLine("******Agregar un usuario*****");
                        Console.WriteLine("Por favor ingrese el \"Apodo\" del usuario");
                        String nicName = Console.ReadLine();
                        Console.WriteLine("Por favor ingrese el \"Correo electrónico\" del usuario");
                        String email = Console.ReadLine();
                        Console.WriteLine("Por favor ingrese la \"Contraseña\" del usuario");
                        String password = Console.ReadLine();

                        var newUser = uRepo.AddUser(new User()
                        {
                            NickName = nicName,
                            Email = email,
                            Password = password
                        });

                        Console.WriteLine($"El usuario \"{newUser.ToString()}\" se agregó correctamente");

                        break;
                    case "3":
                        Console.WriteLine("******Modificar un usuario*****");

                        Console.WriteLine("Por favor ingrese el \"Correo electrónico\" del usuario a modificar");
                        email = Console.ReadLine();

                        Console.WriteLine("Por favor ingrese el \"Apodo\" del usuario. Solo presione enter si no desea modificarlo");
                        nicName = Console.ReadLine();

                        Console.WriteLine("Por favor ingrese la \"Contraseña\" del usuario. Solo presione enter si no desea modificarlo");
                        password = Console.ReadLine();

                        newUser = uRepo.ModifyUser(new User()
                        {
                            NickName = nicName,
                            Email = email,
                            Password = password
                        });

                        Console.WriteLine($"El usuario \"{newUser.ToString()}\" se modificó correctamente");
                        break;
                    case "4":
                        try
                        {
                            Console.WriteLine("******Eliminar un usuario*****");

                            Console.WriteLine("Por favor ingrese el \"Correo electrónico\" del usuario a eliminar");
                            email = Console.ReadLine();

                            newUser = uRepo.DeleteUser(email);

                            Console.WriteLine($"El usuario \"{newUser.ToString()}\" se eliminó correctamente");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case "5":
                        Console.WriteLine("Hasta Luego...");
                        finishExecution = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida, por favor intente de nuevo");
                        break;
                }

                if (finishExecution == false)
                {
                    Console.WriteLine("Presione cualquier tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (!finishExecution);
            //while (finishExecution == false);*/

            GenericRepo<User> uRepo =
                new GenericRepo<User>();

            uRepo.Add(new User()
            {
                ID = 3,
                Email = "c@h.com",
                NickName = "c",
                Password = "ldfjij"
            });

            uRepo.Add(new User()
            {
                ID = 1,
                Email = "a@h.com",
                NickName = "a",
                Password = "a"
            });
            uRepo.Add(new User()
            {
                ID = 2,
                Email = "b@h.com",
                NickName = "b",
                Password = "poiut"
            });

            uRepo.Modify(new User()
            {
                ID = 1,
                Email = "a@hotmail.com",
                NickName = "Abraham",
                Password = "Admin123"
            },
            u => u.ID == 1,
            (newU, current) =>
            {
                current.Email = newU.Email;
                current.NickName = newU.NickName;
                current.Password = newU.Password;
            });

            var matches = uRepo.Search(u => u.NickName.ToLower().Contains("h") && u.Email.ToLower().Contains("h"));
            uRepo.Search(SearchUser);

            matches = uRepo.Search(u =>
            u.NickName.ToLower().Contains("h"));
            matches = uRepo.Search(u =>
            u.Email.ToLower().Contains("h"));
            matches = uRepo.Search(u =>
            u.Password.ToLower().Contains("h"));

            //uRepo.Delete(uRepo.Search(u => u.ID == 1).First());

            uRepo.Sort((u1, u2) =>
            {
                return u1.Password.CompareTo(u2.Password);
            });

            uRepo.Sort(y: 45, predicate: (u1, u2) =>
            {
                return u1.Email.CompareTo(u2.Email);
            }, isAsc: false, x: 10, w: "Adios");

            GenericRepo<Module> mRepo = new GenericRepo<Module>();
        }

        public static bool SearchUser(User u)
        {
            return u.NickName.ToLower().Contains("h") &&
                u.Email.ToLower().Contains("h");
        }

        private static List<User> items = new List<User>();

        private static List<User> SearchUSer(Func<User, bool> predicate)
        {
            List<User> tmp = new List<User>();
            foreach (var item in items)
            {
                if (predicate(item) == true)
                {
                    tmp.Add(item);
                }
            }

            return tmp;
        }
    }

    
}

//Visual Studio 2022
//Enterprise :
//VHF9H - NXBBB - 638P6 - 6JHCY - 88JWH

//Professional:
//TD244 - P4NB7 - YQ6XK - Y8MMM - YWV2J