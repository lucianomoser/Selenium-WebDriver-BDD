Feature: DeclaracaoDeServicoTomadoOndeTomadorAdmMunicipal
         Como um Fiscal Municipal 
		 Desejo declarar uma nota fiscal de SERVIÇOS TOMADOS 
		 Sendo que o tomador e ADMINISTRADOR MUNICIPAL
		 		 

Background: 
	Given que eu esteja executando a declaração de serviços pela primeira vez	
	Given que eu desejo declarar as notas de serviço cujo Tomador {04914925000107} e Administrador Municipal
	Given que a empresa de CNPJ "04914925000107" é estabelecido
	Given que a empresa de CNPJ "04914925000107" é do tipo Homologado
	
	Given que eu logue no portal como administrador
	| Usuario          | Senha |
	| '04914925000107' | 123   |



Scenario: CEN.01 - Notas fiscais eletrônicas devem ser declaradas automaticamente e deve ser possível vincular um empenho. Não deve ser possível retificar outros dados

Given que eu desejo consultar a declaração de servico tomado
And que eu solicite uma nova declaração para a competência "11/2018"

Given eu pesquisar o número da nota fiscal "201800000000175".
Given que utilizamos a operação para gerenciar empenho, podemos vincular um empenho a uma nota fiscal eletrônica emitida
And forneça os seguintes dados para formulário de Adicionar Empenho
| UnidadeGestora | EmpenhoAno | EmpenhoNumero | SubEmpenhoNumero |
| 1              | 2019       | 1             | 1                |

Then o campo Dados do Empenho está visivel no formulario de Declaração de Nota Fiscal "true"
And que eu desejo gravar os empenhos na anota fiscal eletrônica emitida.














Scenario: CEN.02 - Deve ser possível adicionar uma nota manual e Vincular um Empenho

Given que a empresa de CNPJ "07065385000114" é estabelecido
Given que a empresa de CNPJ "07065385000114" é do tipo Homologado

And a seguinte configuração de serviços 
| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
| '07.02'        | '4212000'        | AnexoIII | Não             | Não          | Não           | 2.9      |

And que eu desejo consultar a declaração de servico tomado
And que eu solicite uma nova declaração para a competência "01/2019"
And que eu solicite uma nova declaração de nota de serviço	
And que eu solicite um novo empenho	
And forneça os seguintes dados para formulário de Adicionar Empenho
| UnidadeGestora | EmpenhoAno | EmpenhoNumero | SubEmpenhoNumero |
| 1              | 2019       | 1             | 1                |

And forneça os seguintes dados para formulário de declaracao de nota
| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
| Tomado     | '15/01/2019' | '1234' | 'A'   | '0'      | '07065385000114' | Não    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |

Then o campo Dados do Empenho está visivel no formulario de Declaração de Nota Fiscal "true"
Then será gravado a nota fiscal eletrônica e fechado o formulário de Declaração de Nota Fiscal.
And a situação da nota fiscal eletrônica está "Normal"
And o valor da nota fiscal eletrônica fica "29,00"




Scenario: CEN.03 - Deve ser possível imprimir apenas o boleto gerado para notas fiscais em que há a retenção de ISS.

Given que a empresa de CNPJ "07065385000114" é estabelecido
Given que a empresa de CNPJ "07065385000114" é optante do Simples Nacional

Given que a empresa de CNPJ "07065385000114" possui os seguintes faturamentos	
	| Mes | Ano  | Faturamento | MercadoExterno | RegimeCaixa | RegimeCaixaME | FatorR | AtingiuSubLimite | UltrapassouSubLimite | SubLimiteViaRba |	
	| 01  | 2018 | 700000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 02  | 2018 |  50000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 03  | 2018 | 120000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 04  | 2018 |  80000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 05  | 2018 | 111500      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 06  | 2018 | 135000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 07  | 2018 | 1160000     | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 08  | 2018 |  965000     | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 09  | 2018 |  600000     | 0              | 0           | 0             | 0      | 1                | 0                    | 0               |
	| 10  | 2018 |  100000     | 0              | 0           | 0             | 0      | 1                | 0                    | 0               |
	| 11  | 2018 |  0          | 0              | 0           | 0             | 0      | 1                | 0                    | 0               |
	| 12  | 2018 |  30000      | 0              | 0           | 0             | 0      | 1                | 0                    | 0               |


	
Given a seguinte configuração de serviços 
| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
| '01.01'        | '6202300'        | AnexoIII | Não             | Não          | Não           | 2.9      |

