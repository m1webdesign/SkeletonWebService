using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turton.DAL.Context;
using Turton.DAL.Repositories;
using Turton.Domain.DAL;
using Turton.Domain.Models;

/**********CONCRETE IMPLEMENTATION OF IUNITOFWORK, SAYS WHAT DATASTORE WILL BE USED*******/
/**********MEANS DON'T HAVE TO COMMIT TO A DATASTORE UNTIL DAL LAYER (AND DEPENDENCY INJECTION****/

namespace Turton.DAL.UnitOfWork
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        private InMemoryContext _context = new InMemoryContext(); //call specific context (Transient datasets)

        //call the inmemory reporitory, because we now know we are using an in memory store
        //pass it the newsentry entity so can perform its generic methods on correct table
        //PRIVATE as only accessed by this class, tied to datacontext only here
        private InMemoryRepository<NewsEntry> newsEntryRepository;

        private NewsletterRepository newsLetterRepository;

        //PUBLIC to adhere to iunitofwork implementation and therefore remains generic
        //but returns private (datacontext-tied) private variable
        
        public ITurtonRepository<NewsEntry> NewsEntryRepository
        {
            get
            {
                //if one doesn't exist, create one, if not, send existing one
                //As a result, all repositories share the same context instance.
                //COMMIT ONLY HERE TO A DATASTROE
                if (this.newsEntryRepository == null)
                {
                    this.newsEntryRepository = new InMemoryRepository<NewsEntry>(_context);
                }
                return newsEntryRepository;
            }
        }

        public INewsletterRepository NewsLetterRepository
        {
            get
            {
                //if one doesn't exist, create one, if not, send existing one
                //As a result, all repositories share the same context instance.
                //COMMIT ONLY HERE TO A DATASTROE
                if (this.newsLetterRepository == null)
                {
                    this.newsLetterRepository = new NewsletterRepository(_context);
                }
                return newsLetterRepository;
            }
        }

        /*necessary implementations from idisposable (from iuintofwork)*/

        public void Save()
        {
            //_context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //_context.Dispose();
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
