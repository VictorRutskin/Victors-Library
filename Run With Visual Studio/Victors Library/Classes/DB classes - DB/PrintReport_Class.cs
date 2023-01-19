using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Victors_Library.Classes.DB_classes___DB
{
    public class PrintReport //converts the search to a text file report
    {
        public static string FolderPath = AppDomain.CurrentDomain.BaseDirectory + @"/Reports/Latest Report.txt";

        public static List<Library_Class> Onhold= DataBaseService.GetData();
        public void PrintTextReport()
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();

                DateTime Now = DateTime.Now;
                stringBuilder.AppendLine("Report Details: " + Now.ToString());

                stringBuilder.AppendLine("The Books that are in this report: ");

                foreach (Library_Class library in Onhold)
                {
                    stringBuilder.AppendLine(library.Name);
                }

                File.WriteAllText(FolderPath, stringBuilder.ToString());
            }
            
            catch (Exception exception)
            {
                ExceptionLogsDB exceptionLogsDB = new ExceptionLogsDB();
                exceptionLogsDB.AddException(exception);

            }
        }
    }
}
