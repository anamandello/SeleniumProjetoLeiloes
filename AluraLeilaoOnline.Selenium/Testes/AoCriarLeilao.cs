using AluraLeilaoOnline.Selenium.Fixtures;
using AluraLeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;

namespace AluraLeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoCriarLeilao
    {
        IWebDriver driver;
        public AoCriarLeilao(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdminEInfoValidasDeveCadastrarLeilao()
        {
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencherFormulario("admin@example.org", "123");
            loginPO.SubmeteFormulario();

            var novoLeilaoPO = new NovoLeilaoPO(driver);
            novoLeilaoPO.Visitar();
            novoLeilaoPO.PreencheFormulario(
                "Leilão de Coleção 1",
                "Nullam aliquet",
                "Item de Colecionador",
                4000,
                "C:\\Users\\Ana\\Pictures\\colecao1.jpg",
                DateTime.Now.AddDays(20),
                DateTime.Now.AddDays(40)
                );

            novoLeilaoPO.SubmeteFormulario();

            Assert.Contains("Leilões cadastrados no sistema", driver.PageSource);
        }
    }
}
