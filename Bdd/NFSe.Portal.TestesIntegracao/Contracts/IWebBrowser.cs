using OpenQA.Selenium;

namespace NFSe.Portal.TestesIntegracao.Contracts
{
    public interface IWebBrowser
    {
        IWebDriver Current { get; }
    }
}