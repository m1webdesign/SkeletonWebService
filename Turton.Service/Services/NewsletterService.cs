using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turton.Domain.DAL;
using Turton.Domain.Models;
using Turton.Service.Interfaces;

namespace Turton.Service.Services
{
    public class NewsletterService: INewsletterService
    {
        private readonly IUnitOfWork _newsLetterUOW;

        public NewsletterService(IUnitOfWork newsLetterUOW)
        {
            _newsLetterUOW = newsLetterUOW;

        }

        public IEnumerable<Newsletter> GetAllNewsletters()
        {
            return _newsLetterUOW.NewsLetterRepository.Get();
        }

        public Newsletter GetNewsletter(string id)
        {
            return _newsLetterUOW.NewsLetterRepository.GetByID(id);
        }

        public Newsletter AddNewsletter(Newsletter newsletterToAdd)
        {
            return _newsLetterUOW.NewsLetterRepository.InsertNewsletter(newsletterToAdd);

        }

        public void Delete(Newsletter newsletterToDelete)
        {
            _newsLetterUOW.NewsLetterRepository.Delete(newsletterToDelete);
        }

        public void Delete(int id)
        {
            _newsLetterUOW.NewsLetterRepository.Delete(id);
        }

        public void Update(Newsletter newsletterToUpdate)
        {
            _newsLetterUOW.NewsLetterRepository.Update(newsletterToUpdate);
        }
    }
}
