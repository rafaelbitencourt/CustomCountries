# CustomCountries

Uma API para salvar personalizações de países disponibilizados pela [API Graph Countries](https://github.com/lennertVanSever/graphcountries).
Utilize GraphQL para salvar e consultar os seguintes dados dos países: capital, área, população e densidade populacional.

Todas as alterações feitas na branch master deste respositório são publicadas automaticamente no [Heroku](https://customcountries.herokuapp.com/graphql/), que se conecta a um banco de dados [PostgreSQL](https://www.postgresql.org/), também hospedado no Heroku, para persistência dos dados.


Explore utilizando o [Playground](https://customcountries.herokuapp.com/playground/).

### Exemplo de query

```graphql
query {
  countries{
    numericCode
    capital
    area
    population
    populationDensity    
  }
}
```

### Exemplo de mutation

```graphql
mutation {
  saveCountry (country: {
    numericCode: "076"
    capital: "São Paulo"
    area: 8515767
    population: 206135893
    populationDensity: 24.20638011819722
  })
  {
    numericCode
    capital
    area
    population
    populationDensity
  }
}
```

## Recursos utilizados

* Banco de dados PostgreSQL
* Framework .Net Core 3.1
* Entity Framework
* Hot Chocolate GraphQL

## Como utilizar

Requisitos:
* [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/)
* [Um banco de dados PostgreSQL](https://www.postgresql.org/download/)

Começando:

1. Clone este repositório
2. Informe a String de conexão de seu banco de dados PostgreSQL no arquivo CustomCountries.API\appsettings.json
3. Crie a estrutura no banco com o comando `dotnet ef database update` no CLI do .NET (Este irá criar a tabela `country`, conforme definido em CustomCountries.API\Migrations)
4. Inicie o projeto no Visual Studio
5. Será aberto o browser com o Playground :)
