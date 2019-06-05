using NFSe.Portal.TestesIntegracao.Contracts;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace NFSe.Portal.TestesIntegracao.Helpers
{
    public class ScreenShot
    {

        private static string path = @"C:\inetpub\imagens\";


        public static void Foto(IWebDriver driver)
        {

            ITakesScreenshot camera = driver as ITakesScreenshot;

            Screenshot foto = camera.GetScreenshot();

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                foto.SaveAsFile(path + ObterTituloDoCenario() + DataHoraArquivo() + ".Png", ScreenshotImageFormat.Png);
            }
            else
            {
                foto.SaveAsFile(path + ObterTituloDoCenario() + DataHoraArquivo() + ".Png", ScreenshotImageFormat.Png);                
            }
            Thread.Sleep(500);


        }

        private static string DataHoraArquivo()
        {
            return DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        }


        private static string ObterTituloDoCenario()
        {
            return ScenarioContext.Current.ScenarioInfo.Title; 
        }



    }
}


