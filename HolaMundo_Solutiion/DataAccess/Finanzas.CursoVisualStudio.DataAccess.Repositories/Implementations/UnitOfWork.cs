﻿using Finanzas.CursoVisualStudio.DataAccess.Repositories.Interfaces;
using Finanzas.CursoVisualStudio.DataAccess.SQLDatabase.Models;

namespace Finanzas.CursoVisualStudio.DataAccess.Repositories.Implementations
{
    public class UnitOfWork : IDisposable
    {
        public IGenericRepo<User> UserRepo { get; private set; }
        public IGenericRepo<Module> ModuleRepo { get; private set; }

        public UnitOfWork()
        {
            this.UserRepo = new GenericRepo<User>();
            this.ModuleRepo = new GenericRepo<Module>();
        }

        public void Dispose()
        {
            this.UserRepo.Dispose();
            this.ModuleRepo.Dispose();
        }

        ~UnitOfWork()
        {
            this.Dispose();
        }
    }
}