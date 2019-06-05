using FluentAssertions;
using NFSe.Portal.TestesIntegracao.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using NFSe.Portal.TestesIntegracao.Helpers;

namespace NFSe.Portal.TestesIntegracao.Navegacao.Steps
{
    [Binding]
    public class DeclaracaoNotaServicoSteps
    {
        WebDriverWait aguardeProcesso;

        IWebDriver driver;

        public DeclaracaoNotaServicoSteps(IWebBrowser driver)
        {
            this.driver = driver.Current;
        }

        [Given(@"forneça os seguintes dados para formulário de declaracao de nota")]
        public void DadoFornecaOsSeguintesDadosParaFormularioDeDeclaracaoDeNota(Table table)
        {

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            var tabela = table.CreateDynamicSet().First();
            var chkTomado = driver.FindElement(By.Id("DeclaracaoNota_ServicoTomado"));
            var emissao = driver.FindElement(By.Id("DeclaracaoNota_DataPrestacao"));
            var cbExigivel = driver.FindElement(By.Id("DeclaracaoNota_ExigibilidadeISS_listbox"));
            var txtNumero = driver.FindElement(By.Id("DeclaracaoNota_Numero"));
            var documentoTomadorPrestador = driver.FindElement(By.Id("DeclaracaoNota_DocumentoTomadorPrestador"));
            var nomeTomadorPrestador = driver.FindElement(By.Id("DeclaracaoNota_NomeTomadorPrestador"));
            var cbServico = driver.FindElement(By.Id("DeclaracaoNota_Servico_ServicoMunicipal_listbox"));
            var txtServicoFederal = driver.FindElement(By.Id("DeclaracaoNota_Servico_ServicoFederal"));
            var txtValorServico = driver.FindElement(By.Id("DeclaracaoNota_Servico_ValorServico"));
            var chkRetido = driver.FindElement(By.Id("checkboxRetido"));
            var txtBaseCalculo = driver.FindElement(By.Id("DeclaracaoNota_Servico_BaseCalculo"));
            var txtAliquota = driver.FindElement(By.Id("DeclaracaoNota_Servico_Aliquota"));
            var cbMunicipio = driver.FindElement(By.Id("DeclaracaoNota_Municipio_listbox"));
            var txtValorISS = driver.FindElement(By.Id("DeclaracaoNota_Servico_ValorISS"));


            if (tabela.Modalidade == "Tomado")
                executor.ExecuteScript("window.scrollTo(" + chkTomado.Location.X + ", " + chkTomado.Location.Y + ")");
            executor.ExecuteScript("arguments[0].click();", chkTomado);            

            emissao.SendKeys(tabela.Emissao);
            emissao.SendKeys(Keys.Tab);



            var cbExigivelElements = cbExigivel.FindElements(By.ClassName("k-item"));

            aguardeProcesso = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            aguardeProcesso.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("DeclaracaoNota_ExigibilidadeISS_listbox")));
            aguardeProcesso = null;
            foreach (var item in cbExigivelElements)
            {
                try
                {
                    executor.ExecuteScript("if (arguments[0].innerHTML=='Exigível') { arguments[0].click(); }", item);
                }
                catch { }
            }


            txtNumero.SendKeys(tabela.Numero);
            txtNumero.SendKeys(Keys.Tab);

