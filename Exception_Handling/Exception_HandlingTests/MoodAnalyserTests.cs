using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exception_Handling;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exception_Handling.Tests
{
    [TestClass()]
    public class MoodAnalyserTests
    {
        MoodAnalyser mac, Mac, macNull;
        string msg;
        [TestInitialize]
        public void Setup()
        {
            this.msg = "Im in a Happy Mood";
            mac = new MoodAnalyser(this.msg);
            Mac = new MoodAnalyser("im in sad mood");
            macNull = new MoodAnalyser(null);
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
            //Arrange
            string actual, expected = "happy";
            //Act
            actual = macNull.CheckMood();
            //Assert
            Assert.AreEqual(actual, expected);
        }
    }
}