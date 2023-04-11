using AluraLeilaoOnline.Selenium.Fixtures;
using AluraLeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraLeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogin
    {
        private IWebDriver driver;

        public AoEfetuarLogin(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoCredenciasValidasDeveIrParaPaginaDeDashboard()
        {
            var loginPO = new LoginPO(driver);

            loginPO.Visitar();
            loginPO.PreencherFormulario("fulano@example.org", "123");
            loginPO.SubmeteFormulario();

            Assert.Contains("Dashboard", driver.Title);
        }

        [Fact]
        public void DadoCredenciasInvalidasDeveContinuarNaPaginaDeLogin()
        {
            var loginPO = new LoginPO(driver);

            loginPO.Visitar();
            loginPO.PreencherFormulario("fulano@example.org", "1233");
            loginPO.SubmeteFormulario();

            Assert.Contains("Login", driver.PageSource);
        }


    }
}
