
Feature: ServicosTomadosLimiteExcedido 
		 Como um usuário do sistema
		 Desejo declarar um nota fiscal de SERVIÇOS TOMADOS
		 Sendo eu uma EMPRESA ESTABELECIDA e OPTANTE DO SIMPLES NACIONAL
		 E tendo UTRAPASSADO O SUBLIMITE de faturamento

 Background: 
	Given que eu esteja executando a declaração de serviços pela primeira vez
	Given que eu logue no portal com os seguintes dados
	| Usuario       | Senha |
	| '01977364918' | 123   |	

	And realize a autenticação no cnpj "06864931000114"

	Given que a empresa de CNPJ "06864931000114" é estabelecido
	Given que a empresa de CNPJ "06864931000114" é optante do Simples Nacional
	
	Given que a empresa de CNPJ "06864931000114" possui os seguintes faturamentos	
	| Mes | Ano  | Faturamento | MercadoExterno | RegimeCaixa | RegimeCaixaME | FatorR |AtingiuSubLimite | UltrapassouSubLimite |SubLimiteViaRba |
	| 06  | 2017 | 400000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0              |
	| 07  | 2017 | 400000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0              |
	| 08  | 2017 | 500000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0              |
	| 09  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0              |
	| 10  | 2017 | 145000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0              |
	| 11  | 2017 | 450000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0              |
	| 12  | 2017 | 465000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0              |
	| 01  | 2018 | 700000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0              |
	| 02  | 2018 | 500000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0              |
	| 03  | 2018 | 420000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0              |
	| 04  | 2018 | 800000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0              |
	| 05  | 2018 | 111500      | 0              | 0           | 0             | 0      | 0               | 0                    | 0              |
	| 06  | 2018 | 135000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0              |
	| 07  | 2018 | 600000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0              |
	| 08  | 2018 | 650000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0              |

	Given que eu selecione a opção de Declaração de Serviços	
	Given que eu solicite uma nova declaração para a competência "08/2018"



Scenario: T04 - Prestador Estabelecido - Não Optante do Simples Nacional - Sem Retenção

	Given que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é do tipo Homologado

	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Não             | Não          | Não           | 2.8      |
		
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Não    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |
	
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser igual a 2,80
	


Scenario: T05 - Prestador Estabelecido - Não Optante do Simples Nacional - Com Retenção

	Given que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é do tipo Homologado

	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Sim             | Não          | Não           | 2.8      |
		
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Sim    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |
	
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser igual a 2,80
	

	
Scenario: T06 - Prestador Estabelecido - Optante do Simples Nacional - Dentro do Sublimite - Sem Retenção
	
	Given que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional
	
	Given que a empresa de CNPJ "07065385000114" possui os seguintes faturamentos	
	| Mes | Ano  | Faturamento | MercadoExterno | RegimeCaixa | RegimeCaixaME | FatorR |AtingiuSubLimite | UltrapassouSubLimite | SubLimiteViaRba |
	| 06  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2017 | 50000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 09  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 10  | 2017 | 145000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 11  | 2017 | 150000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 12  | 2017 | 265000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 01  | 2018 | 700000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 02  | 2018 | 50000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 03  | 2018 | 120000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 04  | 2018 | 80000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 05  | 2018 | 111500      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 06  | 2018 | 135000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2018 | 60000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2018 | 65000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
			
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Não             | Não          | Não           | 2.8      |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Não    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser igual a 0,00



Scenario: T07 - Prestador Estabelecido - Optante do Simples Nacional - Dentro do Sublimite - Com Retenção
	
	Given que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional
	
	Given que a empresa de CNPJ "07065385000114" possui os seguintes faturamentos	
	| Mes | Ano  | Faturamento | MercadoExterno | RegimeCaixa | RegimeCaixaME | FatorR |AtingiuSubLimite | UltrapassouSubLimite | SubLimiteViaRba |
	| 06  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2017 | 50000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 09  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 10  | 2017 | 145000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 11  | 2017 | 150000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 12  | 2017 | 265000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 01  | 2018 | 700000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 02  | 2018 | 50000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 03  | 2018 | 120000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 04  | 2018 | 80000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 05  | 2018 | 111500      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 06  | 2018 | 135000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2018 | 60000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2018 | 65000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
		
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Sim             | Não          | Não           | 2.8      |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Sim    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "true"
	Then o valor do campo Alíquota deverá ser maior ou igual a 2,0000000000
	Then o valor do campo Alíquota deverá ser menor ou igual a 5,0000000000



