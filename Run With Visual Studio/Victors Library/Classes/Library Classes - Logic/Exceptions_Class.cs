using System;
using System.Collections.Generic;

namespace Victors_Library
{
    public class Exceptions_Class : Exception
    {
        public static List<Exception> exceptions = ExceptionLogsDB.GetData();

        private string _Name;
        private string _Description;
        private string _Explanation;
        private string _Time;


        public List<Exception> ExceptionList
        {
            get { return exceptions; }
            set { exceptions = value; }
        }

        public Exceptions_Class(string name ="", string description ="", string explanation = "")
        {
            _Name = name;
            _Description = description;
            _Explanation = explanation;

        }

        public class IlegalBookAddingException : Exceptions_Class
        {

            public IlegalBookAddingException(string explanation = "") : base()
            {
                DateTime Now = DateTime.Now;

                _Name = "IlegalBookAdding";
                _Description = "Tried to add a book with missing some parameters.";
                _Explanation = explanation;
                _Time = Now.ToString();

            }
        }
        public class DuplicateBookAddingException : Exceptions_Class
        {

            public DuplicateBookAddingException(string explanation = "") : base()
            {
                DateTime Now = DateTime.Now;

                _Name = "DuplicateBookAddingException";
                _Description = "Tried to add a book that already exists.";
                _Explanation = explanation;
                _Time = Now.ToString();

            }
        }

        public class NoBookSelectedException : Exceptions_Class
        {

            public NoBookSelectedException(string explanation = "No more information") : base()
            {
                DateTime Now = DateTime.Now;

                _Name = "NoBookSelectedException";
                _Description = "No book was selected";
                _Explanation = explanation;
                _Time = Now.ToString();

            }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public string Explanation
        {
            get { return _Explanation; }
            set { _Explanation = value; }
        }
        public string TimeOfException
        {
            get { return _Time; }
            set { _Time = value; }
        }
    }
  


}
