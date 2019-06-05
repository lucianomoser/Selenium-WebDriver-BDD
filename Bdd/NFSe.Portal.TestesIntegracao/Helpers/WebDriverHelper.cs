using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace NFSe.Portal.TestesIntegracao.Helpers
{
    class WebDriverHelper
    {
        public static void AguardeValorElemento(IWebElement elemento, int segundos)
        {
            for (int i = 0; i < segundos; i++)
            {
                if (!string.IsNullOrEmpty(elemento.GetAttribute("value")))
                {
                    break;
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
        }

        public static void AguardeMsgAtualizacaoAutomatica(IWebDriver driver, int segundos)
        {

            Thread.Sleep(4000);
            WebDriverWait aguardeMsg = new WebDriverWait(driver, TimeSpan.FromSeconds(segundos));          
            aguardeMsg.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='Modal-Loading-Message']")));
            aguardeMsg.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.Id("msgAtualizacaoAutomatica")));
            aguardeMsg.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@id='Janela-Modal']")));
            
        }

    }
}