Scenario: T08 - Prestador Estabelecido - Optante do Simples Nacional - Ultrapassou o Sublimite - Sem Retenção
	
	Given que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional

	Given que a empresa de CNPJ "07065385000114" possui os seguintes faturamentos	
	| Mes | Ano  | Faturamento | MercadoExterno | RegimeCaixa | RegimeCaixaME | FatorR |AtingiuSubLimite | UltrapassouSubLimite | SubLimiteViaRba |
	| 06  | 2017 | 400000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2017 | 400000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2017 | 500000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 09  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 10  | 2017 | 145000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 11  | 2017 | 450000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 12  | 2017 | 465000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 01  | 2018 | 700000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 02  | 2018 | 500000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 03  | 2018 | 420000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 04  | 2018 | 800000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 05  | 2018 | 111500      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 06  | 2018 | 135000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2018 | 600000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2018 | 650000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Não             | Não          | Não           | 2.8      |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Não    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser igual a 0,00



Scenario: T09 - Prestador Estabelecido - Optante do Simples Nacional - Ultrapassou o Sublimite - Com Retenção
	
	Given que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional	

	Given que a empresa de CNPJ "07065385000114" possui os seguintes faturamentos	
	| Mes | Ano  | Faturamento | MercadoExterno | RegimeCaixa | RegimeCaixaME | FatorR |AtingiuSubLimite | UltrapassouSubLimite | SubLimiteViaRba |
	| 06  | 2017 | 400000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2017 | 400000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2017 | 500000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 09  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 10  | 2017 | 145000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 11  | 2017 | 450000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 12  | 2017 | 465000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 01  | 2018 | 700000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 02  | 2018 | 500000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 03  | 2018 | 420000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 04  | 2018 | 800000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 05  | 2018 | 111500      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 06  | 2018 | 135000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2018 | 600000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2018 | 650000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
		
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Sim             | Não          | Não           | 2.8      |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Sim    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "true"
	Then o valor do campo Alíquota deverá ser maior ou igual a 2,0000000000
	Then o valor do campo Alíquota deverá ser menor ou igual a 5,0000000000



Scenario: T10 - Prestador Não Estabelecido - Não Optante do Simples Nacional - Sem Retenção

	Given que a empresa de CNPJ "07065385000114" não é estabelecido
	Given que a empresa não estabelecida de CNPJ "07065385000114" está cadastrada como Prestadora da empresa de CNPJ "06864931000114"
	Given que a empresa de CNPJ "07065385000114" é do tipo Homologado
			
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Não             | Não          | Não           | 2.8      |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Não    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser igual a 2,80
	



Scenario: T11 - Prestador Não Estabelecido - Não Optante do Simples Nacional - Com Retenção
	
	Given que a empresa de CNPJ "07065385000114" não é estabelecido
	Given que a empresa não estabelecida de CNPJ "07065385000114" está cadastrada como Prestadora da empresa de CNPJ "06864931000114"
	Given que a empresa de CNPJ "07065385000114" é do tipo Homologado
			
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Sim             | Não          | Não           | 2.8      |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Sim    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser igual a 2,80



