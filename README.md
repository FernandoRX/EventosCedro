# EventosCedro

Sistema desenvolvido para gerenciar eventos e seus participantes.

## Baixando o projeto

### Requisitos
Os seguites softwares devem estar instalados: 
   - [DotNet SDK](https://www.microsoft.com/en-us/download/details.aspx?id=15354) para execução no Prompt de comando.
   - [MySql Server](https://dev.mysql.com/downloads/mysql/) para o banco de dados.
   - [Visual Studio 2017](https://www.visualstudio.com/pt-br/downloads/?rr=https%3A%2F%2Fwww.google.com.br%2F) como editor de texto (pode ser substituído por outro de sua preferência)

Baixe o projeto :
```bash
$ git clone <https://github.com/FernandoRX/EventosCedro.git>
```

## Configurando a solução 

### Criando o banco de dados
No seu Workbench execute o comando:

```bash
CREATE DATABASE eventoscedro
```

### Fazendo conexão com o banco 
No seu editor de texto, no projeto Server.App vá para a classe Startup nela modifique o serviço:

```bash
services.AddDbContext<MigrationDbContext>(options =>
			options.UseMySql("server=localhost;userid=root;password=root;database=eventoscedro;"));
```

Substitua os campos "userid" e o "password" para os seus, configurados no seu MySQL.

### Atualizando o banco com as migrations
Com a janela do PowerShell dentro da pasta Server.Dal execute o comando:

```bash
dotnet ef database update -c MigrationDbContext -s ..\Server.App\Server.App.csproj
```

### Editando a ConnectionString
No seu editor de texto, novamente no projeto Server.app , abra a pasta Properties no arquivo lauch.Setttings.json modifique a variável de ambiente:

```bash
"ConnectionString": "server=localhost;userid=root;password=root;database=eventoscedro;"
```

Substitua os campos "userid" e o "password" para os seus, configurados no seu MySQL.

## Executando o projeto 

Com a janela do PowerShell dentro da pasta Server.App execute o comando:

```bash
dotnet run 
```

## Rotas

A solução conta com as sequintes rotas:

- api/Eventos
- api/Participantes

Todas possuem as ações: 
 - GET : Retorna todos os objetos .
 - GET{id} : Retorna um objeto filtrado .
 - POST  : Adiciona um novo objeto .
 - PUT{id} : Edita um objeto caso ele exista .
 - DELETE{id} : Deleta um objeto caso ele exista .




 
 


