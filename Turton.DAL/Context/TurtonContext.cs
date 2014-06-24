using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turton.Domain.Models;

namespace Turton.DAL.Context
{
    public class TurtonContext : DbContext 
    {
        public DbSet<NewsEntry> NewsEntrys { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
    }
}
