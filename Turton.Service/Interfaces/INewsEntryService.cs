using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turton.Domain.Models;

namespace Turton.Service.Interfaces
{
    public interface INewsEntryService
    {
        IEnumerable<NewsEntry> GetAllNewsEntries();

        NewsEntry GetNewsEntry(string id);

        NewsEntry AddNewsEntry(NewsEntry newsentryToAdd);

        void Delete(NewsEntry newsentryToDelete);

        void Delete(int id);

        void Update(NewsEntry newsentryToUpdate);
    }
}
