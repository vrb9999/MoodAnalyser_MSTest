using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection_InvokeMethod
{
    public class MoodAnalyser
    {
        private string message;
        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        public MoodAnalyser()
        {
        }
        public string AnalyseMood()
        {
            try
            {
                if (this.message.Equals(string.Empty))
                {
                    throw new Custom_MoodAnalyser(Custom_MoodAnalyser.ExceptionType.EMPTY_MESSAGE, "Mood should not be empty")
                    {

                    };
                }
                if (this.message.Contains("Sad"))
                {
                    return "SAD";
                }
                else if (this.message.Contains("Happy"))
                {
                    return "HAPPY";
                }
                else if (this.message.Contains("Any"))
                {
                    return "HAPPY";
                }
                else
                {
                    return "Happy";
                }
            }
            catch (NullReferenceException)
            {
                throw new Custom_MoodAnalyser(Custom_MoodAnalyser.ExceptionType.NULL_MESSAGE, "Message should not be null")
                {

                };
            }
        }
    }
}
