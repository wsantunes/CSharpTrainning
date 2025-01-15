# Csharp Trainning

Projeto desenvolvido com Backend e C# e FrontEnd em Blazor.
Inicialmente a versão 1 faz Insert, update e delete com informações basicas de um cadastro de usuários, usando como banco de dados o SQL Server.

Esse template está sendo criado para fins academicos, utilizando as melhores praticas.

Para esse projeto Contamos com uma **Core Web API**, usando os seguintes packages.
>- Microsoft.EntityFrameworkCore.SqlServer  (Aqui eu usei a versão 8)
>- Microsoft.EntityFrameworkCore.Tools      (Aqui eu usei a versão 8)

E uma aplicação **Blazor (FrontEnd)**, usando os seguinte packages.
>- Microsoft.EntityFrameworkCore.SqlServer  (Aqui eu usei a versão 8)
>- Microsoft.EntityFrameworkCore.Tools      (Aqui eu usei a versão 8)

**Importante:**\
 Após a Criação do codigo de manipulação dos dados, é possível  criar o banco de forma automatica abrindo o "Packet Manager Console"
  - Criar o pacote de migração usando o comando\
    ` PM> add-migration FirstMigration`
  - Após isso utilize o comando abaixo para gerar as tabelas no banco de dados em que estiver conectado pela aplicação.\
     `PM> update-database`\\
 
  Ao criar O back e o front end, não esquecer de ir no Solution Propertyes Pages e selecionar para inicializar multiplos projetos.
  ![CsharpTrainning - 1](https://github.com/user-attachments/assets/ff34ea43-3c82-464a-a317-9cce5b72edc0)

## Referências
Vídeo com toda a explicação do conteudo: [Grud Operations using Blazor Web Assembly](https://www.youtube.com/watch?v=mIVCNh_xjgY)
