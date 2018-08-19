using Stitchy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Stitchy
{
    public class PersistenceProcessor
    {
        private readonly string DirectoryName = @"C:\Stitchy";
        private readonly string SaveFileName = "saveData.json";

        public void Save(List<Stitch> data)
        {
            var jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);

            Directory.CreateDirectory(DirectoryName);

            try
            {
                using (StreamWriter file = new StreamWriter($"{DirectoryName}\\{SaveFileName}", false))
                {
                    file.Write(jsonData.ToCharArray());
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return;
        }

        public List<Stitch> Open()
        {
            var data = new List<Stitch>();

            try
            {
                using (StreamReader file = File.OpenText($"{DirectoryName}\\{SaveFileName}"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    data = (List<Stitch>)serializer.Deserialize(file, typeof(List<Stitch>));
                }
            }
            catch { }

            return data;
        }
    }
}
