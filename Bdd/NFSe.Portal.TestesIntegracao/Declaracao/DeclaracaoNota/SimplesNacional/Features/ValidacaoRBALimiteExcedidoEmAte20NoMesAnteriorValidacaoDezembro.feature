Feature: ValidacaoRBALimiteExcedidoEmAte20NoMesesAnterioresValidacaoDezembro
         Como um usuário do sistema
		 Desejo declarar um nota fiscal de SERVIÇOS PRESTADOS
		 Sendo eu um PRESTADOR ESTABELECIDO e OPTANTE DO SIMPLES NACIONAL
		 E tendo UTRAPASSADO O SUBLIMITE EM ATE 20 PORCENTO de faturamento Do MES ANTERIOR a Declaração VALIDANDO NO MÊS DE DEZEMBRO

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
	| 08  | 2017 |  50000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 09  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 10  | 2017 | 145000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 11  | 2017 | 150000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 12  | 2017 | 265000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 01  | 2018 | 700000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 02  | 2018 |  50000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 03  | 2018 | 120000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 04  | 2018 |  80000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 05  | 2018 | 111500      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 06  | 2018 | 135000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 07  | 2018 | 1160000     | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 08  | 2018 |  965000     | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 09  | 2018 |  600000     | 0              | 0           | 0             | 0      | 1                | 0                    | 0               |
	| 10  | 2018 |  100000     | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 11  | 2018 |  0          | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 12  | 2018 |  30000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |

		
	
	Given que eu selecione a opção de Declaração de Serviços	
	Given que eu solicite uma nova declaração para a competência "12/2018"
	



Scenario: CEN.04.02 - Validacao RBA Excedeu o SubLimite Em Ate 20 Porcento Em Meses Anteriores a Declaracao Validacao em Dezembro Do Anexo III Sem Retencao

	Given que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional

	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '07.02'        | '4212000'        | AnexoIII | Não             | Não          | Não           | 2.9      |
		
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '15/12/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Não    | '07.02'        | '4212000'        | 'Cerejeiras'       | 100000 |
		
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ter o tamanho total igual a 12
	Then o valor do campo Alíquota deverá ter a quantidade de casas decimais maior que 2




Scenario: CEN.04.02 - Validacao RBA Excedeu o SubLimite Em Ate 20 Porcento Em Meses Anteriores a Declaracao Validacao em Dezembro Do Anexo III Com Retencao

	Given que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional

	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '07.02'        | '4212000'        | AnexoIII | Não             | Não          | Não           | 2.9      |
		
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '15/12/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Sim    | '07.02'        | '4212000'        | 'Cerejeiras'       | 100000 |
	
	
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ter o tamanho total igual a 12
	Then o valor do campo Alíquota deverá ter a quantidade de casas decimais maior que 2	


	
	
Scenario: CEN.04.02 - Validacao RBA Excedeu o SubLimite Em Ate 20 Porcento Em Meses Anteriores a Declaracao Validacao em Dezembro Do Anexo IV Sem Retencao

	Given que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional

	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '07.02'        | '4212000'        | AnexoIV  | Não             | Não          | Não           | 2.9      |
		
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '15/12/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Não    | '07.02'        | '4212000'        | 'Cerejeiras'       | 100000 |
	
	
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ter o tamanho total igual a 12
	Then o valor do campo Alíquota deverá ter a quantidade de casas decimais maior que 2




Scenario: CEN.04.02 - Validacao RBA Excedeu o SubLimite Em Ate 20 Porcento Em Meses Anteriores a Declaracao Validacao em Dezembro Do Anexo IV Com Retencao

	Given que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional

	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '07.02'        | '4212000'        | AnexoIV  | Não             | Não          | Não           | 2.9      |
		
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '15/12/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Sim    | '07.02'        | '4212000'        | 'Cerejeiras'       | 100000 |
	
	
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ter o tamanho total igual a 12
	Then o valor do campo Alíquota deverá ter a quantidade de casas decimais maior que 2
	   
	
	
	
Scenario: CEN.04.02 - Validacao RBA Excedeu o SubLimite Em Ate 20 Porcento Em Meses Anteriores a Declaracao Validacao em Dezembro Do Anexo V Sem Retencao

	Given que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional

	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '07.02'        | '4212000'        | AnexoV   | Não             | Não          | Não           | 2.9      |
		
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '15/12/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Não    | '07.02'        | '4212000'        | 'Cerejeiras'       | 100000 |
	
	
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ter o tamanho total igual a 12
	Then o valor do campo Alíquota deverá ter a quantidade de casas decimais maior que 2




Scenario: CEN.04.02 - Validacao RBA Excedeu o SubLimite Em Ate 20 Porcento Em Meses Anteriores a Declaracao Validacao em Dezembro Do Anexo V Com Retencao

	Given que a empresa de CNPJ "07065385000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional

	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '07.02'        | '4212000'        | AnexoV   | Não             | Não          | Não           | 2.9      |
		
	Given que eu solicite uma nova declaração de nota de serviço	
	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '15/12/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Sim    | '07.02'        | '4212000'        | 'Cerejeiras'       | 100000 |
	
	
	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ter o tamanho total igual a 12
	Then o valor do campo Alíquota deverá ter a quantidade de casas decimais maior que 2