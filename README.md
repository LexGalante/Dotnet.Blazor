# Dotnet.Blazor
Projeto exemplo com uso de Blazor Server Side

## Como executar
- Crie uma base de dados Sql server com nome de blazor
- Execute o script contido na pasta <PASTA_PROJETO>\src\Dotnet.Blazor.Infra\Scripts\CreateTableCustomer.sql
```
USE [blazor]
GO

CREATE TABLE [dbo].[customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[last_name] [varchar](150) NOT NULL,
	[address] [varchar](250) NOT NULL,
 CONSTRAINT [pk_customer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
```
- No visual studio basta executar a aplicação
- Via linha de comando va ate a pasta <PASTA_PROJETO>\src\Dotnet.Blazor.Application e execute o comando
```
dotnet run
```
- No navegador va ate a url http://localhost:5000/
