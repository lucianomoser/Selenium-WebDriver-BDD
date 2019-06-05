
Feature: DeclaracaoEntregaSemServicoPrestadoTomado
	     Entrega da Declaração de Nota de Serviços Prestados e/ou Tomados
	
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
	| 06  | 2018 | 100000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |

    Given que eu selecione a opção de Declaração de Serviços	
	Given que eu solicite uma nova declaração para a competência "06/2018"

Scenario: Realizar a opção de Declaração De Entrega de Serviços na página de declaração

    
	Given que eu selecione a opção de declaração de Entrega

	Given forneça os seguintes dados para formulário de declaracao de Entrega
	| RegimeApuracao | ReceitaInterno | ReceitaExterno | FatorR |
	| Competência    | 10000,00       | 1,00           | 1,00   |

	Then A mensagem de validação de entrega da declaração deve ser igual a "Entrega realizada com sucesso!"
	

	





	




