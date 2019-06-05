
Feature: Declaração Nota Servico

Scenario: Ao selecionar a opção de Declaração de Serviços na página de declaração e solicitar uma adição de nota de serviço

	Given que eu logue no portal com os seguintes dados
	| Usuario       | Senha |
	| '01977364918' | 123   |

	And realize a autenticação no cnpj "06864931000114"
	Given que eu selecione a opção de Declaração de Serviços	
	Given que eu solicite uma nova declaração para a competência "08/2018"
	Given que eu solicite uma nova declaração de nota de serviço

	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '15/08/2018' | '1234' | 'A'   | '0'      | '07065385000114' | Não    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |

	Then o status Habilitado para o campo Alíquota deverá ser "false"
	Then o valor do campo Alíquota deverá ser igual a 0,00
	Then o valor do campo Alíquota deverá ser maior ou igual a 0
	Then o valor do campo Alíquota deverá ser menor ou igual a 5
	Then o valor do campo Alíquota deverá ser maior que -1
	Then o valor do campo Alíquota deverá ser menor que 5
