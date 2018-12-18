using LUG3WebApi.Added;
using LUG3WebApi.Authentication.Model;
using LUG3WebApi.Controllers;
using LUG3WebApi.DBManagerAll;
using LUG3WebApi.DBModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class MimeTypes
    {
        private AddedFunctions fnc;

        public MimeTypes () {
            fnc = new AddedFunctions();
        }
        [TestMethod]
        public void getTxt()
        {
           string toTest = fnc.getMimeTypes("txt");
            string trueValue = "text/plain";
            Assert.AreEqual(trueValue, toTest);
        }
        [TestMethod]
        public void getPdf()
        {
           string toTest = fnc.getMimeTypes("txt");
            string trueValue = "text/plain";
            Assert.AreEqual(trueValue, toTest);
        }
        [TestMethod]
        public void getDoc()
        {
           string toTest = fnc.getMimeTypes("doc");
            string trueValue = "application/vnd.ms-word";
            Assert.AreEqual(trueValue, toTest);
        }
        [TestMethod]
        public void getDocx()
        {
           string toTest = fnc.getMimeTypes("docx");
            string trueValue = "application/vnd.ms-word";
            Assert.AreEqual(trueValue, toTest);
        }
        [TestMethod]
        public void getXls()
        {
           string toTest = fnc.getMimeTypes("xls");
            string trueValue = "application/vnd.ms-excel";
            Assert.AreEqual(trueValue, toTest);
        }
        [TestMethod]
        public void getXlsx()
        {
           string toTest = fnc.getMimeTypes("xlsx");
            string trueValue = "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet";
            Assert.AreEqual(trueValue, toTest);
        }
        [TestMethod]
        public void getPng()
        {
           string toTest = fnc.getMimeTypes("png");
            string trueValue = "image/png";
            Assert.AreEqual(trueValue, toTest);
        }
        [TestMethod]
        public void getJpg()
        {
           string toTest = fnc.getMimeTypes("jpg");
            string trueValue = "image/jpeg";
            Assert.AreEqual(trueValue, toTest);
        }
        [TestMethod]
        public void getJpeg()
        {
           string toTest = fnc.getMimeTypes("jpeg");
            string trueValue = "image/jpeg";
            Assert.AreEqual(trueValue, toTest);
        }
        [TestMethod]
        public void getGif()
        {
           string toTest = fnc.getMimeTypes("gif");
            string trueValue = "image/gif";
            Assert.AreEqual(trueValue, toTest);
        }
        [TestMethod]
        public void getCsv()
        {
           string toTest = fnc.getMimeTypes("csv");
            string trueValue = "text/csv";
            Assert.AreEqual(trueValue, toTest);
        }

    }
}
