# Boletados
![](https://img.shields.io/badge/Boletados-60%25-yellowgreen)
## API criada usando o AspNet Core 5.
É uma API simples de consulta e cadastro de pessoas que deve ter autenticação e algumas rotas.
A ideia principal é poder acessar uma rota que retorne as pessoas com seus atributos em rotas que tenham autenticação.
Partindo disso é possível cadastrar cadastrar as contas dessas pessoas e retornar os seus boletos pagos e não pagos.

## Rotas da API
| Função                | Rota                          | Cool  |
|:----------------------|:-----------------------------:|------:|
| Todos os dados        | api/Boletados                 | $1600 |
| Dados idividuais      | api/Boletados/{id}            |   $12 |
| buscar por UF         | api/Boletados/UF/{uf}         |    $1 |
| Cadastro de dados     | api/Boletados/cadastro        |    $1 |
| Atualizar Cadastro    | api/Boletados/update/{id}     |    $1 |
| Deletar Cadastro      | api/Boletados/delete/{id}     |    $1 |
| Autenticar usuarios   | api/Boletados/login           |    $1 |
| Lista de ususarios    | api/Boletados/user            |    $1 |


## Proximos passos
1. Concertar token de autenticação
2. Criar controler de contas
2. Banco de dados
    1. Criar
    2. Conectar
3. Terminar front-end
4. Rodar testes

## Situação atual
Com os problemas no token de autenticação, foi necessário remover o atributo [Authorize] do controller para que as rotas funcionem.
Ainda é necessário criar o banco de dados e mudar os tipos dos campos.
