using System;
using System.Collections.Generic;
using System.Text;

namespace Exception_Handling
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
                if (this.message.ToLower().Contains("sad"))
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
                return "happy";
            }
        }
    }
}
