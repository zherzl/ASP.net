using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EBudget.Models;

namespace Testovi
{
    /// <summary>
    /// Summary description for TestBaza
    /// </summary>
    [TestClass]
    public class TestBaza
    {
        public TestBaza()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        
        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Add test logic here
            //
            UsersContext db = new UsersContext();
            Assert.IsTrue(db != null, "Veza s bazom nije uspostavljena");
        }
    }
}
