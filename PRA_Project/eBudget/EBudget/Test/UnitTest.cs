using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EBudget.Models;
using EBudget.Controllers;
using System.Web.Mvc;

namespace Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void CreatePrihodTrosak()
        {
            CreatePrihodView cpt = new CreatePrihodView();          
            Assert.IsTrue(cpt != null, "CreateTrosak je null");
        }

        [TestMethod]
        public void CreateDetaljiTrosakPrihod()
        {
            DetaljiTrosakPrihodModelView d = new DetaljiTrosakPrihodModelView();
            Assert.IsTrue(d != null, "Detalji su null");

        }

        [TestMethod]
        public void TestMainController()
        {
            var kontroler = new MainController();
            var result = kontroler.CreatePrihod() as ViewResult;

            Assert.AreEqual("CreatePrihod", result.ViewName);
        }

        [TestMethod]
        public void TestViewPrihodController()
        {
            var pregled = new PregledPrihodController();
            var viewResultIndex = pregled.Index() as ViewResult;
            
            Assert.AreEqual("Index", viewResultIndex.ViewName);

            var viewResultEdit = pregled.Edit(1) as ViewResult;
            Assert.AreEqual("Edit", viewResultEdit.ViewName);

        }

        [TestMethod]
        public void TestViewTrosakController()
        {
            var pregled = new PregledTrosakController();
            var viewResultIndex = pregled.Index() as ViewResult;

            Assert.AreEqual("Index", viewResultIndex.ViewName);

            var viewResultEdit = pregled.Edit(1) as ViewResult;
            Assert.AreEqual("Edit", viewResultEdit.ViewName);

        }
    }   
}
