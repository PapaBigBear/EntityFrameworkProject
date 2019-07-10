using System;
using System.Collections.Generic;

namespace CMDDto.Common
{
    public class RequestResult
    {
        public bool IsSucceeded { get; set; }
        public string Message { get; set; }
        public Object Result { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
