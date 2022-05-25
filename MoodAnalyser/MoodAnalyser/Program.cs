using System;

namespace MoodAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            Mood_Analyser moodAnalyserr = new Mood_Analyser("Iam in Sad Mood");
            Console.WriteLine(moodAnalyserr.MoodCheck());
        }
    }
}
