using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turton.Domain.Models;
using Turton.Service.Interfaces;
using Turton.DAL.Repositories;
using Turton.Domain.DAL;


namespace Turton.Service.Services
{
    public class NewsEntryService: INewsEntryService
    {

        private readonly IUnitOfWork _newsEntryUOW;

        public NewsEntryService(IUnitOfWork newsEntryUOW)
        {
            _newsEntryUOW = newsEntryUOW;

        }

        public IEnumerable<NewsEntry> GetAllNewsEntries()
        {
            return _newsEntryUOW.NewsEntryRepository.Get();
        }

        public NewsEntry GetNewsEntry(string id)
        {

            return _newsEntryUOW.NewsEntryRepository.GetByID(id);
        }


        public NewsEntry AddNewsEntry(NewsEntry newsentryToAdd)
        {
            NewsEntry news = _newsEntryUOW.NewsEntryRepository.Insert(newsentryToAdd);
            return news;
        }

        public void Delete(NewsEntry newsentryToDelete)
        {
            _newsEntryUOW.NewsEntryRepository.Delete(newsentryToDelete);
        }

        public void Delete(int id)
        {
            _newsEntryUOW.NewsEntryRepository.Delete(id);
        }

        public void Update(NewsEntry newsentryToUpdate)
        {
            _newsEntryUOW.NewsEntryRepository.Update(newsentryToUpdate);
        }
    }
}
