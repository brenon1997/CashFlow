# CashFlow
 
## Sobre o projeto

Esta **API**, desenvolvida utilizando **.NET 8**, adota os princ�pios do **Domain-Driven Design (DDD)** para oferecer uma solu��o estruturada e eficaz no gerenciamento de despesas pessoais. O principal objetivo � permitir que os usu�rios registrem suas despesas, detalhando informa��es como t�tulo, data e hora, descri��o, valor e tipo de pagamento, com os dados sendo armazenados de forma segura em um banco de dados **MySQL**.

A arquitetura da **API** baseia-se em **REST**, utilizando m�todos **HTTP** padr�o para uma comunica��o eficiente e simplificada. Al�m disso, � complementada por uma documenta��o **Swagger**, que proporciona uma interface gr�fica interativa para que os desenvolvedores possam explorar e testar os endpoints de maneira f�cil.

Dentre os pacotes NuGet utilizados, o **AutoMapper** � o respons�vel pelo mapeamento entre objetos de dom�nio e requisi��o/resposta, reduzindo a necessidade de c�digo repetitivo e manual. O **FluentAssertions** � utilizado nos testes de unidade para tornar as verifica��es mais leg�veis, ajudando a escrever testes claros e compreens�veis. Para as valida��es, o **FluentValidation** � usado para implementar regras de valida��o de forma simples e intuitiva nas classes de requisi��es, mantendo o c�digo limpo e f�cil de manter. Por fim, o **EntityFramework** atua como um ORM (Object-Relational Mapper) que simplifica as intera��es com o banco de dados, permitindo o uso de objetos .NET para manipular dados diretamente, sem a necessidade de lidar com consultas SQL.

![hero-image]

### Features

- **Domain-Driven Design (DDD)**: Estrutura modular que facilita o entendimento e a manuten��o do dom�nio da aplica��o.
- **Testes de Unidade**: Testes abrangentes com FluentAssertions para garantir a funcionalidade e a qualidade.
- **Gera��o de Relat�rios**: Capacidade de exportar relat�rios detalhados para **PDF e Excel**, oferecendo uma an�lise visual e eficaz das despesas.
- **RESTful API com Documenta��o Swagger**: Interface documentada que facilita a integra��o e o teste por parte dos desenvolvedores.

### Constru�do com

![badge-dot-net]
![badge-windows]
![badge-visual-studio]
![badge-mysql]
![badge-swagger]

## Getting Started

Para obter uma c�pia local funcionando, siga estes passos simples.

### Requisitos

* Visual Studio vers�o 2022+ ou Visual Studio Code
* Windows 10+ ou Linux/MacOS com [.NET SDK][dot-net-sdk] instalado
* MySql Server

### Instala��o

1. Clone o reposit�rio:
    ```sh
    git clone https://github.com/brenonPerez/CashFlow.git
    ```

2. Preencha as informa��es no arquivo `appsettings.Development.json`.
3. Execute a API e aproveite o seu teste :)



<!-- Links -->
[dot-net-sdk]: https://dotnet.microsoft.com/en-us/download/dotnet/8.0

<!-- Images -->
[hero-image]: images/heroimage.png

<!-- Badges -->
[badge-dot-net]: https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=fff&style=for-the-badge
[badge-windows]: https://img.shields.io/badge/Windows-0078D4?logo=windows&logoColor=fff&style=for-the-badge
[badge-visual-studio]: https://img.shields.io/badge/Visual%20Studio-5C2D91?logo=visualstudio&logoColor=fff&style=for-the-badge
[badge-mysql]: https://img.shields.io/badge/MySQL-4479A1?logo=mysql&logoColor=fff&style=for-the-badge
[badge-swagger]: https://img.shields.io/badge/Swagger-85EA2D?logo=swagger&logoColor=000&style=for-the-badge