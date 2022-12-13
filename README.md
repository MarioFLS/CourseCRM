# Your Course!

## Descrição
Esse Projeto busca simular o gerenciamento de Curso. Podendo criar  cursos, cadastrar e matricular Estudantes!

## Tecnologias Usadas

> Desenvolvida utilizando: C#, .Net, Entity Framework Core, Razor, Docker, Docker-Compose, SQLServer, CSS, Bootstrap 5. Utilizando o Modelo MVC

# Como Utilizar

## Você pode escolher utilizar Docker ou Não.

<details>
  <summary><strong>🐳 Usando Docker</strong></summary><br />
 
  > Rode o serviço `SQLServer` com o comando `docker-compose up -d`.
  - Lembre-se de parar o `SQLServer` se estiver usando localmente na porta padrão (`1433`), a porta pode ser mudada, mas não é aconselhado que se faça. Isto é falado mais a baixo;

  <br />
  
  ### :warning: Atenção :warning:
  - É de suma importância que você *desabilite* a porta do SQLServer no seu computador antes de rodar a aplicação. Pois eles usaram a mesma porta. Claro que
  
  No Windows você pode fazer pelos *serviços*, parando o SQLServer por lá.
  
  ### :warning: **IMPORTANTE!** :warning:
  - Não mude as portas, isso pode fazer com que você não consiga conectar no banco!
</details>

<details>
  <summary><strong>😀 Sem Docker </strong></summary><br />
 Entre na pasta `Repository` e olhe o arquivo `CourseContext.cs`.
 o método *OnConfiguring* tem as configurações pra coneção com o banco.
 
 ![image](https://user-images.githubusercontent.com/93008789/201788589-efb8ec64-6d2d-424f-b6a6-9a044c61d2e5.png)

  <br />
</details>

# Como Conectar ao Banco

<details>
  <summary><strong>🎲 Conexão com o Banco</strong></summary><br />
 
Utilizando o Docker o banco já estará criado. Sem o docker você precisará ter o SQLServer instalado na sua maquina.
É recomendado o uso do Docker e da ferramenta Azure Data Studio

## :warning: **IMPORTANTE!**

### A senha do Banco é *Password12!*

Você deve ver se o seu banco tem essas crêdenciais

![image](https://user-images.githubusercontent.com/93008789/201788589-efb8ec64-6d2d-424f-b6a6-9a044c61d2e5.png)

#### Comando para subir o Banco

Você precisa ter o `dotnet ef`

Para instalar globalmente use

`dotnet tool install --global dotnet-ef`

Link da documentação da Microsoft: https://learn.microsoft.com/pt-br/ef/core/get-started/overview/install

```C#
# Usado o PowerShell

dotnet ef database update
```

# Usado o Sheel do Visual Studio
```PowerShell

Update-Database
```
</details>


## Iniciando a aplicação

#### Utilize o comando abaixo para iniciar a aplicação
`dotnet run`
Como dito antes, ele irá transpilar o código e iniciar o uso. Não esqueça se for sair dele use `CTRL + C` ou equivalente. Se não a porta ainda será ocupada.
Você pode reiniciar ou derrubar o container, isso resolverá esse problema.

#### Dentro da pasta do projeto:
Use os comandos pra acessar de fato a aplicação:

`cd YourCourse`
`cd CourseCRM`

em seguida atualize o banco de dados.

`dotnet ef database update`
E pronto! O Banco estará pronto para ser usado!

Lembre-se você precisar estar com o docker rodando ou com o SQLServer rodando na sua maquina!


## Estou aqui para Ajudar!
Havendo algum problema. Entre em contato comigo, poderei auxiliar a resolver os problemas!
Isso também vale para dúvidas de funcionamento!
