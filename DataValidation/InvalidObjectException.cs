using System;
using System.Collections.Generic;

namespace DataValidation
{
    public class InvalidObjectException : Exception
    {
        public string ObjectName { get; internal set; }
        public object InvalidObject { get; internal set; }
        public List<string> ErrorMessages { get; internal set; }

        public InvalidObjectException(string objectName, object invalidObject, List<string> errorMessages)
        {
            this.ObjectName = objectName;
            this.InvalidObject = invalidObject;
            this.ErrorMessages = errorMessages;
        }
    }
}
