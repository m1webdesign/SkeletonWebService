using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turton.Domain.Models;

namespace Turton.Service.Interfaces
{
    public interface INewsletterService
    {
        IEnumerable<Newsletter> GetAllNewsletters();

        Newsletter GetNewsletter(string id);

        Newsletter AddNewsletter(Newsletter newsentryToAdd);

        void Delete(Newsletter newsletterToDelete);

        void Delete(int id);

        void Update(Newsletter newsletterToUpdate);
    }
}
