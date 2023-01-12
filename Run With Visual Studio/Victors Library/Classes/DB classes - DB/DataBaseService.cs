using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml;
using Victors_Library.Classes;
using static Victors_Library.Exceptions_Class;
using Formatting = Newtonsoft.Json.Formatting;

namespace Victors_Library
{
    public class DataBaseService 
    {
        private static string _FilePath = @"json DB.json"; //set name, starts looking here anyway

        private string _jsonData = System.IO.File.ReadAllText(_FilePath); //read all text


        public DataBaseService() //checks if file exists, if not makes one for the first use
        {     
            if (!File.Exists(_FilePath))
            {
                using (FileStream file = new FileStream(_FilePath, FileMode.Create))
                {
                    file.Close();
                }
            }
        }

        public void SaveData(object data) //save data to the json
        {
            string UpdatedList = ObjectToJson(data);
            WriteFile(UpdatedList);
        }

        private string ObjectToJson(object data)
        {
            return JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore
            });
        }
        private void WriteFile(string data)
        {
            using (StreamWriter writer = new StreamWriter(_FilePath))
            {
                writer.Write(data);
                writer.Dispose();
            }
        }

        public static List<Library_Class> GetData()
        {
            try
            {
                string strConvert = File.ReadAllText(_FilePath);
                List<Library_Class> data = JsonConvert.DeserializeObject<List<Library_Class>>(strConvert, new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    NullValueHandling = NullValueHandling.Ignore,
                });
                return data;
            }
            catch (Exception ex)
            {
                ExceptionLogsDB exceptionLogsDB = new ExceptionLogsDB();
                exceptionLogsDB.AddException(ex);
                return null;
            }
        }

    }


}
