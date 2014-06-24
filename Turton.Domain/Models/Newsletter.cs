using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turton.Domain.Models
{
    public class Newsletter
    {
        public int ID { get; set; }
        public string Headline { get; set; }
        public int IssueNumber { get; set; }
        public string URL { get; set; }
        public string ImageURL { get; set; }
        public IList<NewsletterAttachment> NewsletterAttachments { get; set; }
    }
}
