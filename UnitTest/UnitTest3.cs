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
    public class validateIdwForm
    {
        private AddedFunctions fnc;
        private Form baseForm;
        public validateIdwForm(){
            fnc = new AddedFunctions();
            baseForm = new Form{
                Name = "Ejemplo",
                Lastname = "Ejemplo",
                Birth = "1997-10-20",
                Dni = "40234567",
                Email = "ejemplo@ejemplo.com",
                PhoneHome = "43569789",
                PhoneMobile = "1134536789",
                GitHub = "MiGithub",
                LinkedIn = "MiLinkedIn",
                Study = "universitary",
                Institution = "Universidad de Buenos Aires",
                Career = "Ing Informatica",
                Study1 = "ongoing",
                English = "yes",
                SpeakEnglish = "intermediate",
                WrittenEnglish = "intermediate",
                ListenEnglish = "intermediate",
                Technologies = "yes",
                InfoProg = "Amigos",
                Other = "No",
                intProg = "Bastante",
                ConverTheme = "yes",
                Cod = "yes",
                Tools = "PC",
                Pc = "Yes",
                Experience = "Have"
            };
        }

        [TestMethod]
        public void IdStudySecondary()
        {
            baseForm.Study = "secondary";
            int trueValue = 1;
            int toTest = fnc.validateIdStudy(baseForm);
            Assert.AreEqual(trueValue, toTest);
            
        }
        [TestMethod]
        public void IdStudyTertiary()
        {
            baseForm.Study = "tertiary";
            int trueValue = 2;
            int toTest = fnc.validateIdStudy(baseForm);
            Assert.AreEqual(trueValue, toTest);
            
        }
        [TestMethod]
        public void IdStudyUniversitary()
        {
            baseForm.Study = "universitary";
            int trueValue = 3;
            int toTest = fnc.validateIdStudy(baseForm);
            Assert.AreEqual(trueValue, toTest);
            
        }
        [TestMethod]
        public void IdStudyOngoing()
        {
            baseForm.Study1 = "ongoing";
            int trueValue = 1;
            int toTest = fnc.validateIdStudyState(baseForm);
            Assert.AreEqual(trueValue, toTest);
        }
        [TestMethod]
        public void IdStudyFinished()
        {
            baseForm.Study1 = "finished";
            int trueValue = 2;
            int toTest = fnc.validateIdStudyState(baseForm);
            Assert.AreEqual(trueValue, toTest);
        }

        [TestMethod]
        public void IdStudyAbandoned()
        {
            baseForm.Study1 = "abandoned";
            int trueValue = 3;
            int toTest = fnc.validateIdStudyState(baseForm);
            Assert.AreEqual(trueValue, toTest);   
        }
    }
}
