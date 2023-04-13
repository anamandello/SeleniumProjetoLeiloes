using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AluraLeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver driver;
        private By byLogoutLink;
        private By byMeuPerfilLink;
        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        private By byBotaoPesquisar;

        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
            byLogoutLink = By.Id("logout");
            byMeuPerfilLink = By.Id("meu-perfil");
            bySelectCategorias = By.ClassName("select-wrapper");
        }

        public void PesquisarLeiloes(
            List<string> categorias)
        {
            var selectWrapper = driver.FindElement(bySelectCategorias);
            selectWrapper.Click();

            var opcoes = selectWrapper.FindElements(By.CssSelector("li>span")).ToList();

            opcoes.ForEach(o =>
            {
                o.Click();
            });

            categorias.ForEach(categ =>
            {
                opcoes.Where(o => o.Text.Contains(categ))
                .ToList()
                .ForEach(o =>
                {
                    o.Click();
                });
            });

            selectWrapper.FindElement(By.TagName("li"))
                .SendKeys(Keys.Tab);

            Thread.Sleep(8000);
          
        }

        public void EfetuarLogout()
        {
            var linkMeuPerfil = driver.FindElement(byMeuPerfilLink);
            var linkLogout = driver.FindElement(byLogoutLink);

            IAction acaoLogout = new Actions(driver)
                //mover para o elemento meu-perfil
                .MoveToElement(linkMeuPerfil)
                //mover para o link de logout
                .MoveToElement(linkLogout)
                //clicar no link de logout
                .Click()
                .Build();

            acaoLogout.Perform();

        }
    }
}
