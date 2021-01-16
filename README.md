# Desafio Técnico .NET
## OBJETIVO
Escrever uma aplicação .NET que tenha como objetivo, fazer upload de arquivo de log e popular o banco de dados. Para isso será necessário uma tela onde o usuário possa listar/consultar/pesquisar logs, e uma segunda tela que possibilite ao usuário a inserção manual de um arquivo de log. Implementar o back-end com (ASP .NET Core) e front-end usando JavaScript, AJAX, JQuery, HTML5, CSS3 ou Angular (Se for em angular, preferencialmente acima do 6).

## DETALHES DO BACK-END
**Abaixo os requisitos necessários para o desenvolvimento:**
 - Definir o modelo de dados no PostgreSQL.
 - Definir serviços para a inserção em batch(usando o arquivo de logs fornecido).
 -  Definir serviços para inserção de logs manuais(CRUD).
 - Implementar filtros ou pesquisas de logs.
 - Testes Unitários.
 
*OBS: Aplicar as boas práticas de programação: o Modelagem em camada. o Programação defensiva. o Tipagem de dados adequada para o banco de dados.*

## DETALHES DO FRONT-END
**Abaixo os requisitos necessários para o desenvolvimento:**
 - Tela para inserção de logs manuais (CRUD).
 - Tela para inserção de logs usando o arquivo modelo.
 - (BÔNUS) Tela para buscar logs feitos por um determinado IP, por hora, user-agent (agregação).

## EXEMPLOS DO ARQUIVO DE LOG:
 - [Link do arquivo](https://github.com/Marlohn/LogChallenge/blob/develop/extras/sample.log)
 
## REQUISITOS DE ENTREGA
 - O código deve ser disponibilizado em um repositório público, nas seguintes opções:
	 - Gitlab 
	 - Github 
	 - Bitbucket
 - O código deve   estar disponível até 23:59 do dia final do prazo;
 - A aplicação deve estar compilando e livre de bugs;
 - Disponibilizar um arquivo readme.txt, contendo uma documentação simplificada, com instruções sobre compilação, ambiente, comentários sobre o desenvolvimento, lógica e padrões utilizados, além de outros dados que considere relevante.