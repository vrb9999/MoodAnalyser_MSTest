using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection_Parameter
{
    public class Custom_MoodAnalyser : Exception
    {
        public enum ExceptionType
        {
            NULL_MESSAGE,
            EMPTY_MESSAGE,
            NO_SUCH_FIELD,
            NO_SUCH_METHOD,
            NO_SUBH_CLASS,
            OBJECT_CREATION_ISSUE
        }

        private readonly ExceptionType type;
        public Custom_MoodAnalyser(ExceptionType type, String message) : base(message)
        {
            this.type = type;
        }
    }
}
