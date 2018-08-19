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
        public void Save(List<Stitch> data)
        {
            var jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);

            var saveDirectory = @"C:\Stitchy";
            Directory.CreateDirectory(saveDirectory);

            try
            {
                using (StreamWriter file = new StreamWriter($"{saveDirectory}\\saveData.json", false))
                {
                    file.Write(jsonData.ToCharArray());
                }
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
            }

            return;
        }
    }
}
