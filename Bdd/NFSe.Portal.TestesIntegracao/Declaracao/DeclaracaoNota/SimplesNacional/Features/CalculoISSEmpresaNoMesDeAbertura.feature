Feature: CalculoISSEmpresaNoMesDeAbertura	
         Como um usuário do sistema
		 Desejo declarar uma nota fiscal de SERVIÇOS PRESTADOS afim de aferir o Calculo do ISSQN
		 Sendo eu uma EMPRESA ESTABELECIDA 
		 E OPTANTE DO SIMPLES NACIONAL
		 E desejo declarar a Prestação de Serviço no MESMO MÊS DA DATA DE ABERTURA DA EMPRESA		 


 Background: 
	Given que eu esteja executando a declaração de serviços pela primeira vez
	Given que eu logue no portal com os seguintes dados
	| Usuario       | Senha |
	| '01977364918' | 123   |

	And realize a autenticação no cnpj "06864931000114"
	
	Given que a data de abertura da empresa de CNPJ "06864931000114" seja "01/09/2018"
	Given que a empresa de CNPJ "06864931000114" é estabelecido
	Given que a empresa de CNPJ "06864931000114" é optante do Simples Nacional
	
	Given que a empresa de CNPJ "06864931000114" possui os seguintes faturamentos	
	| Mes | Ano  | Faturamento | MercadoExterno | RegimeCaixa | RegimeCaixaME | FatorR | AtingiuSubLimite | UltrapassouSubLimite | SubLimiteViaRba |
	| 09  | 2018 | 100000      | 0              | 0           | 0             | 0      | 0                | 0                    | 0               |
																																  
																																  
	Given que eu selecione a opção de Declaração de Serviços																	  
	Given que eu solicite uma nova declaração para a competência "09/2018"														  
																																  
																																  
	Scenario: CEN.02.02 - Calculo ISS Empresa no mes de abertura Do Anexo III Sem Retencao										  

	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Não             | Não          | Não           |16.0      |

	Given que eu solicite uma nova declaração de nota de serviço	

	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '01/09/2018' | '1234' | 'A'   | '0'      | '10306984000197' | Não    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |

	Then o valor do campo Alíquota deverá ser igual a 4,2347500000




	Scenario: CEN.02.02 - Calculo ISS Empresa no mes de abertura Do Anexo III Com Retencao

	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIII | Sim             | Não          | Não           | 0.0      |

	Given que eu solicite uma nova declaração de nota de serviço	

	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '01/09/2018' | '1234' | 'A'   | '0'      | '10306984000197' | Sim    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |

	Then o valor do campo Alíquota deverá ser igual a 2,0000000000




	
	Scenario: CEN.02.02 - Calculo ISS Empresa no mes de abertura Do Anexo IV Sem Retencao

	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIV  | Não             | Não          | Não           |14.0      |

	Given que eu solicite uma nova declaração de nota de serviço	

	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '01/09/2018' | '1234' | 'A'   | '0'      | '10306984000197' | Não    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |

	Then o valor do campo Alíquota deverá ser igual a 4,2740000000





	Scenario: CEN.02.02 - Calculo ISS Empresa no mes de abertura Do Anexo IV Com Retencao

	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIV  | Sim             | Não          | Não           | 0.0      |

	Given que eu solicite uma nova declaração de nota de serviço	

	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '01/09/2018' | '1234' | 'A'   | '0'      | '10306984000197' | Sim    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |

	Then o valor do campo Alíquota deverá ser igual a 2,0000000000



	
	Scenario: CEN.02.02 - Calculo ISS Empresa no mes de abertura Do Anexo V Sem Retencao

	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoV   | Não             | Não          | Não           |20.50     |

	Given que eu solicite uma nova declaração de nota de serviço	

	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '01/09/2018' | '1234' | 'A'   | '0'      | '10306984000197' | Não    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |

	Then o valor do campo Alíquota deverá ser igual a 4,0057500000



	
	Scenario: CEN.02.02 - Calculo ISS Empresa no mes de abertura Do Anexo V Com Retencao

	Given a seguinte configuração de serviços 
	| ServicoFederal | ServicoMunicipal | Anexo    | RetencaoTomador | SujeitoFatoR | DevidoNoLocal | Aliquota |
	| '01.01'        | '6202300'        | AnexoIV  | Sim             | Não          | Não           | 0.0      |

	Given que eu solicite uma nova declaração de nota de serviço	

	And forneça os seguintes dados para formulário de declaracao de nota	
	| Modalidade | Emissao      | Numero | Serie | Aliquota | TomadorPrestador | Retido | ServicoFederal | ServicoMunicipal | MunicipioPrestacao | Valor  |
	| Prestado   | '01/09/2018' | '1234' | 'A'   | '0'      | '10306984000197' | Sim    | '01.01'        | '6202300'        | 'Cerejeiras'       | 100000 |

	Then o valor do campo Alíquota deverá ser igual a 2,0000000000