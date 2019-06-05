
Feature: Autenticação
Scenario: Realizar autenticação para um determinado CNPJ
	Given que eu logue no portal com os seguintes dados
	| Usuario       | Senha |
	| '01977364918' | 123   |

	And realize a autenticação no cnpj "06864931000114"
