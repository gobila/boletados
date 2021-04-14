# Boletados
![](https://img.shields.io/badge/Boletados-60%25-yellowgreen)
## API criada usando o AspNet Core 5.

É uma API simples de consulta e cadastro de pessoas que deveter autenticação e algumas rotas.
A ideia principal é poder acessar uma rota que retorne as pessoas com seus atributos em rotas que tenham autenticação.
Partindo disso é possivel cadastrar cadastrar as contas dessas pessoas e retornar os seus boletos pagos e não pagos

## Proximos passos
1. Concertar token de autenticação
2. Criar controler de contas
2. Banco de dados
    1. Criar
    2. Conectar
3. Terminar front-end
4. Rodar testes

## Situação atual
Com os problemas no token de autenticação, foi nescessario remover o atributo [Authorize] do controller para que as rotas funcionem.
Ainda é nescessario criar o banco de dados e mudar os tipos dos campos.
