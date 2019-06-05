Feature: CalculoISSEmpresaMaisDeUmAno
         Como um usuário do sistema
		 Desejo declarar uma nota fiscal de SERVIÇOS PRESTADOS afim de aferir o Calculo do ISSQN
		 Sendo eu uma EMPRESA ESTABELECIDA e OPTANTE DO SIMPLES NACIONAL
		 E possuindo a DATA DE INICIO DE ATIVIDADE com MAIS de 1 ANO entre a ABERTURA DA EMPRESA eo PERÍODO DE APURAÇÃO	 


 Background: 
	Given que eu esteja executando a declaração de serviços pela primeira vez
	Given que eu logue no portal com os seguintes dados
	| Usuario       | Senha |
	| '01977364918' | 123   |

	And realize a autenticação no cnpj "06864931000114"
	
	Given que a data de abertura da empresa de CNPJ "06864931000114" seja "10/06/2017"
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
	| 02  | 2018 |  50000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 03  | 2018 | 120000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 04  | 2018 |  80000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 05  | 2018 | 111500      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 06  | 2018 | 135000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 07  | 2018 |  60000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 08  | 2018 |  65000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
	| 09  | 2018 | 100000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |

	Given que eu selecione a opção de Declaração de Serviços	
	Given que eu solicite uma nova declaração para a competência "09/2018"

	Scenario: CEN.02.01 - Calculo ISS Empresa Com Mais de 12 Meses Do Anexo III Sem Retencao
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Não             | Não          | Não           | 2.8      |

	Given que eu solicite uma nova declaração de nota de serviço	

	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '05/09/2018' | '1234' | 'A'   | '0'      | '10306984000197' | Não    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |

	Then o valor do campo Alíquota deverá ser igual a 4,9108819076




	Scenario: CEN.02.01 - Calculo ISS Empresa Com Mais de 12 Meses Do Anexo III Com Retencao
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Sim             | Não          | Não           | 2.8      |

	Given que eu solicite uma nova declaração de nota de serviço	

	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '05/09/2018' | '1234' | 'A'   | '0'      | '10306984000197' | Sim    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |

	Then o valor do campo Alíquota deverá ser igual a 4,8946796339



	
	Scenario: CEN.02.01 - Calculo ISS Empresa Com Mais de 12 Meses Do Anexo IV Sem Retencao
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIV  | Não             | Não          | Não           | 2.8      |

	Given que eu solicite uma nova declaração de nota de serviço	

	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '05/09/2018' | '1234' | 'A'   | '0'      | '10306984000197' | Não    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |

	Then o valor do campo Alíquota deverá ser igual a 5,0000000000



	Scenario: CEN.02.01 - Calculo ISS Empresa Com Mais de 12 Meses Do Anexo IV Com Retencao
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIV  | Sim             | Não          | Não           | 2.8      |

	Given que eu solicite uma nova declaração de nota de serviço	

	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '05/09/2018' | '1234' | 'A'   | '0'      | '10306984000197' | Sim    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |

	Then o valor do campo Alíquota deverá ser igual a 5,0000000000



	Scenario: CEN.02.01 - Calculo ISS Empresa Com Mais de 12 Meses Do Anexo V Sem Retencao
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoV   | Não             | Não          | Não           | 2.8      |

	Given que eu solicite uma nova declaração de nota de serviço	

	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '05/09/2018' | '1234' | 'A'   | '0'      | '10306984000197' | Não    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |

	Then o valor do campo Alíquota deverá ser igual a 4,6685124905



	Scenario: CEN.02.01 - Calculo ISS Empresa Com Mais de 12 Meses Do Anexo V Com Retencao
	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoV   | Sim             | Não          | Não           | 2.8      |

	Given que eu solicite uma nova declaração de nota de serviço	

	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '05/09/2018' | '1234' | 'A'   | '0'      | '10306984000197' | Sim    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |

	Then o valor do campo Alíquota deverá ser igual a 4,6628947368