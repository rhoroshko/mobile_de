using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobile_de
{
    public class Cars
    {
        private Dictionary<string, List<string>> cars;

        public void LoadJson()
        {
            using (StreamReader r = new StreamReader(@"data\cars.json"))
            {
                string json = r.ReadToEnd();
                cars = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);
            }
        }

        public List<string> GetMakes()
        {
            return cars.Keys.ToList();
        }

        public List<string> GetMakeModels(string make)
        {
            return cars[make];
        }
    }
}