Scenario: T12 - Prestador Não Estabelecido - Optante do Simples Nacional - Dentro do Sublimite - Sem Retenção
	
	Given que a empresa de CNPJ "07065385000114" não é estabelecido
	Given que a empresa não estabelecida de CNPJ "07065385000114" está cadastrada como Prestadora da empresa de CNPJ "06864931000114"
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional	
		
	Given que a empresa de CNPJ "07065385000114" possui os seguintes faturamentos	
	| Mes | Ano  | Faturamento | MercadoExterno | RegimeCaixa | RegimeCaixaME | FatorR |AtingiuSubLimite | UltrapassouSubLimite | SubLimiteViaRba |
	| 06  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2017 | 50000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 09  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 10  | 2017 | 145000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 11  | 2017 | 150000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 12  | 2017 | 265000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 01  | 2018 | 700000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 02  | 2018 | 50000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 03  | 2018 | 120000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 04  | 2018 | 80000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 05  | 2018 | 111500      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 06  | 2018 | 135000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2018 | 60000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2018 | 65000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
			
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Não             | Não          | Não           | 2.8      |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Não    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser igual a 0,00



Scenario: T13 - Prestador Não Estabelecido - Optante do Simples Nacional - Dentro do Sublimite - Com Retenção
	
	Given que a empresa de CNPJ "07065385000114" não é estabelecido
	Given que a empresa não estabelecida de CNPJ "07065385000114" está cadastrada como Prestadora da empresa de CNPJ "06864931000114"
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional	

	Given que a empresa de CNPJ "07065385000114" possui os seguintes faturamentos	
	| Mes | Ano  | Faturamento | MercadoExterno | RegimeCaixa | RegimeCaixaME | FatorR |AtingiuSubLimite | UltrapassouSubLimite | SubLimiteViaRba |
	| 06  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2017 | 50000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 09  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 10  | 2017 | 145000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 11  | 2017 | 150000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 12  | 2017 | 265000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 01  | 2018 | 700000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 02  | 2018 | 50000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 03  | 2018 | 120000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 04  | 2018 | 80000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 05  | 2018 | 111500      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 06  | 2018 | 135000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2018 | 60000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2018 | 65000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
			
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Sim             | Não          | Não           | 2.8      |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Sim    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "false"
    Then o valor do campo Alíquota deverá ser maior ou igual a 2,0000000000
	Then o valor do campo Alíquota deverá ser menor ou igual a 5,0000000000



Scenario: T14 - Prestador Não Estabelecido - Optante do Simples Nacional - Ultrapassou Sublimite - Sem Retenção
	
	Given que a empresa de CNPJ "07065385000114" não é estabelecido
	Given que a empresa não estabelecida de CNPJ "07065385000114" está cadastrada como Prestadora da empresa de CNPJ "06864931000114"
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional

	Given que a empresa de CNPJ "07065385000114" possui os seguintes faturamentos	
	| Mes | Ano  | Faturamento | MercadoExterno | RegimeCaixa | RegimeCaixaME | FatorR |AtingiuSubLimite | UltrapassouSubLimite | SubLimiteViaRba |
	| 06  | 2017 | 400000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2017 | 400000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2017 | 500000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 09  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 10  | 2017 | 145000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 11  | 2017 | 450000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 12  | 2017 | 465000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 01  | 2018 | 700000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 02  | 2018 | 500000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 03  | 2018 | 420000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 04  | 2018 | 800000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 05  | 2018 | 111500      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 06  | 2018 | 135000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2018 | 600000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2018 | 650000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
				
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Não             | Não          | Não           | 2.8      |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Não    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser igual a 0,00



Scenario: T15 - Prestador Não Estabelecido - Optante do Simples Nacional - Ultrapassou o Sublimite - Com Retenção
	
	Given que a empresa de CNPJ "07065385000114" não é estabelecido
	Given que a empresa não estabelecida de CNPJ "07065385000114" está cadastrada como Prestadora da empresa de CNPJ "06864931000114"
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional

	Given que a empresa de CNPJ "07065385000114" possui os seguintes faturamentos	
	| Mes | Ano  | Faturamento | MercadoExterno | RegimeCaixa | RegimeCaixaME | FatorR |AtingiuSubLimite | UltrapassouSubLimite | SubLimiteViaRba |
	| 06  | 2017 | 400000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2017 | 400000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2017 | 500000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 09  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 10  | 2017 | 145000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 11  | 2017 | 450000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 12  | 2017 | 465000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 01  | 2018 | 700000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 02  | 2018 | 500000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 03  | 2018 | 420000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 04  | 2018 | 800000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 05  | 2018 | 111500      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 06  | 2018 | 135000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2018 | 600000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2018 | 650000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
				
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Sim             | Não          | Não           | 2.8      |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Sim    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "true"
	Then o valor do campo Alíquota deverá ser maior ou igual a 2,00
	Then o valor do campo Alíquota deverá ser menor ou igual a 5,00

		

