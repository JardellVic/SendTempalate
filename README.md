# Meu Sistema de Envio de Templates

🚀 **Versão 1.1 - Lançamento!**

Este repositório contém o código do meu sistema de envio de templates personalizados, que facilita a comunicação com clientes através da integração com uma base de dados e a API da **Gupshup** para envio via **WhatsApp**. A versão 1.1 traz melhorias significativas para otimizar a comunicação, aprimorar a geração de relatórios e fornecer uma melhor experiência de usuário (UX).

## 📊 Funcionalidades Principais

- **Coleta de Dados**: Integração com um ERP terceirizado para capturar informações de clientes e suas compras.
- **Filtros Personalizados**: Implementação de filtros para garantir que os templates sejam enviados conforme o perfil de cada cliente.
- **Registro de Atividades**: Armazenamento de informações sobre quem gerou e enviou cada template, proporcionando rastreabilidade das ações.
- **Controle de Edições**: Histórico das planilhas já editadas por cada usuário, promovendo organização e controle.
- **Relatórios de Retorno**: Geração de relatórios para análise dos templates enviados e melhoria contínua.
- **Interface Amigável**: Interface criada com **UserControls**, garantindo uma experiência de uso intuitiva e responsiva, com ajuda integrada.

## 🚀 Tecnologias Utilizadas

- **Linguagem**: C# com WPF (Windows Presentation Foundation)
- **Design**: **MaterialDesignThemes** para uma interface moderna e responsiva.
- **Dependências**:
  - [ClosedXML](https://github.com/ClosedXML/ClosedXML) - Manipulação de arquivos Excel.
  - [EPPlus](https://github.com/EPPlusSoftware/EPPlus) - Leitura e gravação de arquivos Excel.
  - [MaterialDesignThemes](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit) - Biblioteca de design para WPF.
  - [Newtonsoft.Json](https://www.newtonsoft.com/json) - Manipulação de JSON.
  - [Npgsql](https://github.com/npgsql/npgsql) - Driver .NET para PostgreSQL.
  - [System.Data.SqlClient](https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient) - Acesso a bases de dados SQL Server.

## 🚧 Próximos Passos

A próxima atualização do projeto será a implementação de um **sistema de CRM** utilizando a API da **Gupshup** para gerenciamento de conversas via WhatsApp, permitindo uma gestão de relacionamento mais eficaz.

## 📦 Instalação

1. Clone o repositório:

   ```bash
   git clone https://github.com/JardellVic/SendTemplate
   ```

2. Instale as dependências do projeto utilizando **NuGet**:

   ```bash
   dotnet restore
   ```

3. Configure as strings de conexão e API da Gupshup no arquivo `appsettings.json` ou diretamente no código.

4. Compile o projeto:

   ```bash
   dotnet build
   ```

5. Execute o sistema:

   ```bash
   dotnet run
   ```

## 📞 Contato

Se você tiver interesse em discutir mais sobre o projeto ou tiver dúvidas sobre o seu funcionamento, sinta-se à vontade para entrar em contato!

---

Obrigado por conferir este projeto! 😊
