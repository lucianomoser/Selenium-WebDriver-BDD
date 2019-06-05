using Bdd_Database.Contracts;
using Bdd_Database.Helpers;

namespace Bdd_Database.Services
{
    public class ProcuracaoService
    {
        
        public string ObterChaveProcuracaoServicosExternos(string cpf, string cnpj)
        {
            var pessoaService = new PessoaService();
            var empresaService = new EmpresaService();
            var identidadeJuridicaService = new IdentidadeJuridicaService();

            var pessoaId = pessoaService.ObterPessoaId(cpf);
            var empresaId = empresaService.ObterEmpresaId(cnpj);
            var pessoaEmpresaId = empresaService.ObterPessoaEmpresaId(pessoaId, empresaId);

            var identiadeJuridicaId = identidadeJuridicaService.ObterID(cnpj);

            var dataBase = new DatabaseConnection();
            dataBase.Open();
            var cmd = dataBase.Command;

            var sql = " SELECT PKID FROM PROCURACAO_SERVICOS_EXTERNOS " +
                      " WHERE FK_PESSOA_EMPRESA_PESSOA_EMPRESA = " + pessoaEmpresaId +
                      "     AND FK_IDENTIDADE_JURIDICA_IDENTIDADE_JURIDICA = " + identiadeJuridicaId;


            cmd.CommandText = sql;

            var procuracaoId = cmd.ExecuteScalar();

            var result = new CryptographyHelper().Encrypt(procuracaoId.ToString());
            return result;
        }
    }
}
