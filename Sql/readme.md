## Desafio proposto
Uma consulta que traga as informações de contas a pagar e contas pagas, sendo que ele precisa do número do processo de pagamento, nome do fornecedor, data de vencimento, data de pagamento, valor líquido e um identificador se é conta a pagar ou paga.
Dado a requisição acima, o sistema trabalha com duas tabelas uma para armazenar as contas a pagar e outra para armazenar as contas pagas, o número do processo de pagamento é único entre as tabelas, e o cliente precisa que essa informação venha em uma única consulta. Segue MER abaixo, das tabelas necessárias.

![Captura de tela de 2021-04-14 11-40-25](/assets/Captura%20de%20tela%20de%202021-04-14%2011-40-25.png)

## Solução
Essa desafio pode ser simplificado para usar uma única tabela no banco de dados e gerar views diferentes, entretanto essa solução pode esbarrar em alguma regra de negocio. Assim é necessário que se crie um método no sistema para validar a mudança de tabela prevenindo que exista contas duplicadas.
Dessa forma existem duas possível soluções uma usando JOIN e outra usando UNION, acredito que nesse caso o ideal seria fazer usar o Join para gerar as view, alterando o nome de campos para identificar de qual tabela vem o dado.

### Usando JOIN
SELECT Pessoas.Nome, contasPagas.Numero as CodPago, contasAPagar.Numero as CondNaoPago 
FROM Pessoas,ContasAPagar, ContasPagas 
WHERE Pessoas.ID = contasPagas.CodigoFornecedor OR Pessoas.ID = ContasAPagar.CodigoFornecedor 
OUTER JOIN Pessoas.id on ContasAPagar.CodigoFornecedor AND contasPagas.CodigoFornecedor


### Usando UNION
SELECT Numero, CodigoFornecedor, dataPagamento, dataVencimento, valor, Pessoas.Nome 
    FROM( 
        SELECT Numero, CodigoFornecedor, dataPagamento, dataVencimento, valor FROM contasPagas WHERE CodigoFornecedor = Pessoas.id 
        UNION 
        SELECT Numero, CodigoFornecedor,dataPagamento, dataVencimento, valor FROM contasAPagas WHERE CodigoFornecedor = Pessoas.id
    ) GROUP BY Numero



