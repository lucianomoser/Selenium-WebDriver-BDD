
Feature: ServicosPrestadosDentroDoLimite
		 Como um usuário do sistema
		 Desejo declarar um nota fiscal de SERVIÇOS PRESTADOS
		 Sendo eu um PRESTADOR ESTABELECIDO e OPTANTE DO SIMPLES NACIONAL
		 E estando DENTRO DO SUBLIMITE de faturamento

 Background: 
	Given que eu esteja executando a declaração de serviços pela primeira vez
	Given que eu logue no portal com os seguintes dados
	| Usuario       | Senha |
	| '01977364918' | 123   |	

	And realize a autenticação no cnpj "06864931000114"

	Given que a empresa de CNPJ "06864931000114" é estabelecido
	Given que a empresa de CNPJ "06864931000114" é optante do Simples Nacional
	
	Given que a empresa de CNPJ "06864931000114" possui os seguintes faturamentos	
	| Mes | Ano  | Faturamento | MercadoExterno | RegimeCaixa | RegimeCaixaME | FatorR | AtingiuSubLimite | UltrapassouSubLimite | SubLimiteViaRba |
	| 06  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 07  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 08  | 2017 | 50000       | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 09  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 10  | 2017 | 145000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 11  | 2017 | 150000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 12  | 2017 | 265000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 01  | 2018 | 700000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 02  | 2018 | 50000       | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 03  | 2018 | 120000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 04  | 2018 | 80000       | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 05  | 2018 | 111500      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 06  | 2018 | 135000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 07  | 2018 | 60000       | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 08  | 2018 | 65000       | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |

	Given que eu selecione a opção de Declaração de Serviços	
	Given que eu solicite uma nova declaração para a competência "08/2018"


Scenario: C04 - Tomador Estabelecido Não Optante do Simples Nacional - Sem Retenção

	Given que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é do tipo Homologado

	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal |
	| '07.02'        | '4212000'        | AnexoIII | Não             | Não          | Não           |
		
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '15/08/2018' | '1234' | 'A'   | '0'      | '03936232000144' | Não    | '07.02'        | '4212000'        | 'Cerejeiras'       | 100000 |
	
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser igual a 0


Scenario: C05 - Tomador Estabelecido Não Optante do Simples Nacional - Com Retenção

	Given que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é do tipo Homologado

	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal |
	| '07.02'        | '4212000'        | AnexoIII | Não             | Não          | Não           |
		
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '15/08/2018' | '1234' | 'A'   | '0'      | '05914650000166' | Sim    | '07.02'        | '4212000'        | 'Cerejeiras'       | 100000 |
	
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser maior que 0
	Then o valor do campo Alíquota deverá ser menor ou igual a 5,00000000000


Scenario: C06 - Tomador Estabelecido Optante do Simples Nacional - Sem Retenção
	
	Given  que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional
			
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal |
	| '07.02'        | '4212000'        | AnexoIII | Não             | Não          | Não           |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '15/08/2018' | '1234' | 'A'   | '0'      | '03936232000144' | Não    | '07.02'        | '4212000'        | 'Cerejeiras'       | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser igual a 0


Scenario: C07 - Tomador Estabelecido Optante do Simples Nacional - Com Retenção
	
	Given  que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional
			
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal |
	| '07.02'        | '4212000'        | AnexoIII | Não             | Não          | Não           |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '15/08/2018' | '1234' | 'A'   | '0'      | '03936232000144' | Sim    | '07.02'        | '4212000'        | 'Cerejeiras'       | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser maior que 0
	Then o valor do campo Alíquota deverá ser menor ou igual a 5,00000000000


Scenario: C08 - Tomador Não Estabelecido Não Optante do Simples Nacional - Sem Retenção
	
	Given  que a empresa de CNPJ "07065385000114" não é estabelecido
	Given que a empresa não estabelecida de CNPJ "07065385000114" está cadastrada como Prestadora da empresa de CNPJ "06864931000114"
	Given que a empresa de CNPJ "07065385000114" é do tipo Homologado
			
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal |
	| '07.02'        | '4212000'        | AnexoIII | Não             | Não          | Não           |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '15/08/2018' | '1234' | 'A'   | '0'      | '03936232000144' | Não    | '07.02'        | '4212000'        | 'Cerejeiras'       | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser igual a 0

Scenario: C09 - Tomador Não Estabelecido Não Optante do Simples Nacional - Com Retenção
	
	Given  que a empresa de CNPJ "07065385000114" não é estabelecido
	Given que a empresa não estabelecida de CNPJ "07065385000114" está cadastrada como Prestadora da empresa de CNPJ "06864931000114"
	Given que a empresa de CNPJ "07065385000114" é do tipo Homologado
			
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal |
	| '07.02'        | '4212000'        | AnexoIII | Não             | Não          | Não           |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '15/08/2018' | '1234' | 'A'   | '0'      | '03936232000144' | Sim    | '07.02'        | '4212000'        | 'Cerejeiras'       | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser maior que 0
	Then o valor do campo Alíquota deverá ser menor ou igual a 5,00000000000

Scenario: C10 - Tomador Não Estabelecido Optante do Simples Nacional - Sem Retenção
	
	Given  que a empresa de CNPJ "07065385000114" não é estabelecido
	Given que a empresa não estabelecida de CNPJ "07065385000114" está cadastrada como Prestadora da empresa de CNPJ "06864931000114"
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional
			
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal |
	| '07.02'        | '4212000'        | AnexoIII | Não             | Não          | Não           |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '15/08/2018' | '1234' | 'A'   | '0'      | '03936232000144' | Não    | '07.02'        | '4212000'        | 'Cerejeiras'       | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser igual a 0

