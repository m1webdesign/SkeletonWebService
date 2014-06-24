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
    public class EFUnitOfWork : IUnitOfWork
    {
        private TurtonContext _context = new TurtonContext(); //call specific context (EF)

        //call the EF reporitory, because know using Entity Framework
        //pass it the newsentry entity so can perform its generic methods on correct table
        private EFRepository<NewsEntry> newsEntryRepository;

        private NewsletterRepository newsLetterRepository;

        public ITurtonRepository<NewsEntry> NewsEntryRepository
        {
            get
            {
                //if one doesn't exist, create one, if not, send existing one
                if (this.newsEntryRepository == null)
                {
                    this.newsEntryRepository = new EFRepository<NewsEntry>(_context);
                }
                return newsEntryRepository;
            }
        }

        public INewsletterRepository NewsLetterRepository
        {/*
            get
            {
                //if one doesn't exist, create one, if not, send existing one
                if (this.newsLetterRepository == null)
                {
                    this.newsLetterRepository = new EFRepository<Newsletter>(_context);
                }
                return newsLetterRepository;
            }*/
            get { return newsLetterRepository; }
            
        }

        /*necessary implementations from idisposable (from iuintofwork)*/

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
