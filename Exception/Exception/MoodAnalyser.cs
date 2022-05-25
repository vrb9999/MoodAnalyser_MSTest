using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_Exception
{
    public class MoodAnalyser
    {
        string message;
        public MoodAnalyser(string message)
        {
            this.message = message;
        }

        public string CheckMood()
        {
            try
            {
                if (message.Equals(string.Empty))
                {
                    throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.EMPTY_EXCEPTION, "Mood should not be empty");
                }
                else if (this.message.ToLower().Contains("sad"))
                {
                    return "sad";
                }
                else
                {
                    return "happy";
                }
            }
            catch (NullReferenceException)
            {
                throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.NULL_EXCEPTION, "mood should not be null");
            }
        }
    }
}
