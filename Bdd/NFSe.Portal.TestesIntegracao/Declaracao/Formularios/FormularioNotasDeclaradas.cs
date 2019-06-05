using System;
using NFSe.Portal.TestesIntegracao.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NFSe.Portal.TestesIntegracao.Declaracao.Formularios
{
    public class FormularioNotasDeclaradas
    {
        private IWebDriver Driver { get; set; }
        private WebDriverWait Aguarde { get; set; }

        public FormularioNotasDeclaradas(IWebDriver driver)
        {
            Driver = driver;
        }


        public FormularioConsultaDeclaracao GravarNotasFiscaisESair()
        {
            var botaoGravarFechar = Driver.FindElement(By.Id("salvarFechar"));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;

            executor.ExecuteScript("window.scrollTo(" + botaoGravarFechar.Location.X + ", " + botaoGravarFechar.Location.Y + ")");
            executor.ExecuteScript("arguments[0].click();", botaoGravarFechar);

            WebDriverHelper.AguardeMsgAtualizacaoAutomatica(Driver, 25);

            return new FormularioConsultaDeclaracao(Driver);
        }

        
    }
}