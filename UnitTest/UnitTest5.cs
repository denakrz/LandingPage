using System.Collections.Generic;
using LUG3WebApi.Added;
using LUG3WebApi.Authentication.Model;
using LUG3WebApi.Controllers;
using LUG3WebApi.DBManagerAll;
using LUG3WebApi.DBModels;
using LUG3WebApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class State
    {        
        private AddedFunctions fnc;
        List<PostulantBasic> baseList;

        public State(){
            fnc = new AddedFunctions();
            PostulantBasic poba = new PostulantBasic {
                Id = 1,
                Name = "Ejemplo",
                Lastname = "Ejemplo",
                Iteration = 1,
                IdState = 2
            };
            baseList = new List<PostulantBasic>(); 
            baseList.Add(poba);
        }
        [TestMethod]
        public void State1()
        {
            baseList[0].IdState = 1;
            List<BasicPostulant> toTest = fnc.addState(baseList);
            string trueValue = "Pending contact";

            Assert.AreEqual(trueValue, toTest[0].State);
        }
        [TestMethod]
        public void State2()
        {
            baseList[0].IdState = 2;
            List<BasicPostulant> toTest = fnc.addState(baseList);
            string trueValue = "Scheduled Assessment";

            Assert.AreEqual(trueValue, toTest[0].State);

        }
        [TestMethod]
        public void State3()
        {
            baseList[0].IdState = 3;
            List<BasicPostulant> toTest = fnc.addState(baseList);
            string trueValue = "FinishedAssessment";

            Assert.AreEqual(trueValue, toTest[0].State);

        }
        [TestMethod]
        public void State4()
        {
            baseList[0].IdState = 4;
            List<BasicPostulant> toTest = fnc.addState(baseList);
            string trueValue = "Pending Interview";

            Assert.AreEqual(trueValue, toTest[0].State);

        }
        [TestMethod]
        public void State5()
        {
            baseList[0].IdState = 5;
            List<BasicPostulant> toTest = fnc.addState(baseList);
            string trueValue = "Finished Interview";

            Assert.AreEqual(trueValue, toTest[0].State);

        }
        [TestMethod]
        public void State6()
        {
            baseList[0].IdState = 6;
            List<BasicPostulant> toTest = fnc.addState(baseList);
            string trueValue = "Approved";

            Assert.AreEqual(trueValue, toTest[0].State);

        }
        [TestMethod]
        public void State7()
        {
            baseList[0].IdState = 7;
            List<BasicPostulant> toTest = fnc.addState(baseList);
            string trueValue = "Rejected";

            Assert.AreEqual(trueValue, toTest[0].State);

        }
        [TestMethod]
        public void State8()
        {
            baseList[0].IdState = 8;
            List<BasicPostulant> toTest = fnc.addState(baseList);
            string trueValue = "Canceled";

            Assert.AreEqual(trueValue, toTest[0].State);

        }
    }
}
