using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_WEB_Api.Models;
using System.IO;
using System.Text;

namespace Test_WEB_Api.Controllers
{
    public class HomeController : Controller
    {
        SentenceContext db = new SentenceContext();
        static int ind;
        public ActionResult Index()
        {
            IEnumerable<Sentence> sentences = db.Sentences;
            ind = sentences.Count();
            ViewBag._Sentences = sentences;
            
            return View();
        }

        [HttpPost]
        public ActionResult FindAndAdd(HttpPostedFileBase File,string SearchWord)
        {
            if (File != null)
            {
               
           //    string result1 = new StreamReader(File.InputStream).ReadToEnd(); // ще один спосіб зчитування

               BinaryReader b = new BinaryReader(File.InputStream);
               byte[] binData = b.ReadBytes(File.ContentLength);
               ArrayList list = new ArrayList();
                string f = System.Text.Encoding.UTF8.GetString(binData);
                string AddToData;
                int IndexPoint = -1;
                while ((IndexPoint = f.IndexOf('.')) >= 0)
                {

                    if ((AddToData = f.Substring(0, IndexPoint)).IndexOf(SearchWord, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        list.Add(AddToData);
                        f = f.Remove(0, IndexPoint);
                        f = f.TrimStart(new char[] { ' ', '.' });
                    }
                    else
                    {
                        f = f.Remove(0, IndexPoint);
                        f = f.TrimStart(new char[] { ' ', '.' });
                    }
                }
                Sentence sent = new Sentence();
                int counter,rangeString;
               
                foreach(string t in list)
                {
                    //   StringBuilder buff = new StringBuilder(t.Length);
                    string buff;
                    counter = 0;
                    IndexPoint = 0;
                    for (;;)
                    {
                        if ((IndexPoint = t.IndexOf(SearchWord, IndexPoint, StringComparison.CurrentCultureIgnoreCase)) >= 0)
                        {
                            counter++;
                            IndexPoint++;
                        }
                        else break;
                    }
                    buff = Reverse(t);
                    db.Sentences.Add(new Sentence { ID = ++ind, Body = buff, Counter = counter });
                }
                db.SaveChanges();


            }
            return RedirectToAction("Index");
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }


    }
}