using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflection_ChangeMoodDynamically;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection_ChangeMoodDynamically.Tests
{
    [TestClass()]
    public class MoodAnalyserTests
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
            object obj = MoodAnalyserFactory.CreateMoodAnalyse("Reflection_ChangeMoodDynamically.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyserObject_UsingParameterizdConstructor()
        {
            object expected = new MoodAnalyser("HAPPY");
            object obj = MoodAnalyserFactory.CreateMoodAnalyserUsingParameterizedConstructor("Reflection_ChangeMoodDynamically.MoodAnalyser", "MoodAnalyser", "HAPPY");
            expected.Equals(obj);
        }
        [TestMethod]
        public void GiveHappyMoodShouldReturnHappy()
        {
            string expected = "HAPPY";
            string mood = MoodAnalyserFactory.InvokeAnalyseMood("Happy", "AnalyseMood");
            Assert.AreEqual(expected, mood);
        }
        [TestMethod]
        [TestCategory("ChangeMoodDynamically")]
        public void SetFieldReturnsHappy()
        {
            try
            {
                string message = "sad";
                string fieldName = "fieldName";
                string actual = MoodAnalyserFactory.SetField(message, fieldName);
            }
            catch (Custom_MoodAnalyser ex)
            {
                Assert.AreEqual("field not found check the field name", ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("ChangeMoodDynamically")]
        public void SetFieldReturnsNoSuchField()
        {
            try
            {
                string message = "happy";
                string fieldName = "fieldName";
                string actual = MoodAnalyserFactory.SetField(message, fieldName);
            }
            catch (Custom_MoodAnalyser ex)
            {
                Assert.AreEqual("field not found check the field name", ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("ChangeMoodDynamically")]
        public void SetFieldReturnsNullMessage()
        {
            try
            {
                string message = null;
                string fieldName = "message";
                string actual = MoodAnalyserFactory.SetField(message, fieldName);
            }
            catch (Custom_MoodAnalyser ex)
            {
                Assert.AreEqual("message should not be null", ex.Message);
            }
        }
    }
}