Scenario: C11 - Tomador Não Estabelecido Optante do Simples Nacional - Com Retenção
	
	Given  que a empresa de CNPJ "07065385000114" não é estabelecido
	Given que a empresa não estabelecida de CNPJ "07065385000114" está cadastrada como Prestadora da empresa de CNPJ "06864931000114"
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional
			
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal |
	| '07.02'        | '4212000'        | AnexoIII | Não             | Não          | Não           |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '15/08/2018' | '1234' | 'A'   | '0'      | '03936232000144' | Sim    | '07.02'        | '4212000'        | 'Cerejeiras'       | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser maior que 0
	Then o valor do campo Alíquota deverá ser menor ou igual a 5,00000000000

Scenario: E04 - Tomador Estabelecido Não Optante do Simples Nacional - Sem Retenção

	Given que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é do tipo Homologado

	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal |
	| '07.02'        | '4212000'        | AnexoIII | Não             | Não          | Sim           |
		
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '15/08/2018' | '1234' | 'A'   | '0'      | '03936232000144' | Não    | '07.02'        | '4212000'        | 'Buritis'          | 100000 |
	
	Then o status Habilitado para o campo Alíquota deverá ser "true"
	Then o valor do campo Alíquota deverá ser igual a 0

Scenario: E05 - Tomador Estabelecido Não Optante do Simples Nacional - Com Retenção

	Given que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é do tipo Homologado

	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal |
	| '07.02'        | '4212000'        | AnexoIII | Sim             | Não          | Sim           |
		
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '15/08/2018' | '1234' | 'A'   | '0'      | '05914650000166' | Sim    | '07.02'        | '4212000'        | 'Buritis'          | 100000 |
	
	Then o status Habilitado para o campo Alíquota deverá ser "true"
	Then o valor do campo Alíquota deverá ser igual a 0

Scenario: E06 - Tomador Estabelecido Optante do Simples Nacional - Sem Retenção
	
	Given  que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional
			
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal |
	| '07.02'        | '4212000'        | AnexoIII | Não             | Não          | Sim           |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '15/08/2018' | '1234' | 'A'   | '0'      | '03936232000144' | Não    | '07.02'        | '4212000'        | 'Buritis'          | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "true"
	Then o valor do campo Alíquota deverá ser igual a 0

Scenario: E07 - Tomador Estabelecido Optante do Simples Nacional - Com Retenção
	
	Given  que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional
			
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal |
	| '07.02'        | '4212000'        | AnexoIII | Não             | Não          | Sim           |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '15/08/2018' | '1234' | 'A'   | '0'      | '03936232000144' | Sim    | '07.02'        | '4212000'        | 'Buritis'          | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "true"
	Then o valor do campo Alíquota deverá ser igual a 0

Scenario: E08 - Tomador Não Estabelecido Não Optante do Simples Nacional - Sem Retenção
	
	Given  que a empresa de CNPJ "07065385000114" não é estabelecido
	Given que a empresa não estabelecida de CNPJ "07065385000114" está cadastrada como Prestadora da empresa de CNPJ "06864931000114"
	Given que a empresa de CNPJ "07065385000114" é do tipo Homologado
			
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal |
	| '07.02'        | '4212000'        | AnexoIII | Não             | Não          | Sim           |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '15/08/2018' | '1234' | 'A'   | '0'      | '03936232000144' | Não    | '07.02'        | '4212000'        | 'Buritis'          | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "true"
	Then o valor do campo Alíquota deverá ser igual a 0

Scenario: E09 - Tomador Não Estabelecido Não Optante do Simples Nacional - Com Retenção
	
	Given  que a empresa de CNPJ "07065385000114" não é estabelecido
	Given que a empresa não estabelecida de CNPJ "07065385000114" está cadastrada como Prestadora da empresa de CNPJ "06864931000114"
	Given que a empresa de CNPJ "07065385000114" é do tipo Homologado
			
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal |
	| '07.02'        | '4212000'        | AnexoIII | Não             | Não          | Sim           |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '15/08/2018' | '1234' | 'A'   | '0'      | '03936232000144' | Sim    | '07.02'        | '4212000'        | 'Buritis'          | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "true"
	Then o valor do campo Alíquota deverá ser igual a 0

Scenario: E10 - Tomador Não Estabelecido Optante do Simples Nacional - Sem Retenção
	
	Given  que a empresa de CNPJ "07065385000114" não é estabelecido
	Given que a empresa não estabelecida de CNPJ "07065385000114" está cadastrada como Prestadora da empresa de CNPJ "06864931000114"
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional
			
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal |
	| '07.02'        | '4212000'        | AnexoIII | Não             | Não          | Sim           |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '15/08/2018' | '1234' | 'A'   | '0'      | '03936232000144' | Não    | '07.02'        | '4212000'        | 'Buritis'          | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "true"
	Then o valor do campo Alíquota deverá ser igual a 0

Scenario: E11 - Tomador Não Estabelecido Optante do Simples Nacional - Com Retenção
	
	Given  que a empresa de CNPJ "07065385000114" não é estabelecido
	Given que a empresa não estabelecida de CNPJ "07065385000114" está cadastrada como Prestadora da empresa de CNPJ "06864931000114"
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional
			
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal |
	| '07.02'        | '4212000'        | AnexoIII | Sim             | Não          | Sim           |
			
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '15/08/2018' | '1234' | 'A'   | '0'      | '03936232000144' | Sim    | '07.02'        | '4212000'        | 'Buritis'          | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "true"
	Then o valor do campo Alíquota deverá ser igual a 0






