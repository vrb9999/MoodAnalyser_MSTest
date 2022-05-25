using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class Mood_Analyser
    {
        private const string SAD = "Iam in Sad Mood";
        private const string HAPPY = "Iam in Happy Mood";
        private string message;
        public Mood_Analyser(string message)
        {
            this.message = message;
        }
        public string MoodCheck()
        {
            if (message == SAD)
                return "SAD";
            if (message == HAPPY)
                return "HAPPY";
            return null;
        }
    }
}
