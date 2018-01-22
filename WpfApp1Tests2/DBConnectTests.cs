using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Tests
{
    [TestClass()]
    public class DBConnectTests
    {
        [TestMethod()]
        public void OpenConnectionTest()
        {
            var report = new DBConnect();
            bool expected = true;
            bool returned;
            returned = report.OpenConnection();
            Assert.AreEqual(expected, returned);
        }

        [TestMethod()]
        public void CloseConnectionTest()
        {
            var report = new DBConnect();
            bool expected = true;
            bool returned;
            returned = report.CloseConnection();
            Assert.AreEqual(expected, returned);
        }
    }
}