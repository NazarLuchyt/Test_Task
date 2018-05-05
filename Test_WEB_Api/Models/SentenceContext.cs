using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Test_WEB_Api.Models
{
    public class SentenceContext : DbContext
    {
        public SentenceContext() :
            base("SentenceContextConnection")
        { }
        public DbSet<Sentence> Sentences { get; set; }

    }
}