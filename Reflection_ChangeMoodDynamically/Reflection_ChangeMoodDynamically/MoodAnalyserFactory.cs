using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Reflection_ChangeMoodDynamically
{
    public class MoodAnalyserFactory
    {
        public static object CreateMoodAnalyse(string className, string constructorName)
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
        public static object CreateMoodAnalyserUsingParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new Custom_MoodAnalyser(Custom_MoodAnalyser.ExceptionType.NO_SUCH_METHOD, "Constructor is not Found");
                }
            }
            else
            {
                throw new Custom_MoodAnalyser(Custom_MoodAnalyser.ExceptionType.NO_SUBH_CLASS, "Class Not Found ");
            }
        }
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("Reflection_ChangeMoodDynamically.MoodAnalyser");
                object moodAnalyserObject = MoodAnalyserFactory.CreateMoodAnalyserUsingParameterizedConstructor("Reflection_ChangeMoodDynamically.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo AnalseMoodInfo = type.GetMethod(methodName);
                object mood = AnalseMoodInfo.Invoke(moodAnalyserObject, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new Custom_MoodAnalyser(Custom_MoodAnalyser.ExceptionType.NO_SUCH_METHOD, "Method is Not Found");
            }
        }
        public static string SetField(string msg, string fieldName)
        {
            try
            {
                MoodAnalyser moodAnalyser = new MoodAnalyser();
                Type type = Type.GetType("Reflection_ChangeMoodDynamically.MoodAnalyser");
                FieldInfo fieldInfo = type.GetField(fieldName);
                if (msg == null)
                {
                    throw new Custom_MoodAnalyser(Custom_MoodAnalyser.ExceptionType.NULL_MESSAGE, "message should not be null");
                }
                fieldInfo.SetValue(moodAnalyser, msg);
                return moodAnalyser.AnalyseMood();
            }
            catch (NullReferenceException)
            {
                throw new Custom_MoodAnalyser(Custom_MoodAnalyser.ExceptionType.NO_SUCH_FIELD, "field not found check the field name");
            }
        }
    }
}
