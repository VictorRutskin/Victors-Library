using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Victors_Library
{
    public class RemovedBooksLogsDB
    {

        private static string _FilePath = AppDomain.CurrentDomain.BaseDirectory + @"\Logs\RemovedBooksLogs.json"; //set name, starts looking here anyway

        private string _jsonData = System.IO.File.ReadAllText(_FilePath); //read all text

        public static List<Library_Class> RemovedBooks = GetData(); //when booklist initialized automatically se library to get data



        public RemovedBooksLogsDB() //checks if file exists, if not makes one for the first use
        {
            if (!File.Exists(_FilePath))
            {
                using (FileStream file = new FileStream(_FilePath, FileMode.Create))
                {
                    file.Close();
                }
            }
        }

        public static void AddBookRemovedDB(string name, bool Updatedb) //adds a book to the list after checking type
        {

            foreach (Library_Class library_Class in BookList_Class.library)
            {
                if (library_Class.Name == name)
                {
                    RemovedBooks.Add(library_Class);
                }
            }

            if (Updatedb == true)
            {
                RemovedBooksLogsDB removedBooksLogs = new RemovedBooksLogsDB();
                removedBooksLogs.SaveData(RemovedBooks);
                //update UI
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
    public class BoughtBooksLogsDB
    {

        private static string _FilePath = AppDomain.CurrentDomain.BaseDirectory + @"\Logs\BoughtBooksLogs.json"; //set name, starts looking here anyway
        private string _jsonData = System.IO.File.ReadAllText(_FilePath); //read all text

        public static List<Library_Class> BoughtBooks = GetData(); //when booklist initialized automatically se library to get data


        public BoughtBooksLogsDB() //checks if file exists, if not makes one for the first use
        {
            if (!File.Exists(_FilePath))
            {
                using (FileStream file = new FileStream(_FilePath, FileMode.Create))
                {
                    file.Close();
                }
            }
        }
        public static void AddBookBoughtDB(string name, bool Updatedb) //adds a book to the list after checking type
        {

            foreach (Library_Class library_Class in BookList_Class.library)
            {
                if (library_Class.Name == name)
                {
                    BoughtBooks.Add(library_Class);
                }
            }

            if (Updatedb == true)
            {
                BoughtBooksLogsDB boughtBooksLogs = new BoughtBooksLogsDB();
                boughtBooksLogs.SaveData(BoughtBooks);
                //update UI
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
                string strConvert = File.ReadAllText(_FilePath);//change later to you't AbstractItem
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
    public class AddedBooksLogsDB
    {

        private static string _FilePath = AppDomain.CurrentDomain.BaseDirectory + @"\Logs\AddedBooksLogs.json"; //set name, starts looking here anyway
        private string _jsonData = System.IO.File.ReadAllText(_FilePath); //read all text

        public static List<Library_Class> AddedBooks = GetData(); //when booklist initialized automatically se library to get data


        public AddedBooksLogsDB() //checks if file exists, if not makes one for the first use
        {
            if (!File.Exists(_FilePath))
            {
                using (FileStream file = new FileStream(_FilePath, FileMode.Create))
                {
                    file.Close();
                }
            }
        }

        public static void AddBookAddedDB(string name, bool Updatedb) //adds a book to the list after checking type
        {

            foreach (Library_Class library_Class in BookList_Class.library)
            {
                if (library_Class.Name == name)
                {
                    AddedBooks.Add(library_Class);
                }
            }

            if (Updatedb == true)
            {
                AddedBooksLogsDB addedBooksLogsDB = new AddedBooksLogsDB();
                addedBooksLogsDB.SaveData(AddedBooks);
                //update UI
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
                string strConvert = File.ReadAllText(_FilePath);//change later to you't AbstractItem
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
    public class ExceptionLogsDB
    {

        private static string _FilePath = AppDomain.CurrentDomain.BaseDirectory + @"\Logs\ExceptionLogs.json"; //set name, starts looking here anyway
        private string _jsonData = System.IO.File.ReadAllText(_FilePath); //read all text

        public static List<Exception> Exceptions = GetData(); //when booklist initialized automatically se library to get data


        public ExceptionLogsDB() //checks if file exists, if not makes one for the first use
        {
            if (!File.Exists(_FilePath))
            {
                using (FileStream file = new FileStream(_FilePath, FileMode.Create))
                {
                    file.Close();
                }
            }
        }

        public void AddException(Exception exception) //adds the exception
        {
            Exceptions.Add(exception);

            SaveData(Exceptions);

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

        public static List<Exception> GetData()
        {
            try
            {
                string strConvert = File.ReadAllText(_FilePath);//change later to you't AbstractItem
                List<Exception> data = JsonConvert.DeserializeObject<List<Exception>>(strConvert, new JsonSerializerSettings()
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
