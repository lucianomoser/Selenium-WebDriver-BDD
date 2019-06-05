
Feature: Declaração

Scenario: Ao selecionar a opção de Declaração de Serviços
		 na página de declaração

    Given que eu esteja executando a declaração de serviços pela primeira vez
	Given que eu logue no portal com os seguintes dados
	| Usuario       | Senha |
	| '01977364918' | 123   |

	And realize a autenticação no cnpj "06864931000114"
	Given que eu selecione a opção de Declaração de Serviços	
	Given que eu solicite uma nova declaração para a competência "08/2018"
	Given que eu solicite uma nova declaração de nota de serviço



