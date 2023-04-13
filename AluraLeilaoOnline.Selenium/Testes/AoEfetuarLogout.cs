using AluraLeilaoOnline.Selenium.Fixtures;
using AluraLeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;

namespace AluraLeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogout
    {
        private IWebDriver driver;

        public AoEfetuarLogout(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginValidaDeveIrParaHomeNaoLogada()
        {
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencherFormulario("fulano@example.org", "123");
            loginPO.SubmeteFormulario();

            //act - efetuar Logout
            var dashboardPO = new DashboardInteressadaPO(driver);
            dashboardPO.EfetuarLogout();

            //assert
            Assert.Contains("Próximos Leilões", driver.PageSource);

        }
    }
}
