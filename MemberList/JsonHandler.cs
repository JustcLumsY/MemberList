using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace MemberList
{
    public static class JsonHandler
    {
        private static string path = @"C:\Users\cLuMsY\Desktop\MemberList.json";
        private static string text = File.ReadAllText(path);
       
     
        public static void WriteToJson(List<Member> model)
        {
            //Stopwatch kan sjekke hvor rask en methode er eller en del av en kode.
            var sw = new Stopwatch();
            sw.Start();

            //Gjør om ett object til en Json string.
            //Serialisere er å gjøre om noe
            var json = JsonConvert.SerializeObject(model);

            //Skriver all teksten til en path på disk
            File.WriteAllText(path, json); 

            sw.Stop();
            Console.WriteLine($"{sw.ElapsedMilliseconds}ms"
            );
        }
        
        public static List<Member> GetListFromJson()
        {   //Deserialize gjør om en string til ett object
            var m = JsonConvert.DeserializeObject<List<Member>>(text);
            //Første gang når filen er tom vil objectet være null.
            //Om den er null så oppretter vi objectet
            if (m == null) { m = new List<Member>(); }
            return m;       
        }
      
        //public static void Debug()
        //{
        //    var temp = new List<Member>();
        //    for (int i = 0; i < 10000; i++)
        //    {
        //        temp.Add(new Member
        //        {
        //            FirstName = $"Name: {i}",
        //            LastName = $"LastName: {i}",
        //            Age = i
        //        }    ); 
        //    }
        //    WriteToJson(temp);
        //}
    }
}
