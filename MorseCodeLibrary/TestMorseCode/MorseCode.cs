using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MorseCodeLibrary;
using System.Collections;
using System.Diagnostics;

namespace TestMorseCode
{
    [TestClass]
    public class MorseCode
    {
        /// <summary>
        /// Checks if the Method "organizeInput" is splitting the inputdata correct
        /// </summary>
        [TestMethod]
        public void organizeInput()
        {
            WorkWithData workWithData = new WorkWithData();
            workWithData.data = ".... . .-.. .-.. ---    .-- --- .-. .-.. -..";

            workWithData.organizeInput();
            ArrayList testlist = new ArrayList();
            testlist.Add(".... . .-.. .-.. ---");
            testlist.Add(".-- --- .-. .-.. -..");

            CollectionAssert.AreEqual(testlist, workWithData.splittedMessage);
        }

        /// <summary>
        /// Checks if the given Input Data is correct MorseCode
        /// </summary>
        [TestMethod]
        public void correctData()
        {
            WorkWithData workWithData = new WorkWithData();
            workWithData.data = ".... . .-.. .-.. ---    .-- --- .-. .-.. -..";

            Assert.AreEqual(true, workWithData.controlData());
        }

        /// <summary>
        /// Checks if the given Input Data is correct MorseCode
        /// </summary>
        [TestMethod]
        public void toManySpaces()
        {
            WorkWithData workWithData = new WorkWithData();
            workWithData.data = ".... . .-.. .-.. ---     .-- --- .-. .-.. -.."; //this String has 5 spaces instead of 4

            Assert.AreEqual(false, workWithData.controlData());
        }

        /// <summary>
        /// Checks if the given Input Data is correct MorseCode
        /// </summary>
        [TestMethod]
        public void toLessSpaces()
        {
            WorkWithData workWithData = new WorkWithData();
            workWithData.data = ".... . .-.. .-.. ---  .-- --- .-. .-.. -.."; //this String has 3 spaces instead of 4

            Assert.AreEqual(false, workWithData.controlData());
        }

        /// <summary>
        /// Checks if the given Input Data is correct MorseCode
        /// </summary>
        [TestMethod]
        public void wrongChars()
        {
            WorkWithData workWithData = new WorkWithData();
            workWithData.data = "a.... . .-.. .-.. ---   .-- --- .-. .-.. -.."; //this String contains a wrong char

            Assert.AreEqual(false, workWithData.controlData());
        }
    }
}
