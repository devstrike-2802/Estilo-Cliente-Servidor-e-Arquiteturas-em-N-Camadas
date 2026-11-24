# Garagem de Veículos — Tema 5

Implementação prática do estilo Cliente-Servidor e arquitetura em N camadas, em C#/.NET 8. O cliente Console e a API ASP.NET Core são projetos separados.

## Integrante
- Matheus Araújo Silva

## Arquitetura
- Cliente: Console C# que consome a API via HTTP/JSON.
- API: Controllers (MVC) recebem requisições.
- Service: valida os dados e coordena operações.
- Repository: abstrai e executa persistência.
- Dados: arquivo JSON.
- DI: registro das dependências no Program.cs da API.

Diagramas estão em `Diagramas/arquitetura.md`.

## Requisitos
.NET 8 SDK.

## Executar
1. Abra dois terminais na raiz do repositório.
2. No primeiro, execute:
   ```bash
   cd GaragemAPI
   dotnet restore
   dotnet run --urls http://localhost:5080
   ```
3. No segundo, execute:
   ```bash
   cd GaragemCliente
   dotnet run
   ```
4. Opcional: abra `http://localhost:5080/swagger` para consultar e testar endpoints.

## Funcionalidades
Listar, buscar, cadastrar, atualizar e excluir veículos.

## Ferramentas
C#, ASP.NET Core, .NET 8, Swagger, JSON, Mermaid e GitHub.

## Uso de IA
ChatGPT foi utilizado como apoio na organização da estrutura, elaboração inicial dos códigos e documentação. O conteúdo deve ser revisado e testado pelos integrantes.
