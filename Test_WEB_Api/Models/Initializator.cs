using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Test_WEB_Api.Models
{
    public class Initializator : DropCreateDatabaseAlways<SentenceContext>
    {
        protected override void Seed(SentenceContext db)
        {
            db.Sentences.Add(new Sentence { ID = 0, Body = "Доброго дня." });
            db.Sentences.Add(new Sentence { ID = 1, Body = "Дня не вистачає нам вже." });
            db.Sentences.Add(new Sentence { ID = 2, Body = "Доброго дня тобі мій любий друже." });
            base.Seed(db);
        }
    }
}