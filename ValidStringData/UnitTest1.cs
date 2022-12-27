using System;
using CheckDataLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ValidStringData
{
    [TestClass]
    public class UnitTest1
    {
        VinCheck testedObject = new VinCheck();
        /// <summary>
        /// тест на наличие неправильных символов в вим-коде
        /// </summary>
        [TestMethod]
        public void CheckVin_WrongVIN_ThrowNewException()
        {
            //Arrange
            string entryString = "1234567890123456O";
            int entryYear = 2004;
            //Act
            //Assert          
            Assert.ThrowsException<Exception>(() => testedObject.CheckVin(entryString, entryYear));
        }

        /// <summary>
        /// тест на пустой вим код
        /// </summary>
        [TestMethod]
        public void CheckVin_EmptyVim_ThrowNewException()
        {
            //Arrange
            string entryString = "";
            int entryYear = 2004;
            //Act
            //Assert          
            Assert.ThrowsException<Exception>(() => testedObject.CheckVin(entryString, entryYear));
        }
        /// <summary>
        /// тест на короткий вим код
        /// </summary>
        [TestMethod]
        public void CheckVin_ShortVim_ThrowNewException()
        {
            //Arrange
            string entryString = "123";
            int entryYear = 2004;
            //Act
            //Assert          
            Assert.ThrowsException<Exception>(() => testedObject.CheckVin(entryString, entryYear));
        }
        /// <summary>
        /// тест на длинный вим код
        /// </summary>
        [TestMethod]
        public void CheckVin_LongVim_ThrowNewException()
        {
            //Arrange
            string entryString = "12345678901234567890";
            int entryYear = 2004;
            //Act
            //Assert          
            Assert.ThrowsException<Exception>(() => testedObject.CheckVin(entryString, entryYear));
        }

        /// <summary>
        /// тест на маленький год 
        /// </summary>
        [TestMethod]
        public void CheckVin_SmallYear_ThrowNewException()
        {
            //Arrange
            string entryString = "1234567890123456E";
            int entryYear = 0;
            //Act
            //Assert          
            Assert.ThrowsException<Exception>(() => testedObject.CheckVin(entryString, entryYear));
        }

        /// <summary>
        /// тест на большой год 
        /// </summary>
        [TestMethod]
        public void CheckVin_BigYear_ThrowNewException()
        {
            //Arrange
            string entryString = "1234567890123456E";
            int entryYear = 2023;
            //Act
            //Assert          
            Assert.ThrowsException<Exception>(() => testedObject.CheckVin(entryString, entryYear));
        }

        /// <summary>
        /// тест на правильный вим
        /// </summary>
        [TestMethod]
        public void CheckVin_RightVIM_ReturnTrue()
        {
            //Arrange
            string entryString = "JHMCM56557C404453";
            int entryYear = 1982;
            //Act
            //Assert          
            Assert.IsTrue(testedObject.CheckVin(entryString, entryYear));
        }

        /// <summary>
        /// тест на неправильный вим
        /// </summary>
        [TestMethod]
        public void CheckVin_NotRightVIM_ReturnFalse()
        {
            //Arrange
            string entryString = "1234556557C404453";
            int entryYear = 2000;
            //Act

            //Assert          
            Assert.IsFalse(testedObject.CheckVin(entryString, entryYear));
        }

        /// <summary>
        /// тест на правильный год в виме
        /// </summary>
        [TestMethod]
        public void CorrectYear_RightYear_ReturnTrue()
        {
            //Arrange
            string entryString = "JHMCM56557C404453";
            int entryYear = 1982;
            //Act
            //Assert          
            Assert.IsTrue(testedObject.CorrectYear(entryString, entryYear));
        }

        /// <summary>
        /// тест на неправильный год в виме
        /// </summary>
        [TestMethod]
        public void CorrectYear_NotRightYear_ReturnFalse()
        {
            //Arrange
            string entryString = "JHMCM56557C404453";
            int entryYear = 2000;
            //Act

            //Assert          
            Assert.IsFalse(testedObject.CorrectYear(entryString, entryYear));
        }
    }
}