Given que eu desejo consultar a declaração de servico tomado
And que eu solicite uma nova declaração para a competência "01/2019"
And que eu solicite uma nova declaração de nota de serviço	
And forneça os seguintes dados para formulário de declaracao de nota
| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
| Tomado     | '15/01/2019' | '1234' | 'A'   | '0'      | '07065385000114' | Sim    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |

Then será gravado a nota fiscal eletrônica e fechado o formulário de Declaração de Nota Fiscal.
And a situação da retenção da nota fiscal eletrônica deverá ser "Sim".
And a visibilidade do botão imprimir boleto com retenção deverá ser igual a "true".




Scenario: CEN.04 - Não deve ser possível imprimir o boleto gerado para notas fiscais que não possuem retenção de ISS.

Given que a empresa de CNPJ "07065385000114" é estabelecido
And que a empresa de CNPJ "07065385000114" é do tipo Homologado
And a seguinte configuração de serviços 
| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
| '01.01'        | '6202300'        | AnexoIII | Não             | Não          | Não           | 2.9      |

Given que eu desejo consultar a declaração de servico tomado
And que eu solicite uma nova declaração para a competência "01/2019"
And que eu solicite uma nova declaração de nota de serviço	
And forneça os seguintes dados para formulário de declaracao de nota
| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
| Tomado     | '15/01/2019' | '1234' | 'A'   | '0'      | '07065385000114' | Não    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |

Then será gravado a nota fiscal eletrônica e fechado o formulário de Declaração de Nota Fiscal.
And a situação da retenção da nota fiscal eletrônica deverá ser "Não".
And a opção para marcar todas notas permanece desabilitada.



Scenario: CEN.05 - O boleto deve ser gerado apenas para as notas fiscais em que há a retenção de ISS e o ISS não esteja pago.

Given que a empresa de CNPJ "07065385000114" é estabelecido
And que a empresa de CNPJ "07065385000114" é do tipo Homologado
And a seguinte configuração de serviços 
| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
| '07.02'        | '4212000'        | AnexoIII | Não             | Não          | Não           | 2.9      |

And que eu desejo consultar a declaração de servico tomado
And que eu solicite uma nova declaração para a competência "01/2019"
And que eu solicite uma nova declaração de nota de serviço	
And forneça os seguintes dados para formulário de declaracao de nota
| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
| Tomado     | '15/01/2019' | '1234' | 'A'   | '0'      | '07065385000114' | Sim    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |

Then será gravado a nota fiscal eletrônica e fechado o formulário de Declaração de Nota Fiscal.
And a visibilidade do botão imprimir boleto com retenção deverá ser igual a "true".
And será impresso o boleto de retenção de iss com a nova data de vencimento "13/05/2019"
And será registrado o pagamento a guia de retenção de Issqn emitida pela empresa "07065385000114".
And a opção para marcar todas notas permanece desabilitada.



Scenario: CEN.06 - O débito gerado no sistema tributário deve ser constituído no cadastro da empresa que prestou o serviço.

Given que a empresa de CNPJ "07065385000114" é estabelecido
And que a empresa de CNPJ "07065385000114" é do tipo Homologado
And a seguinte configuração de serviços 
| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
| '07.02'        | '4212000'        | AnexoIII | Não             | Não          | Não           | 2.9      |

And que eu desejo consultar a declaração de servico tomado
And que eu solicite uma nova declaração para a competência "01/2019"
And que eu solicite uma nova declaração de nota de serviço	
And forneça os seguintes dados para formulário de declaracao de nota
| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
| Tomado     | '15/01/2019' | '1234' | 'A'   | '0'      | '07065385000114' | Sim    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |

Then será gravado a nota fiscal eletrônica e fechado o formulário de Declaração de Nota Fiscal.
And a opção para marcar todas notas permanece desabilitada.
And a visibilidade do botão imprimir boleto com retenção deverá ser igual a "true".
And será impresso o boleto de retenção de iss com a nova data de vencimento "13/05/2019"
And a empresa com o cnpj "07065385000114" gerou o débito no sistema tributário para o cadastro "9863"








Scenario: CEN.07 - Administrador Municipal pode declarar somente notas recebidas.

Given que a empresa de CNPJ "07065385000114" é estabelecido
Given que a empresa de CNPJ "07065385000114" é do tipo Homologado

Given a seguinte configuração de serviços 
| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
| '07.02'        | '4212000'        | AnexoIII | Não             | Não          | Não           | 2.9      |

Given que eu desejo consultar a declaração de servico tomado

And que eu solicite uma nova declaração para a competência "01/2019"

And que eu solicite uma nova declaração de nota de serviço	


Then o valor do campo Declarar como serviço tomado deverá estar selecionado igual a "true"

Then o status Habilitado para o campo Declarar como serviço tomado deverá ser "false"




















		 
