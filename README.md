# Oque é?
Projeto com intuito de auxiliar empresas no controle de empréstimos de itens internos para os colabores.

# Qual o impacto?
Diminuir furtos, agilizar processos e miminizar mau-uso do patromonio por parte dos colaboradores.

# Como funciona?
A regra de negócio principal são os equipamentos emprestados para as pessoas. O que é importante ressaltar é que uma pessoa pode ter em sua posse vários equipamentos, porém um equipamento só pode estar sobre posse de apenas pessoa.
## Tela principal
Ao abrir o ControleDePatrimonio serão exibidos todas as movimentações de empréstimo que existem e que ainda não foram finalizadas. Isso será explicado melhor abaixo.

![z1](https://github.com/nathanndos/ControleDePatrimonio/assets/77414867/8e363780-f3ff-43a1-832f-c2ffb8cd1958)

## Equipamentos
Clicando no botão de Equipamentos será aberta uma nova janela mostrando os equipamentos cadastrados, juntamente com as informações individuais de cada um deles.

![z2](https://github.com/nathanndos/ControleDePatrimonio/assets/77414867/a04daf47-aba0-48f6-85ef-9012eaaff604)

Ao clicar em Novo, Editar ou dar duplo click em um registro, será aberta uma janela básica de cadastro de equipamento. Nela poderá ser inserido nome, data de aquisição e um serial de controle interno da empresa. Ao editar, é só clicar em salvar para concluir as alterações.

![z3](https://github.com/nathanndos/ControleDePatrimonio/assets/77414867/9c9a429d-de4e-448e-aa71-551e9893d608)

## Pessoas

Clicando em Pessoas, será aberta uma janela simples de cadastro e pesquisa de pessoas.

![z4](https://github.com/nathanndos/ControleDePatrimonio/assets/77414867/f032f6cc-bdc7-40e4-95e5-dca60449ddee)

## Empréstimos

Na janela de Empréstimos, é aonde serão criadas as movimentações dos equipamentos emprestados as pessoas/colaboradores.

![z5](https://github.com/nathanndos/ControleDePatrimonio/assets/77414867/d3673d2b-1fbb-45b1-b231-de352cf63242)

- Campo Id/Ide: São gerados automaticamente ao gravar a movimentação
- Pessoa: Pessoa que terá a posse do equipamento. Clicar em + abre uma lista das pessoas cadastradas
- Equipamento: Item que será emprestado. Clicar em + abre uma lista de equipamentos cadastrados
- Data Abertura: É gerado automaticamente ao criar uma nova movimentação de empréstimo
- Data Fechamento: É gerado automaticamente com a data atual da finalização do empréstimo, ou seja, ao devolver o item o campo pega a data atual
- Observação: Campo livre para descrever algo sobre a movimentação, como estado do equipamento, motivo do emprestimo, etc

## Histórico
Em histórico, serão exibidas todas as movimentações de empréstimos realizadas até o momento. Existem os filtros de pessoa e equipamento que podem ou não ser preenchidos. Além disso, são exibidas duas grid, aonde a primeira são os empréstimos ativos no momento e abaixo dele são exibidos as movimentações antigas que já foram finalizadas anteriormente 

![z6](https://github.com/nathanndos/ControleDePatrimonio/assets/77414867/0dfcf68b-040c-4c61-890b-b91332390188)
- Ao clicar no + no campo de pessoa ou equipamento, serão exibidas listas dos registros cadastrados
- Duplo clique em algum registro, abrirá o cadastro de empréstimo

