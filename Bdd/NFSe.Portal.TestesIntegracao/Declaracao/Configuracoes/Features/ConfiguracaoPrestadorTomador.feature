
Feature: Configuracoes dos paramentros de prestadores/tomadores

Scenario: Configuração da Empresa
	Given que a data de abertura da empresa de CNPJ "06864931000114" seja "10/06/2017"	
	Given que a empresa de CNPJ "06864931000114" é optante do Simples Nacional	
	Given que a empresa de CNPJ "06864931000114" é estabelecido
	Given que a empresa de CNPJ "07065385000114" possui os seguintes faturamentos	
	| Mes | Ano  | Faturamento | MercadoExterno | RegimeCaixa | RegimeCaixaME | FatorR |AtingiuSubLimite | UltrapassouSubLimite | SubLimiteViaRba |
	| 06  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
	| 07  | 2017 | 100000      | 0              | 0           | 0             | 0      | 0               | 0                    | 0               |
																				