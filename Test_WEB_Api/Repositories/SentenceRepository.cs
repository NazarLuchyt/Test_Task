using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Test_WEB_Api.Interfaces;
using Test_WEB_Api.Models;

namespace Test_WEB_Api.Repositories
{
    public class SentenceRepository : IRepository<Sentence>
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
 
        //public Sentence Get(int id)
        //{
        //    return db.Sentences.Find(id);
        //}
 
        public void Create(Sentence sentence)
        {
            db.Sentences.Add(sentence);
        }
 
        public void Update(Sentence sentence)
        {
            db.Entry(sentence).State = EntityState.Modified;
        }
 
        //public IEnumerable<Phone> Find(Func<Phone, Boolean> predicate)
        //{
        //    return db.Phones.Where(predicate).ToList();
        //}
 
        //public void Delete(int id)
        //{
        //    Phone book = db.Phones.Find(id);
        //    if (book != null)
        //        db.Phones.Remove(book);
        //}
    }
}