Scenario: U04 - Prestador Estabelecido - Não Optante do Simples Nacional - Sem Retenção

	Given que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é do tipo Homologado

	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Não             | Não          | Não           | 2.9      |
		
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Não    | '01.01'        | '6202300'        | 'Buritis'          | 100000 |
	
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser maior ou igual a 2,0000000000
	Then o valor do campo Alíquota deverá ser menor ou igual a 5,0000000000



Scenario: U05 - Prestador Estabelecido - Não Optante do Simples Nacional - Com Retenção

	Given que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é do tipo Homologado

	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Sim             | Não          | Não           | 2.9      |
		
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Sim    | '01.01'        | '6202300'        | 'Buritis'          | 100000 |
	
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser maior ou igual a 2,0000000000
	Then o valor do campo Alíquota deverá ser menor ou igual a 5,0000000000

	

Scenario: U06 - Prestador Estabelecido - Optante do Simples Nacional - Dentro do Sublimite - Sem Retenção
	
	Given que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional	
	Given que a empresa de CNPJ "07065385000114" possui os seguintes faturamentos	
	| Mes | Ano  | Faturamento | MercadoExterno | RegimeCaixa | RegimeCaixaME | FatorR |AtingiuSubLimite | UltrapassouSubLimite | SubLimiteViaRba |
	| 06  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2017 | 50000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 09  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 10  | 2017 | 145000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 11  | 2017 | 150000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 12  | 2017 | 265000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 01  | 2018 | 700000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 02  | 2018 | 50000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 03  | 2018 | 120000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 04  | 2018 | 80000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 05  | 2018 | 111500      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 06  | 2018 | 135000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2018 | 60000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2018 | 65000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
			
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Não             | Não          | Não           | 2.8      |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Não    | '01.01'        | '6202300'        | 'Buritis'          | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser igual a 0,00



Scenario: U07 - Prestador Estabelecido - Optante do Simples Nacional - Dentro do Sublimite - Com Retenção
	
	Given que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional

	Given que a empresa de CNPJ "07065385000114" possui os seguintes faturamentos	
	| Mes | Ano  | Faturamento | MercadoExterno | RegimeCaixa | RegimeCaixaME | FatorR |AtingiuSubLimite | UltrapassouSubLimite | SubLimiteViaRba |
	| 06  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2017 | 50000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 09  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 10  | 2017 | 145000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 11  | 2017 | 150000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 12  | 2017 | 265000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 01  | 2018 | 700000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 02  | 2018 | 50000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 03  | 2018 | 120000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 04  | 2018 | 80000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 05  | 2018 | 111500      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 06  | 2018 | 135000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2018 | 60000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2018 | 65000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
		
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Sim             | Não          | Não           | 2.8      |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Sim    | '01.01'        | '6202300'        | 'Buritis'          | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "true"
	Then o valor do campo Alíquota deverá ser maior ou igual a 2,0000000000
	Then o valor do campo Alíquota deverá ser menor ou igual a 5,0000000000



Scenario: U08 - Prestador Estabelecido - Optante do Simples Nacional - Ultrapassou o Sublimite - Sem Retenção
	
	Given que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional

	Given que a empresa de CNPJ "07065385000114" possui os seguintes faturamentos	
	| Mes | Ano  | Faturamento | MercadoExterno | RegimeCaixa | RegimeCaixaME | FatorR |AtingiuSubLimite | UltrapassouSubLimite | SubLimiteViaRba |
	| 06  | 2017 | 400000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2017 | 400000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2017 | 500000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 09  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 10  | 2017 | 145000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 11  | 2017 | 450000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 12  | 2017 | 465000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 01  | 2018 | 700000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 02  | 2018 | 500000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 03  | 2018 | 420000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 04  | 2018 | 800000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 05  | 2018 | 111500      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 06  | 2018 | 135000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2018 | 600000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2018 | 650000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Não             | Não          | Não           | 2.8      |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Não    | '01.01'        | '6202300'        | 'Buritis'          | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser igual a 0,00



