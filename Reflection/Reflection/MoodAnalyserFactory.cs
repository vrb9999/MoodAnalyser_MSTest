using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Reflection
{
    public class MoodAnalyserFactory
    {
        public static object CreateeMoodAnalyse(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new Custom_MoodAnalyser(Custom_MoodAnalyser.ExceptionType.NO_SUBH_CLASS, "Class Not Found");
                }
            }
            else
            {
                throw new Custom_MoodAnalyser(Custom_MoodAnalyser.ExceptionType.NO_SUCH_METHOD, "Constructor is Not Found");
            }
        }
    }
}
