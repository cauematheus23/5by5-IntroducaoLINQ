using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAula1B
{
    public class ReadFile
    {

        public static List<PenalidadesAplicadas> GetData(string path)
        {
            StreamReader reader = new StreamReader(path);
            string jsonString = reader.ReadToEnd();
            var lst = JsonConvert.DeserializeObject<MotoristaHabilitado>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy"});
            
            if(lst != null)  return lst.PenalidadesAplicadas;
            return null;
           
        }
    }
}
