using Bdd_Database.Services;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static Bdd_Database.Services.ServicoService;

namespace NFSe.Portal.TestesIntegracao.Declaracao.Configuracoes.Steps
{
    [Binding]
    public class ConfiguracaoDosServicosPrestadosOuTomadosSteps
    {
        [Given(@"a seguinte configuração de serviços")]
        public void DadoSeguinteAConfiguracaoDeServicos(Table table)
        {
            var servicoService = new ServicoService();
            var tabela = table.CreateDynamicSet();

            foreach(var linha in tabela)
            {
                var anexo = ConverterParaEnum(linha.Anexo.ToString());
                var servMunicipal = linha.ServicoMunicipal.ToString();
                var servFederal = linha.ServicoFederal.ToString();

                decimal? aliquota = null;

                try
                {
                    aliquota = Convert.ToDecimal(linha.Aliquota.ToString());
                }
                catch { }

                bool sujeitoFatorR = linha.SujeitoFatoR.ToString() == "Sim";
                bool retencaoTomador = linha.RetencaoTomador.ToString() == "Sim";
                bool devidoNoLocal = linha.DevidoNoLocal.ToString() == "Sim";

                servicoService.AlterarAnexo(anexo, servMunicipal);
                servicoService.AlterarSujeitoFatorR(sujeitoFatorR, servMunicipal);
                servicoService.AlterarRetencaoPeloTomador(retencaoTomador, servMunicipal);
                servicoService.AlterarRetencaoNoLocalDaPrestacao(devidoNoLocal, servMunicipal, servFederal);
                if (aliquota != null)
                    servicoService.AlterarAliquotaMunicipio(aliquota.Value, servMunicipal);
            }
        }

        private Anexo ConverterParaEnum(string anexo)
        {
            if (anexo.Trim().ToUpper() == "ANEXOIII") return Anexo.AnexoIII;
            if (anexo.Trim().ToUpper() == "ANEXOIV") return Anexo.AnexoIV;
            if (anexo.Trim().ToUpper() == "ANEXOV") return Anexo.AnexoV;

            throw new Exception("O Anexo informado não corresponde a um anexo conhecido pelo sistema.");
        }
    }
}
