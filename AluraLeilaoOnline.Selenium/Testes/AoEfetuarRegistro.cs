using AluraLeilaoOnline.Selenium.Fixtures;
using AluraLeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;

namespace AluraLeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver; 
        public AoEfetuarRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoInformacoesValidasDeveirParaPaginaDeAgradecimento()
        {
            //arrange - dado chrome aberto, pag inicial do sist. de leilões
            //dados de registros válidos informados
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            registroPO.PreencheFormulario("Ana Flávia", "anaflavia@emailteste.com", "123456", "123456");

            //act - efetuo o registro
            registroPO.SubmeteFormulario();

            //assert - devo ser direcionado para uma pagina de agradecimento
            Assert.Contains("Obrigado", driver.PageSource);
        }

        [Theory]
        [InlineData("ana", "flavia", "123", "123")]
        [InlineData("ana", "flavia@emailteste.com", "123", "12355")]
        public void DadoInformacoesInvalidasDeveContinuarNaHome(string nome, string email, string senha, string confirmaSenha)
        {
            //arrange - dado chrome aberto, pag inicial do sist. de leilões
            //dados de registros inválidos informados
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            registroPO.PreencheFormulario(nome, email, senha, confirmaSenha);

            //act - efetuo o registro
            registroPO.SubmeteFormulario();

            //assert - devo ser direcionado para uma pagina de agradecimento
            Assert.Contains("section-registro", driver.PageSource);
        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            //arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            //act
            registroPO.SubmeteFormulario();

            //assert span.msg-erro[data-valmsg-for="Nome"]
            IWebElement elemento = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Nome]"));
            Assert.Equal("The Nome field is required.", elemento.Text);
        }

        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            //arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            registroPO.PreencheFormulario(nome:"", email:"ana", senha:"", confirmaSenha: "");

            //act
            registroPO.SubmeteFormulario();

            //assert span.msg-erro[data-valmsg-for="Nome"]
            IWebElement elemento = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Email]"));
            Assert.Equal("Please enter a valid email address.", elemento.Text);
        }
    }
}