            aguardeProcesso = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            aguardeProcesso.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("DeclaracaoNota_SerieCadastrada_listbox")));
            aguardeProcesso = null;

            if (tabela.Modalidade != "Tomado")
            {
                var cbSerie = driver.FindElement(By.Id("DeclaracaoNota_SerieCadastrada_listbox"));
                var cbSerieElements = cbSerie.FindElements(By.ClassName("k-item"));

                foreach (var item in cbSerieElements)
                {
                    try
                    {
                        executor.ExecuteScript("if (arguments[0].innerHTML==" + tabela.Serie + ") { arguments[0].click(); }", item);
                    }
                    catch { }
                }
            }
            else
            {
                var txtSerie = driver.FindElement(By.Id("DeclaracaoNota_Serie"));
                txtSerie.SendKeys(tabela.Serie);
            }

            aguardeProcesso = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            aguardeProcesso.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("DeclaracaoNota_Municipio_listbox")));
            aguardeProcesso = null;

            if (tabela.MunicipioPrestacao != "Cerejeiras")
            {

                var cbMunicipioElements = cbMunicipio.FindElements(By.ClassName("k-item"));

                foreach (var item in cbMunicipioElements)
                {
                    try
                    {
                        executor.ExecuteScript("if (arguments[0].innerHTML==" + tabela.MunicipioPrestacao + ") { arguments[0].click(); }", item);
                    }
                    catch { }
                }
            }

            documentoTomadorPrestador.SendKeys(tabela.TomadorPrestador.Replace("'", ""));            
            documentoTomadorPrestador.SendKeys(Keys.Tab);

            WebDriverHelper.AguardeValorElemento(nomeTomadorPrestador, 15);

            txtServicoFederal.SendKeys(tabela.ServicoFederal.ToString());
            txtServicoFederal.SendKeys(Keys.Tab);

            Thread.Sleep(2000);
            var cbServicoElements = cbServico.FindElements(By.ClassName("k-item"));

            foreach (var item in cbServicoElements)
            {
                try
                {
                    executor.ExecuteScript("if (arguments[0].innerHTML==" + tabela.ServicoMunicipal + ") { arguments[0].click(); }", item);
                }
                catch { }
            }

            txtValorServico.SendKeys(tabela.Valor.ToString());            
            if (tabela.Retido == "Sim" && chkRetido.Enabled && chkRetido.Selected == false)
            {                
                executor.ExecuteScript("window.scrollTo(" + chkRetido.Location.X + ", " + chkRetido.Location.Y + ")");                
                
                while (chkRetido.Selected == false)
                {
                    executor.ExecuteScript("arguments[0].click(); ", chkRetido);
                    Thread.Sleep(500);                 
                }
                executor.ExecuteScript("window.scrollTo(" + txtBaseCalculo.Location.X + ", " + txtBaseCalculo.Location.Y + ")");
                executor.ExecuteScript("arguments[0].click(); ", txtBaseCalculo);                
            }
            else
            {
                txtValorServico.SendKeys(Keys.Tab);
            }
            aguardeProcesso = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            aguardeProcesso.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("DeclaracaoNota_Servico_BaseCalculo")));
            

            WebDriverHelper.AguardeValorElemento(txtBaseCalculo, 10);
            txtBaseCalculo.SendKeys(Keys.Tab);

            WebDriverHelper.AguardeValorElemento(txtAliquota, 10);

            WebDriverHelper.AguardeValorElemento(txtValorISS, 10);
        }



        [Then(@"o status Habilitado para o campo Alíquota deverá ser ""(.*)""")]
        public void EntaoOStatusHabilitadoParaOCampoAliquotaDeveraSer(bool value)
        {

            var txtAliquota = driver.FindElement(By.Id("DeclaracaoNota_Servico_Aliquota"));

            bool habilitada = txtAliquota.Enabled;            

            try
            {
                habilitada.Should().Be(value);
            }
            catch (SpecFlowException)
            {
                ScreenShot.Foto(driver);
            }          
            
        }



        [Then(@"o valor do campo Alíquota deverá ter o tamanho total igual a (.*)")]
        public void EntaoOValorDoCampoAliquotaPossuiOTamanhoIgualA(decimal valor)
        {

            var txtAliquota = driver.FindElement(By.Id("DeclaracaoNota_Servico_Aliquota"));

            Thread.Sleep(1000);

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            var txtValor = executor.ExecuteScript("return arguments[0].value", txtAliquota);

            var valorResult = Convert.ToDecimal(txtValor.ToString().Length);

            valorResult.Should().Be(valor);
        }

        [Then(@"o valor do campo Alíquota deverá ter a quantidade de casas decimais igual a (.*)")]
        public void EntaoOValorDoCampoAliquotaPossuiQuantidadeDeCasasDecimaisIgualA(decimal valor)
        {

            var txtAliquota = driver.FindElement(By.Id("DeclaracaoNota_Servico_Aliquota"));

            Thread.Sleep(1000);

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            var txtValor = executor.ExecuteScript("return arguments[0].value", txtAliquota);

            decimal valorResult = Convert.ToDecimal(txtValor.ToString().Substring(2, 10).Length);
            valorResult.Should().Be(valor);
        }

        [Then(@"o valor do campo Alíquota deverá ter a quantidade de casas decimais maior que (.*)")]
        public void EntaoOValorDoCampoAliquotaPossuiQuantidadeDeCasasDecimaisMaiorQue(decimal valor)
        {

            var txtAliquota = driver.FindElement(By.Id("DeclaracaoNota_Servico_Aliquota"));

            Thread.Sleep(1000);

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            var txtValor = executor.ExecuteScript("return arguments[0].value", txtAliquota);
            decimal valorResult = Convert.ToDecimal(txtValor.ToString().Substring(2, 10).Length);
            valorResult.Should().BeGreaterThan(valor);
        }


        [Then(@"o valor do campo Alíquota deverá ter a quantidade de casas decimais menor que (.*)")]
        public void EntaoOValorDoCampoAliquotaPossuiQuantidadeDeCasasDecimaisMenorQue(decimal valor)
        {

            var txtAliquota = driver.FindElement(By.Id("DeclaracaoNota_Servico_Aliquota"));

            Thread.Sleep(1000);

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            var txtValor = executor.ExecuteScript("return arguments[0].value", txtAliquota);

            decimal valorResult = Convert.ToDecimal(txtValor.ToString().Substring(2, 10).Length);
            valorResult.Should().BeLessThan(valor);
        }


        [Then(@"o valor do campo Alíquota deverá ser igual a (.*)")]
        public void EntaoOValorDoCampoAliquotaDeveraSerIgualA(decimal valor)
        {
            var txtAliquota = driver.FindElement(By.Id("DeclaracaoNota_Servico_Aliquota"));

            Thread.Sleep(1000);

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            var txtValor = executor.ExecuteScript("return arguments[0].value", txtAliquota);        

            decimal valorResult = Convert.ToDecimal(txtValor.ToString());
            valorResult.Should().Be(valor);           
        }


        [Then(@"o valor do campo Alíquota deverá ser maior que (.*)")]
        public void EntaoOValorDoCampoAliquotaDeveraSerMaiorQue(decimal valor)
        {
            var txtAliquota = driver.FindElement(By.Id("DeclaracaoNota_Servico_Aliquota"));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            var txtValor = executor.ExecuteScript("return arguments[0].value", txtAliquota);

            decimal valorResult = Convert.ToDecimal(txtValor.ToString());            
            valorResult.Should().BeGreaterThan(valor);          
        }


        [Then(@"o valor do campo Alíquota deverá ser menor que (.*)")]
        public void EntaoOValorDoCampoAliquotaDeveraSerMenorQue(decimal valor)
        {
            var txtAliquota = driver.FindElement(By.Id("DeclaracaoNota_Servico_Aliquota"));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            var txtValor = executor.ExecuteScript("return arguments[0].value", txtAliquota);

            decimal valorResult = Convert.ToDecimal(txtValor.ToString());                                  
            valorResult.Should().BeLessThan(valor);                       
        }

        [Then(@"o valor do campo Alíquota deverá ser maior ou igual a (.*)")]
        public void EntaoOValorDoCampoAliquotaDeveraSerMaiorOuIgualA(decimal valor)
        {
            var txtAliquota = driver.FindElement(By.Id("DeclaracaoNota_Servico_Aliquota"));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            var txtValor = executor.ExecuteScript("return arguments[0].value", txtAliquota);

            decimal valorResult = Convert.ToDecimal(txtValor.ToString());       
            valorResult.Should().BeGreaterOrEqualTo(valor);          
        }


        [Then(@"o valor do campo Alíquota deverá ser menor ou igual a (.*)")]
        public void EntaoOValorDoCampoAliquotaDeveraSerMenorOuIgualA(decimal valor)
        {
            var txtAliquota = driver.FindElement(By.Id("DeclaracaoNota_Servico_Aliquota"));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            var txtValor = executor.ExecuteScript("return arguments[0].value", txtAliquota);

            decimal valorResult = Convert.ToDecimal(txtValor.ToString());                     
            valorResult.Should().BeLessOrEqualTo(valor);     
        }
    }
}
