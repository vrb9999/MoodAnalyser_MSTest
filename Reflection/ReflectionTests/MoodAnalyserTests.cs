using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenSadMessage_WhenSad_ShouldReturnSAD()
        {
            //Arrange
            string Expected = "SAD";
            MoodAnalyser MoodAnalysers = new MoodAnalyser("I am in Sad Mood");
            //Act
            string result = MoodAnalysers.AnalyseMood();
            //Assert
            Assert.AreEqual(Expected, result);
        }
        [TestMethod]
        public void GivenHappyMessage_WhenAnyMood_ShouldReturnHAPPY()
        {
            //Arrange
            string Expected = "HAPPY";
            MoodAnalyser MoodAnalysers = new MoodAnalyser("I am in Happy Mood");
            //Act
            string result = MoodAnalysers.AnalyseMood();
            //Assert
            Assert.AreEqual(Expected, result);
        }
        [TestMethod]
        public void GivenAnyMessage_WhenAnyMood_ShouldReturnHAPPY()
        {
            //Arrange
            string Expected = "HAPPY";
            MoodAnalyser MoodAnalysers = new MoodAnalyser("I am in Any Mood");
            //Act
            string result = MoodAnalysers.AnalyseMood();
            //Assert
            Assert.AreEqual(Expected, result);
        }
        [TestMethod]
        [DataRow("null")]
        public void GivenNULLMessage_WhenANULL_ShouldReturnHAPPY(string message)
        {
            //Arrange
            string Expected = "Happy";
            MoodAnalyser moodAnalyser = new MoodAnalyser(message);
            //Act
            string result = moodAnalyser.AnalyseMood();
            //Assert
            Assert.AreEqual(Expected, result);
        }
        [TestMethod]
        [DataRow("")]
        public void GivenEmptyMessage_WhenEmpty_ShouldThrowException(string message)
        {
            try
            {
                //Arrange
                MoodAnalyser MoodAnalysers = new MoodAnalyser(message);
                //Act
                string result = MoodAnalysers.AnalyseMood();
                //Assert
            }
            catch (Custom_MoodAnalyser e)
            {
                Assert.AreEqual("Mood should not be empty", e.Message);
            }

        }
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyserObject()
        {
            object expected = new MoodAnalyser();
            object obj = MoodAnalyserFactory.CreateeMoodAnalyse("Reflection.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }
    }
}