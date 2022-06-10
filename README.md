## RouterFinder
O projeto routerFinder é um projeto que tem como objetivo de gerenciar as rotas e encontrar as rotas com menor custo. 

## Estrutura do projeto
O projeto está estruturado em camadas sendo elas:

### 01 - Camada Web
```
A camada web é a camada front end do projeto. Ela é responsável por receber as requisições do usuário e retornar as respostas.
```
### 02 - Camada Api
```
A camada api é a camada de comunicação com o back end do projeto. Ela é responsável por fazer as requisições para a camada de aplicação.
```
### 03 - Camada Application
```
A camada application é a camada de aplicação do projeto. Nessa camada temos a definição dos DTOS e dos Mappings.
```
### 04 - Camada Domain
```
A camada domain é a camada de domínio do projeto. Nessa camada temos a definição das entidades e dos serviços.
```
### 05 - Camada Infrastructure
```
A camada infrastructure é a camada de infraestrutura do projeto. Nessa camada temos a definição do acesso aos dados e a configuração do contexto e do repositório.
```
### 06 - Camada IoC
```
A camada IoC é a camada de injeção de dependências do projeto. Nessa camada temos a definição das dependências que serão injetadas no projeto.
```

## Como levantar o projeto
 - Restore Nuget Packages
 - Setar o projeto .infra como starttup project
 - Alterar a connection string no arquivo RouterFinderContext.cs no projeto .infra
 - No projeto .infra, executar o comando update-database
 - Executar o projeto com multiples startups
    ```
    Menu Debug -> Set Startup Project -> Select Multiple Startup Projects
    Em action, ativar  RouterFinder.Web e RouterFinder.Api
    ``` 
