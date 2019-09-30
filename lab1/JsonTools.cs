using Newtonsoft.Json;
using System.IO;

namespace lab1
{
    class JsonTools
    {
        public static void SaveStudentsGroup(Group group, string path)
        {
            string json = JsonConvert.SerializeObject(group);

            try
            {
                File.WriteAllText(path, json);
            }
            catch
            {
                System.Console.WriteLine("Неверное имя или путь к файлу.");
            }
        }
    }
}
