using System;
using System.IO;
using System.Text.Json;

namespace Cserv.Services
{
    public class DataStorageService
    {
        private string folderPath =
            Path.Combine(Directory.GetCurrentDirectory(), "Data");

        private JsonSerializerOptions options =
            new JsonSerializerOptions
            {
                WriteIndented = true
            };

        public void SaveData<T>(string fileName, T data)
        {
            Directory.CreateDirectory(folderPath);

            string path = Path.Combine(folderPath, fileName);

            string json = JsonSerializer.Serialize(data, options);

            File.WriteAllText(path, json);

            Console.WriteLine(fileName + " saved successfully.");
        }

        public T LoadData<T>(string fileName, T defaultData)
        {
            string path = Path.Combine(folderPath, fileName);

            if (!File.Exists(path))
            {
                return defaultData;
            }

            string json = File.ReadAllText(path);

            T? data = JsonSerializer.Deserialize<T>(json, options);

            if (data == null)
            {
                return defaultData;
            }

            return data;
        }
    }
}