Scenario: U09 - Prestador Estabelecido - Optante do Simples Nacional - Ultrapassou o Sublimite - Com Retenção
	
	Given que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional	

	Given que a empresa de CNPJ "07065385000114" possui os seguintes faturamentos	
	| Mes | Ano  | Faturamento | MercadoExterno | RegimeCaixa | RegimeCaixaME | FatorR |AtingiuSubLimite | UltrapassouSubLimite | SubLimiteViaRba |
	| 06  | 2017 | 400000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2017 | 400000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2017 | 500000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 09  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 10  | 2017 | 145000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 11  | 2017 | 450000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 12  | 2017 | 465000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 01  | 2018 | 700000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 02  | 2018 | 500000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 03  | 2018 | 420000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 04  | 2018 | 800000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 05  | 2018 | 111500      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 06  | 2018 | 135000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2018 | 600000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2018 | 650000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
		
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Sim             | Não          | Não           | 2.8      |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Sim    | '01.01'        | '6202300'        | 'Buritis'          | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "true"
	Then o valor do campo Alíquota deverá ser maior ou igual a 2,0000000000
	Then o valor do campo Alíquota deverá ser menor ou igual a 5,0000000000



Scenario: U10 - Prestador Não Estabelecido - Não Optante do Simples Nacional - Sem Retenção

	Given que a empresa de CNPJ "07065385000114" não é estabelecido
	Given que a empresa não estabelecida de CNPJ "07065385000114" está cadastrada como Prestadora da empresa de CNPJ "06864931000114"
	Given que a empresa de CNPJ "07065385000114" é do tipo Homologado
			
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Não             | Não          | Não           | 2.9      |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Não    | '01.01'        | '6202300'        | 'Buritis'          | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser maior ou igual a 2,0000000000
	Then o valor do campo Alíquota deverá ser menor ou igual a 5,0000000000



Scenario: U11 - Prestador Não Estabelecido - Não Optante do Simples Nacional - Com Retenção
	
	Given que a empresa de CNPJ "07065385000114" não é estabelecido
	Given que a empresa de CNPJ "07065385000114" é do tipo Homologado
			
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Sim             | Não          | Não           | 2.9      |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Sim    | '01.01'        | '6202300'        | 'Buritis'          | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser maior ou igual a 2,0000000000
	Then o valor do campo Alíquota deverá ser menor ou igual a 5,0000000000



Scenario: U12 - Prestador Não Estabelecido - Optante do Simples Nacional - Dentro do Sublimite - Sem Retenção
	
	Given que a empresa de CNPJ "07065385000114" não é estabelecido
	Given que a empresa não estabelecida de CNPJ "07065385000114" está cadastrada como Prestadora da empresa de CNPJ "06864931000114"
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional	

	Given que a empresa de CNPJ "07065385000114" possui os seguintes faturamentos	
	| Mes | Ano  | Faturamento | MercadoExterno | RegimeCaixa | RegimeCaixaME | FatorR |AtingiuSubLimite | UltrapassouSubLimite | SubLimiteViaRba |
	| 06  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2017 | 50000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 09  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 10  | 2017 | 145000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 11  | 2017 | 150000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 12  | 2017 | 265000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 01  | 2018 | 700000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 02  | 2018 | 50000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 03  | 2018 | 120000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 04  | 2018 | 80000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 05  | 2018 | 111500      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 06  | 2018 | 135000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2018 | 60000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2018 | 65000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
			
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Não             | Não          | Não           | 2.8      |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Não    | '01.01'        | '6202300'        | 'Buritis'          | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser igual a 0,00



