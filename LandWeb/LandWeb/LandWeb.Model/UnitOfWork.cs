using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandWeb.Model
{
    public class UnitOfWork : IDisposable
    {
        //private Realty7Entities context = new Realty7Entities();
        //private GenericRepository<agent> agentRepository;

        //public GenericRepository<agent> AgentRepository
        //{
        //    get
        //    {

        //        if (this.agentRepository == null)
        //        {
        //            this.agentRepository = new GenericRepository<agent>(context);
        //        }
        //        return agentRepository;
        //    }
        //}

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
