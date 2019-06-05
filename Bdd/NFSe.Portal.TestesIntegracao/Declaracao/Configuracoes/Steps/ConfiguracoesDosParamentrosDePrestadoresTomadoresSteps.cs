using Bdd_Database.Contracts;
using Bdd_Database.Services;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace NFSe.Portal.TestesIntegracao.Declaracao.Configuracoes.Steps
{
    [Binding]
    public class ConfiguracoesDosParamentrosDePrestadoresTomadoresSteps
    {
        [Given(@"que a data de abertura da empresa de CNPJ ""(.*)"" seja ""(.*)""")]
        public void DadoQueADataDeAberturaDaEmpresaDeCNPJSeja(string cnpj, string dataAbertura)
        {
            var empresaService = new EmpresaService();
            var data = Convert.ToDateTime(dataAbertura);
            empresaService.AlterarDataAbertura(data, cnpj);
        }

        [Given(@"que a empresa de CNPJ ""(.*)"" é optante do Simples Nacional")]
        public void DadoQueOCNPJEOptanteDoSimplesNacional(string cnpj)
        {
            var empresaService = new EmpresaService();
            empresaService.DefinirComoOptanteSimplesNacional(cnpj);
        }

        [Given(@"que a empresa de CNPJ ""(.*)"" é do tipo Homologado")]
        public void DadoQueAEmpresaDeCNPJEDoTipoHomologado(string cnpj)
        {
            var empresaService = new EmpresaService();
            empresaService.DefinirComoHomologado(cnpj);
        }


        [Given(@"que a empresa de CNPJ ""(.*)"" possui os seguintes faturamentos")]
        public void DadoQueOCNPJPossuiOsSeguintesFaturamentos(string cnpj, Table table)
        {
            var tabela = table.CreateDynamicSet();

            var identService = new IdentidadeJuridicaService();
            var faturamentoService = new FaturamentoService();

            var identidadeJuridica = identService.ObterID(cnpj);

            faturamentoService.ProcessarFaturamento(tabela, identidadeJuridica);
        }

        [Given(@"que a empresa de CNPJ ""(.*)"" é estabelecido")]
        public void DadoQueOCNPJEEstabelecido(string cnpj)
        {
            var empresaService = new EmpresaService();
            empresaService.DefinirComoEstabelecido(cnpj);
        }

        [Given(@"que a empresa de CNPJ ""(.*)"" não é estabelecido")]
        public void DadoQueOCNPJNaoEEstabelecido(string cnpj)
        {
            var empresaService = new EmpresaService();
            empresaService.DefinirComoNaoEstabelecido(cnpj);
        }   

        [Given(@"que a empresa não estabelecida de CNPJ ""(.*)"" está cadastrada como Prestadora da empresa de CNPJ ""(.*)""")]
        public void DadoQueAEmpresaNaoEstabelecidaDeCNPJEstaCadastradaComoPrestadoraDaEmpresaDeCNPJ(string cnpjPrestador, string cnpjTomador)
        {
            var empresaService = new EmpresaService();
            empresaService.DefinirEmpresaCadastradaComoPrestadora(cnpjPrestador, cnpjTomador);
        }

        [Given(@"que a empresa de CNPJ ""(.*)"" é optante do Simples Nacional e empresa não é estabelecido")]
        public void DadoQueOCNPJEOptanteDoSimplesNacionaleEmpresaNaoEstabelecido(string cnpj)
        {
            var empresaService = new EmpresaService();
            empresaService.DefinirComoOptanteSimplesNacionalEmpresaNaoEstabelecido(cnpj);
        }


    }
}
