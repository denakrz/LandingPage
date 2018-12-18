using LUG3WebApi.Added;
using LUG3WebApi.Authentication.Model;
using LUG3WebApi.Controllers;
using LUG3WebApi.DBManagerAll;
using LUG3WebApi.DBModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class validateIdwoutForm
    {
        private AddedFunctions fnc;
        private Studiesget baseStudies;

        public validateIdwoutForm(){
            fnc = new AddedFunctions();
            baseStudies = new Studiesget(){
                Study = "secondary",
                Institution = "Universidad de Buenos Aires",
                Career = "Ingenieria",
                IdPostulant = 2,
                Year = 3,
                Study1 = "abandoned"
            };
        }
        [TestMethod]
        public void IdStudySecondary()
        {
            baseStudies.Study = "secondary";
            int trueValue = 1;
            int toTest = fnc.validateIdStudyget(baseStudies);
            Assert.AreEqual(trueValue, toTest);
            
        }
        [TestMethod]
        public void IdStudyTertiary()
        {
            baseStudies.Study = "tertiary";
            int trueValue = 2;
            int toTest = fnc.validateIdStudyget(baseStudies);
            Assert.AreEqual(trueValue, toTest);
            
        }
        [TestMethod]
        public void IdStudyUniversitary()
        {
            baseStudies.Study = "universitary";
            int trueValue = 3;
            int toTest = fnc.validateIdStudyget(baseStudies);
            Assert.AreEqual(trueValue, toTest);
            
        }
        [TestMethod]
        public void IdStudyOngoing()
        {
            baseStudies.Study1 = "ongoing";
            int trueValue = 1;
            int toTest = fnc.validateIdStudyStateget(baseStudies);
            Assert.AreEqual(trueValue, toTest);
        }
        [TestMethod]
        public void IdStudyFinished()
        {
            baseStudies.Study1 = "finished";
            int trueValue = 2;
            int toTest = fnc.validateIdStudyStateget(baseStudies);
            Assert.AreEqual(trueValue, toTest);
        }

        [TestMethod]
        public void IdStudyAbandoned()
        {
            baseStudies.Study1 = "abandoned";
            int trueValue = 3;
            int toTest = fnc.validateIdStudyStateget(baseStudies);
            Assert.AreEqual(trueValue, toTest);   
        }
    }
}
