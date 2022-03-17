using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace JsonHandler
{
    public class JsonHandler
    {
        private static string path = @"";
        private static string text = File.ReadAllText(path);
        public static List<> GetListFromJson()
        {
            var temp = JsonConvert.DeserializeObject<List<>>(text);
            return temp;
        }
        public static void WriteToJson(List<> temp)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(temp));
        }
    }
}
