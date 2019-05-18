using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Business_Layer
{
    public class Actions
    {
        private static string path = @"D:\Sneghka\IT\Visual Studio\TODO List\Tasks.json";
        //private static string DatabaseFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database", "Tasks.json");

        public static List<T> LoadData<T>()
        {    
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
        }

        public static void SaveData<T>(T tasks)
        {
            var newJsonFile = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            File.WriteAllText(path, newJsonFile);
        }      
    }
}
