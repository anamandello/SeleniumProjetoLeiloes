using AluraLeilaoOnline.Selenium.Fixtures;
using AluraLeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;

namespace AluraLeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoFiltrarLeiloes
    {
        IWebDriver driver;

        public AoFiltrarLeiloes(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginInteressadaDeveMostrarPainelResultado()
        {
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencherFormulario("fulano@example.org", "123");
            loginPO.SubmeteFormulario();

            var dashboardInteressadaPO = new DashboardInteressadaPO(driver);

            //act
            dashboardInteressadaPO.PesquisarLeiloes(new List<string>
            {
                "Arte",
                "Coleções"
            });

            //assert

        }
    }
}