Scenario: U13 - Prestador Não Estabelecido - Optante do Simples Nacional - Dentro do Sublimite - Com Retenção
	
	Given que a empresa de CNPJ "07065385000114" não é estabelecido
	Given que a empresa não estabelecida de CNPJ "07065385000114" está cadastrada como Prestadora da empresa de CNPJ "06864931000114"
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional

    Given que a empresa de CNPJ "07065385000114" possui os seguintes faturamentos	
	| Mes | Ano  | Faturamento | MercadoExterno | RegimeCaixa | RegimeCaixaME | FatorR |AtingiuSubLimite | UltrapassouSubLimite | SubLimiteViaRba |
	| 06  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2017 | 50000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 09  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 10  | 2017 | 145000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 11  | 2017 | 150000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 12  | 2017 | 265000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 01  | 2018 | 700000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 02  | 2018 | 50000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 03  | 2018 | 120000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 04  | 2018 | 80000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 05  | 2018 | 111500      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 06  | 2018 | 135000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2018 | 60000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2018 | 65000       | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
			
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Sim             | Não          | Não           | 2.8      |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Sim    | '01.01'        | '6202300'        | 'Buritis'          | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "false"
    Then o valor do campo Alíquota deverá ser maior ou igual a 2,0000000000
	Then o valor do campo Alíquota deverá ser menor ou igual a 5,0000000000



Scenario: U14 - Prestador Não Estabelecido - Optante do Simples Nacional - Ultrapassou Sublimite - Sem Retenção
	
	Given que a empresa de CNPJ "07065385000114" não é estabelecido
	Given que a empresa não estabelecida de CNPJ "07065385000114" está cadastrada como Prestadora da empresa de CNPJ "06864931000114"
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional

	Given que a empresa de CNPJ "07065385000114" possui os seguintes faturamentos	
	| Mes | Ano  | Faturamento | MercadoExterno | RegimeCaixa | RegimeCaixaME | FatorR |AtingiuSubLimite | UltrapassouSubLimite | SubLimiteViaRba |
	| 06  | 2017 | 400000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2017 | 400000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2017 | 500000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 09  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 10  | 2017 | 145000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 11  | 2017 | 450000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 12  | 2017 | 465000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 01  | 2018 | 700000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 02  | 2018 | 500000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 03  | 2018 | 420000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 04  | 2018 | 800000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 05  | 2018 | 111500      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 06  | 2018 | 135000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2018 | 600000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2018 | 650000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
				
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Não             | Não          | Não           | 2.8      |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Não    | '01.01'        | '6202300'        | 'Buritis'          | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser igual a 0,00



Scenario: U15 - Prestador Não Estabelecido - Optante do Simples Nacional - Ultrapassou o Sublimite - Com Retenção
	
	Given que a empresa de CNPJ "07065385000114" não é estabelecido
	Given que a empresa não estabelecida de CNPJ "07065385000114" está cadastrada como Prestadora da empresa de CNPJ "06864931000114"
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional

	Given que a empresa de CNPJ "07065385000114" possui os seguintes faturamentos	
	| Mes | Ano  | Faturamento | MercadoExterno | RegimeCaixa | RegimeCaixaME | FatorR |AtingiuSubLimite | UltrapassouSubLimite | SubLimiteViaRba |
	| 06  | 2017 | 400000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2017 | 400000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2017 | 500000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 09  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 10  | 2017 | 145000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 11  | 2017 | 450000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 12  | 2017 | 465000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 01  | 2018 | 700000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 02  | 2018 | 500000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 03  | 2018 | 420000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 04  | 2018 | 800000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 05  | 2018 | 111500      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 06  | 2018 | 135000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2018 | 600000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 08  | 2018 | 650000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
				
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Sim             | Não          | Não           | 2.8      |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Tomado     | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Sim    | '01.01'        | '6202300'        | 'Buritis'          | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "true"
	Then o valor do campo Alíquota deverá ser maior ou igual a 2,0000000000
	Then o valor do campo Alíquota deverá ser menor ou igual a 5,0000000000
