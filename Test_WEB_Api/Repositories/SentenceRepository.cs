using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
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
        public int GetID()
        {
            int count = GetAll().Count();
            return count;
        }
        public void Create(List<Sentence> Array)
        {
            foreach(Sentence element in Array)
            db.Sentences.Add(element);
            Save();
        }
 
        public void Update(Sentence sentence)
        {
            db.Entry(sentence).State = EntityState.Modified;
        }
        public void Save()
        {
            db.SaveChanges();
        }

    }
}