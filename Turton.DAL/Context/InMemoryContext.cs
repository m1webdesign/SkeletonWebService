using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turton.Domain.Models;

namespace Turton.DAL.Context
{
    public class InMemoryContext
    {
        public Dictionary<Type, object> EntityDictionary = new Dictionary<Type, object>();

        private List<NewsEntry> NewsItems
        {
            get
            {
                return
                new List<NewsEntry>
                {
                    new NewsEntry
                    {
                        ID = 1,
                        Headline = "hello"
                    },

                    new NewsEntry
                    {
                        ID = 2,
                        Headline = "goodbye"
                    }
                };
            }
        }

        private List<Newsletter> Newsletters
        {
            get
            {
                return
                new List<Newsletter>
                {
                    new Newsletter
                    {
                        ID = 1,
                        Headline = "hello newsletter",
                        NewsletterAttachments = new List<NewsletterAttachment>()
                        
                    },

                    new Newsletter
                    {
                        ID = 2,
                        Headline = "goodbye newsletter"
                    }
                };
            }
        }

        public InMemoryContext()
        {
            EntityDictionary.Add(typeof(NewsEntry), NewsItems);
            EntityDictionary.Add(typeof(Newsletter), Newsletters);

        }

    }
}
