using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turton.Domain.Models;

namespace Turton.Domain.DAL
{
    public interface IUnitOfWork: IDisposable
    {
        ITurtonRepository<NewsEntry> NewsEntryRepository { get; }
        INewsletterRepository NewsLetterRepository { get; }

        void Save();

    }
}
