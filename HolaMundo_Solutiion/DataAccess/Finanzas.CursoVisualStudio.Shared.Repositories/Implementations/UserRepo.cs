using Finanzas.CursoVisualStudio.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.CursoVisualStudio.Shared.Repositories.Implementations
{
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
}
