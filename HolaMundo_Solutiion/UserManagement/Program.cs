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
                ID = 1,
                Email = "a@h.com",
                NickName = "a",
                Password = "a"
            });

            uRepo.Modify(new User()
            {
                ID = 1,
                Email = "a@hotmail.com",
                NickName = "Abraham",
                Password = "Admin123"
            });

            var matches = uRepo.Search(u => u.NickName.ToLower().Contains("h") && u.Email.ToLower().Contains("h"));
            uRepo.Search(SearchUser);

            uRepo.Delete(uRepo.Search(u => u.ID == 1).First());

            GenericRepo<Module> mRepo = new GenericRepo<Module>();
        }

        public static bool SearchUser(User usuario)
        {
            return usuario.NickName.ToLower().Contains("h") &&
                usuario.Email.ToLower().Contains("h");
        }
    }

    public class UserRepo
    {
        private List<User> users;

        public UserRepo()
        {
            this.users = new List<User>();
        }

        public User AddUser(User user)
        {
            try
            {
                this.users.Add(user);

                return user;
            }
            catch
            {
                throw;
            }
        }

        public List<User> SearchUser(String searchValue)
        {
            try
            {
                if (String.IsNullOrEmpty(searchValue) == true)
                {
                    return this.users;
                }

                searchValue = searchValue.ToLower();

                return this.users.Where(
                u => u.NickName.ToLower().Contains(searchValue) ||
                u.Email.ToLower().Contains(searchValue)).ToList();

                //return (from u in this.users
                //        where u.NickName.ToLower().Contains(searchValue) ||
                //        u.Email.ToLower().Contains(searchValue)
                //        select u).ToList();

                //List<User> matches = new List<User>();
                //foreach (User user in this.users)
                //{
                //    if (user.Email.ToLower().Contains(searchValue.ToLower()) == true || user.NickName.ToLower().Contains(searchValue.ToLower()) == true)
                //    {
                //        matches.Add(user);
                //    }
                //}

                //return matches;
            }
            catch
            {
                throw;
            }
        }

        public User ModifyUser(User user)
        {
            try
            {
                var matches = this.SearchUser(user.Email);

                if (matches.Any() == true)
                {
                    User tmp = matches.First();
                    tmp.NickName = String.IsNullOrEmpty(user.NickName) == true ?
                        tmp.NickName : user.NickName;
                    tmp.Password = String.IsNullOrEmpty(user.Password) == true ? tmp.Password : user.Password;

                    return matches.First();
                }
                else
                {
                    throw new Exception("No se encontró el usuario solicitado");
                }
            }
            catch
            {
                throw;
            }
        }

        public User DeleteUser(String email)
        {
            try
            {
                var matches = this.SearchUser(email);

                if (matches.Any() == true)
                {
                    User tmp = matches.First();
                    this.users.Remove(tmp);

                    return tmp;
                }
                else
                {
                    throw new Exception("No hay elementos a eliminar");
                }
            }
            catch
            {
                throw;
            }
        }
    }

    public class User : IComparable<User>
    {
        public int ID { get; set; }
        public String Email { get; set; }
        public String NickName { get; set; }
        public String Password { get; set; }

        //CompareTo regresa 0 si ambos ojetos son iguales
        //1 = si el objeto de la izquierda es mayor
        //-1 = si el objeto de la izquierda es menor
        public int CompareTo(User? other)
        {
            if (other == null)
                return -1;

            return this.ID.CompareTo(other.ID);
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj.GetType() == typeof(User))
            {
                User tmp = (User)obj;
                //return this.ID.Equals(tmp.ID);
                return this.ID == tmp.ID;
            }

            return false;
        }

        public override string ToString()
        {
            return $"Apodo: {this.NickName} - Correo electrónico: {this.Email}";
        }
    }

    public class Module : IComparable<Module>
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public int CompareTo(Module? other)
        {
            if (other == null)
                return -1;

            return this.ID.CompareTo(other.ID);
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj.GetType() == typeof(Module))
            {
                Module tmp = (Module)obj;
                //return this.ID.Equals(tmp.ID);
                return this.ID == tmp.ID;
            }

            return false;
        }

        public override string ToString()
        {
            return $"ID: {this.Description} - Nombre: {this.Name}";
        }
    }

    public interface IGenericRepo<T>
    {
        public T Add(T item);

        public List<T> Search(Func<T, bool> predicate);

        public T Modify(T item);

        public T Delete(T entity);
    }

    public class GenericRepo<T> : IGenericRepo<T>
    {
        private List<T> items;

        public GenericRepo()
        {
            this.items = new List<T>();
        }

        public T Add(T item)
        {
            try
            {
                this.items.Add(item);

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
                this.items.Remove(entity);

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
                this.items.Remove(item);
                this.Add(item);

                return item;
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
                return this.items.Where(predicate).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}