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
    public class createFromForm
    {
        private AddedFunctions fnc;
        private Form baseForm;

        public createFromForm () {
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
        public void createPostulant()
        {
            Postulant trueValue = new Postulant 
            {
                Name = "Ejemplo",
                Lastname = "Ejemplo",
                Birthday = "1997-10-20",
                Dni = "40234567",
                Email = "ejemplo@ejemplo.com",
                PhoneHome = "43569789",
                PhoneMobile = "1134536789",
                GitHub = "MiGithub",
                LinkedIn = "MiLinkedIn",
                IdState = 1,
                Iteration = 1,
                Country = 1
            };

            Postulant toTest = fnc.createPostulant(baseForm);
            Assert.AreEqual(trueValue.Name, toTest.Name);
            Assert.AreEqual(trueValue.Lastname, toTest.Lastname);
            Assert.AreEqual(trueValue.Birthday, toTest.Birthday);
            Assert.AreEqual(trueValue.Dni, toTest.Dni);
            Assert.AreEqual(trueValue.Email, toTest.Email);
            Assert.AreEqual(trueValue.PhoneHome, toTest.PhoneHome);
            Assert.AreEqual(trueValue.PhoneMobile, toTest.PhoneMobile);
            Assert.AreEqual(trueValue.GitHub, toTest.GitHub);
            Assert.AreEqual(trueValue.LinkedIn, toTest.LinkedIn);
            Assert.AreEqual(trueValue.IdState, toTest.IdState);
            Assert.AreEqual(trueValue.Iteration, toTest.Iteration);
            Assert.AreEqual(trueValue.Country, toTest.Country);
        }

        [TestMethod]
        public void createStudies()
        {

            Studies trueValue = new Studies{
                IdStudy = 3,
                Institution = "Universidad de Buenos Aires",
                Career = "Ing Informatica",
                IdPostulant = 2,
                IdStudiesState = 1
            };
            
            Studies toTest = fnc.createStudies(baseForm, 2, 3, 1);
            Assert.AreEqual(trueValue.IdStudy, toTest.IdStudy);
            Assert.AreEqual(trueValue.Institution, toTest.Institution);
            Assert.AreEqual(trueValue.Career, toTest.Career);
            Assert.AreEqual(trueValue.IdPostulant, toTest.IdPostulant);
            Assert.AreEqual(trueValue.IdStudiesState, toTest.IdStudiesState);
        }

    }
}
