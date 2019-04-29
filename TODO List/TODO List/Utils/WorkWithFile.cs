using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TODO_List.Objects;


namespace TODO_List.Utils
{
    public static class WorkWithFile
    {
        public static List<Item> LoadJson(string path)
        {

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Item>>(json);
            }

        }

        public static void TaskListToJson(Items tasks, string path)
        {
            var newJsonFile = JsonConvert.SerializeObject(tasks.itemList, Formatting.Indented);
            File.WriteAllText(path, newJsonFile);
        }

    }
}
