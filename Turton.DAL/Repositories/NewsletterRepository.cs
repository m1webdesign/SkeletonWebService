using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turton.DAL.Context;
using Turton.Domain.DAL;
using Turton.Domain.Models;

namespace Turton.DAL.Repositories
{
    public class NewsletterRepository : InMemoryRepository<Newsletter>, INewsletterRepository
    {
        //Since you don't explicitly invoke a parent constructor as part of your child class constructor,
        //there is an implicit call to a parameterless parent constructor inserted. That constructor 
        //does not exist, and so you would get error.
        //To correct the situation, you need to add an explicit call:
        public NewsletterRepository(InMemoryContext context)
            : base(context)
        { }


        public Newsletter InsertNewsletter(Newsletter newsletter)
        {
            var lastelement = _list.OrderBy(x => x.ID).Last();
            if (lastelement != null)
                newsletter.ID = lastelement.ID+1;
            else
                newsletter.ID = 1;

            int id = 1;
            foreach (NewsletterAttachment na in newsletter.NewsletterAttachments)
            {
                na.ID = id;
                id++;
            }
            _list.Add(newsletter);
            
            return newsletter;
        }
    }
}
