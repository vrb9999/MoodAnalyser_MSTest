using Microsoft.VisualStudio.TestTools.UnitTesting;
using Custom_Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_Exception.Tests
{
    [TestClass()]
    public class MoodAnalyserTests
    {
        MoodAnalyser mac, Mac, macNull, macEmpty;
        string msg;
        [TestInitialize]
        public void Setup()
        {
            this.msg = "Im in a Happy Mood";
            mac = new MoodAnalyser(this.msg);
            Mac = new MoodAnalyser("im in sad mood");
            macNull = new MoodAnalyser(null);
            macEmpty = new MoodAnalyser(string.Empty);
        }
        [TestMethod]
        [TestCategory("happy")]
        public void TestMethodForMessageHappy()
        {
            //Arrange
            string actual, expected = "happy";
            //Act
            actual = mac.CheckMood();
            //Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        [TestCategory("sad")]
        public void TestMethodForMessageSad()
        {
            //Arrange
            string actual, expected = "sad";
            //Act
            actual = Mac.CheckMood();
            //Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        [TestCategory("null")]
        public void TestMethodForMessageNull()
        {
            try
            {
                //Arrange
                string actual;
                //Act
                actual = macNull.CheckMood();

            }
            catch (CustomMoodAnalyser ex)
            {
                string expected = "mood should not be null";
                //Assert
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("empty")]
        public void TestMethodForMessageEmpty()
        {
            try
            {
                string actual;
                //Act
                actual = macEmpty.CheckMood();
            }
            catch (CustomMoodAnalyser ex)
            {
                //Arrange
                string expected = "Mood should not be empty";

                //Assert
                Assert.AreEqual(expected, ex.Message);
            }

        }
    }
}