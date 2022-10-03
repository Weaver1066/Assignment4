using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment4.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1;

namespace Assignment4.Managers.Tests
{
    [TestClass()]
    public class FootballPlayersManagerTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            FootballPlayersManager _manager = new FootballPlayersManager();
            int result = _manager.GetAll().Count;
            Assert.AreEqual(4, result);
        }


        [TestMethod()]
        public void GetFootballPlayerByIdTest()
        {
            FootballPlayersManager _manager = new FootballPlayersManager();
            FootballPlayer player1 = _manager.GetFootballPlayerById(3);
            Assert.AreEqual(3, player1.id);
            Assert.AreEqual(42, player1.ShirtNumber);
        }
    }
}