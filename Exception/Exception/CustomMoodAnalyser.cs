using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_Exception
{
    public class CustomMoodAnalyser : Exception
    {        
        ExceptionType type;
        public enum ExceptionType
        {
            NULL_EXCEPTION, EMPTY_EXCEPTION
        }        
        public CustomMoodAnalyser(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
