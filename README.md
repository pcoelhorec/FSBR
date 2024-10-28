>>> Ajustar no arquivo "appsettings.Json" a ConnectionString com os dados de conexão do servidor Sql Server que será utilizado.

    Ex:  "DefaultConnection": "Server={SERVIDOR SQL};Database={DATABASE_NAME};User id={USER_ID};Password={PASSWORD};TrustServerCertificate=true;"

>>> Os scripts para criação do Banco de Dados (Script_banco.sql) e Tabela (Script_tabela.sql);

    > No script do banco de dados ajustar o Nome da Base e caminhos que melhor lhe convier

   CREATE DATABASE [FSBR]
   CONTAINMENT = NONE
   ON  PRIMARY 
  ( NAME = N'FSBR', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.DBSQL\MSSQL\DATA\FSBR.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
   LOG ON 
  ( NAME = N'FSBR_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.DBSQL\MSSQL\DATA\FSBR_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
   WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
  GO
