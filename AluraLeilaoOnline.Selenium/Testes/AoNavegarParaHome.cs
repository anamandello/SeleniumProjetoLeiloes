using AluraLeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;

namespace AluraLeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaHome
    {
        private IWebDriver driver;
        public AoNavegarParaHome(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            driver.Navigate().GoToUrl("http://www.localhost:5000");

            Assert.Contains("Leilões Online", driver.Title);
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            driver.Navigate().GoToUrl("http://www.localhost:5000");

            Assert.Contains("Próximos Leilões", driver.PageSource);
        }
    }
}