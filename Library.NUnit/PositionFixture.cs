using NUnit.Framework;
using Application;
using System.Collections.Generic;
using System;
namespace Library.NUnit
{
    internal sealed class PositionFixture
    {
        List<Position> positionList;
        private TestContext testContextInstance;

        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var pos = new Position(1, 2, 3);
            Assert.That(pos, Is.Not.Null);        
        }

        [Test]
        public void PositionDuplicatedExceptionTest()
        {
            positionList = new List<Position>();
            positionList.Add(new Position(1, 2, 3));
            positionList.Add(new Position(1, 2, 3));
            
            PositionDuplicatedException ex = Assert.Throws<PositionDuplicatedException>(() => Program.checkDuplicatedPosition(positionList));
            Assert.AreEqual("Position Duplicated", ex.Message);
        }

        [Test]
        public void CalculateDistanceTest()
        {
            positionList = new List<Position>();
            positionList.Add(new Position(1, 2, 3));
            positionList.Add(new Position(3, 4, 5));
            positionList.Add(new Position(7, 8, 9));
            positionList.Add(new Position(7, 7, 7));
            List<double> actual = Calculator.CalculateDistance(positionList);
            List<double> excpected = new List<double> { 314859.0672789808d, 629718.1345579616d, 111319.49081123987d, 869433.01689946011d };
            Assert.AreEqual(actual, excpected);
        }
    }
}