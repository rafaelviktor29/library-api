# library-api
#### Gestão de Livraria - Desafio Prático Rocketseat
Este projeto é uma Web API para o gerenciamento de uma livraria, desenvolvida como parte de um [desafio prático da Rocketseat.](https://efficient-sloth-d85.notion.site/Desafio-pr-tico-Gest-o-de-Livraria-fd25d644de1c4c8496c444d867c12178)

A abordagem inicial adotada para o desenvolvimento foi focar na lógica de negócio sem a dependência de um banco de dados externo. Para isso, os dados dos livros são mocados e persistidos localmente em um arquivo .csv. Isso permite que o desenvolvimento da API e de seus endpoints seja feito de forma ágil e isolada, sem a necessidade de configurar e manter uma base de dados real durante a fase inicial do projeto.

Com essa solução, é possível demonstrar o funcionamento completo da API, validando cada endpoint, enquanto se prepara a aplicação para uma futura integração com um banco de dados real.

## Instalação
### 1. Clonar o Repositório
```Bash
git clone https://github.com/rafaelviktor29/library-api.git
```

### 2. Navegar até a Pasta do Projeto
```Bash
cd library-api
```

### 3. Restaurar as Dependências (.csproj)
```Bash
dotnet restore
```

### 4. Compilar o Projeto
```Bash
dotnet build
```
### 5. Executar o Projeto
```Bash
dotnet run
```
