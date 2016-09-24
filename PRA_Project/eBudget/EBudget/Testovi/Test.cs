using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EBudget.Models;
using EBudget.Controllers;

namespace Testovi
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestCreate()
        {
            CreatePrihodTrosakView cptv = new CreatePrihodTrosakView();

            Assert.IsTrue(cptv != null, "Konstruk tor nije implementiran!");
        }

    }
}
