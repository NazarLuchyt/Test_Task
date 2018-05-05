using System.Collections.Generic;
using Test_WEB_Api.Models;

namespace Test_WEB_Api.Repositories
{
    public class SentenceRepository
    {
        private SentenceContext db;


        public SentenceRepository()
        {
            this.db = new SentenceContext();
        }
 
        public IEnumerable<Sentence> GetAll()
        {
            return db.Sentences;
        }
        
        public void Create(List<Sentence> Array)
        {
            foreach(Sentence element in Array)
            db.Sentences.Add(element);
            Save();
        }
 
        public void Save()
        {
            db.SaveChanges();
        }

    }
}