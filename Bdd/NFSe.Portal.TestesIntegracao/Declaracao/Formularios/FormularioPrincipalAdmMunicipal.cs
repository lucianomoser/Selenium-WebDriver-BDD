using NFSe.Portal.TestesIntegracao.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NFSe.Portal.TestesIntegracao.Declaracao.Formularios
{
    class FormularioPrincipalAdmMunicipal
    {
        private IWebDriver Driver { get; set; }
        private WebDriverWait Aguarde { get; set; }

        public FormularioPrincipalAdmMunicipal(IWebDriver driver)
        {
            Driver = driver;
        }

        public FormularioConsultaDeclaracao MenuConsultarDeclaracaoServicoTomado()
        {
            Driver.FindElement(By.XPath("/html/body/div[2]/div[4]/div/ul/li[2]/a")).Click();            

            Thread.Sleep(500);

            var menuConsultarDeclaracaoServicoTomado = Driver.FindElement(By.XPath("/html/body/div[2]/div[4]/div/ul/li[2]/ul/li[6]/a/div"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("window.scrollTo(" + menuConsultarDeclaracaoServicoTomado.Location.X + "," + menuConsultarDeclaracaoServicoTomado.Location.Y + ")");
            executor.ExecuteScript("arguments[0].click();", menuConsultarDeclaracaoServicoTomado);

            WebDriverHelper.AguardeMsgAtualizacaoAutomatica(Driver, 25);
            Aguarde = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
            Aguarde.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("novaDeclaracao")));

            return new FormularioConsultaDeclaracao(Driver);
        }
    }
}
