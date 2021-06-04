using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using FluentAssertions;

namespace UnitTestProject1
{

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ChromeOptions full = new ChromeOptions();
            full.AddArgument("start-maximized");
            ChromeDriver driver = new ChromeDriver(full);
            driver.Url = "https://demoqa.com/automation-practice-form";
            string nombre = "Fabio";
            string apellido = "vasquez";
            string direcciones = "Hola Mundo";
            driver.FindElement(By.Id("firstName")).SendKeys(nombre);
            driver.FindElement(By.Id("lastName")).SendKeys(apellido);

            driver.FindElement(By.Id("userEmail")).SendKeys("hconha@celsia.com");  
            //driver.FindElement(By.Id("gender-radio-1")).Click();
            driver.FindElement(By.XPath("//label[text()='Male']")).Click();

            driver.FindElement(By.Id("userNumber")).SendKeys("3212121213");  

            driver.FindElement(By.Id("dateOfBirthInput")).SendKeys("01/01/1998");
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//label[text()='Music']")).Click();
            driver.FindElement(By.XPath("//label[text()='Reading']")).Click();

            driver.FindElement(By.Id("currentAddress")).SendKeys(direcciones);
            
            driver.FindElement(By.XPath("//div[text()='Select State']")).Click();
            driver.FindElement(By.XPath("//div[text()='Haryana']")).Click();

            driver.FindElement(By.XPath("//div[text()='Select City']")).Click();
            driver.FindElement(By.XPath("//div[text()='Karnal']")).Click();


            driver.FindElement(By.Id("submit")).Click();

            bool Bandera = driver.FindElement(By.Id("example-modal-sizes-title-lg")).Displayed;
            Bandera.Should().BeTrue();

            string texto = driver.FindElement(By.XPath("//table/tbody/tr[1]/td[2]")).Text;
            texto.Should().Equals(nombre + " " + apellido);

            string direccionesMuestra = driver.FindElement(By.XPath("//table/tbody/tr[9]/td[2]")).Text;
            direccionesMuestra.Should().Equals(direcciones);
            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}
