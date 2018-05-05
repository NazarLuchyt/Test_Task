using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_WEB_Api.Models;
using System.IO;
using System.Text;
using Test_WEB_Api.Repositories;

namespace Test_WEB_Api.Helpers
{
   static public class ParseString
    {
        static public List<Sentence> Parse(HttpPostedFileBase file, string SearchWord, int NextID)
        {
          //  string result1 = new StreamReader(File.InputStream).ReadToEnd(); // ще один спосіб зчитування

            BinaryReader b = new BinaryReader(file.InputStream);
            byte[] binData = b.ReadBytes(file.ContentLength);
            List<string> list = new List<string>();
            string _file = System.Text.Encoding.UTF8.GetString(binData);
            string AddToData;
            int IndexPoint = -1;
            while ((IndexPoint = _file.IndexOf('.')) >= 0)
            {

                if ((AddToData = _file.Substring(0, IndexPoint)).IndexOf(SearchWord, StringComparison.CurrentCultureIgnoreCase) >= 0)
                {
                    list.Add(AddToData);
                }
                _file = _file.Remove(0, IndexPoint);
                _file = _file.TrimStart(new char[] { ' ', '.' });
            }
            return ReverseString(list, SearchWord, NextID);
        }

        static public List<Sentence> ReverseString(List<string> list, string SearchWord, int NextID)
        {
            int IndexPoint;
            int counter;
            int _ID = NextID;
            List<Sentence> array = new List<Sentence>(); 
            foreach (string t in list)
            {
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

                array.Add(new Sentence { ID = ++_ID, Body = buff, Counter = counter });
            }
            return array;
           
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}