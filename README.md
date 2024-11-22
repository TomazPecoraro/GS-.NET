# **GS.NET**

## **Descrição da Arquitetura**
O projeto é uma **API monolítica** desenvolvida com **ASP.NET Core Web API**, estruturada de forma modular para garantir organização e facilidade de manutenção.

### **Estrutura do Projeto**

### **Controllers**
Gerenciam as requisições HTTP e direcionam as operações para os serviços correspondentes.
- **UsuarioController**: Gerencia as operações relacionadas a usuários.
- **AparelhoController**: Gerencia as operações de cadastro e consulta de aparelhos.
- **ConsumoController**: Lida com os dados de consumo energético.
- **PrecoController**: Controla as operações relacionadas a preços.
- **AlertaController**: Gerencia alertas e notificações.

---

### **Models**
Define as entidades e os DTOs utilizados pela aplicação.
- **Usuario**: Representa os usuários do sistema.
- **Aparelho**: Modela os aparelhos cadastrados.
- **Consumo**: Contém informações de consumo energético.
- **Preco**: Representa preços de energia e outras tarifas.
- **Alerta**: Modela notificações e alertas gerados pelo sistema.

---

### **Services**
Contém a lógica de negócios, implementando funcionalidades específicas de cada domínio.
- **UsuarioService**
- **AparelhoService**
- **ConsumoService**
- **PrecoService**
- **AlertaService**

---

### **Repositories**
Implementam o padrão **Repository**, encapsulando o acesso ao banco de dados.
- **UsuarioRepository**
- **AparelhoRepository**
- **ConsumoRepository**
- **PrecoRepository**
- **AlertaRepository**

---

### **Config**
Gerencia configurações do projeto.
- **AppConfiguration**: Configuração do Swagger e banco de dddos para documentação da API.

---

### **Tests**
Testes automatizados utilizando **xUnit** e **Moq**.
- **UsuarioServiceTests**
- **AparelhoServiceTests**
- **ConsumoServiceTests**
- **AlertaServiceTests**
- **PrecoServiceTests**

1. **Executar Testes Automatizados:**
   - Para rodar os testes automatizados, use o comando:
     ```bash
     dotnet test
     ```

### Exemplos de Uso

- Testes de Integração das Entidades Anuncio, Campanha e Usuario
- Teste da Camada Service de cada Classe
- Utilização do Swagger para teste de todos os EndPoint e Operações CRUD

---

## **Design Patterns Utilizados**

1. **Repository Pattern**: Encapsula o acesso ao banco de dados, facilitando alterações no provedor de dados.
2. **Dependency Injection**: Promove baixo acoplamento e facilita a troca e o teste de dependências.
3. **Singleton Pattern**: Utilizado em configurações globais, como a configuração de segurança e o Swagger.

---

### **Configuração da API**

#### **Pré-requisitos**
- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- [Oracle Database](https://www.oracle.com/database/)
- [Postman](https://www.postman.com/downloads/) ou navegador para acessar o Swagger.

#### **Configuração do Banco de Dados**
1. Configure o banco Oracle conforme as instruções fornecidas pela Oracle.
2. Atualize a string de conexão no arquivo `appsettings.json`:
   ```json
   "ConnectionStrings": {
       "OracleFIAP": "Data Source=seu_host:1521/seu_serviço;User ID=seu_usuario;Password=sua_senha;"
   }

---

### Instalação

1. **Clone o Repositório:**
   - Clone o repositório para o seu ambiente local usando o seguinte comando:
     ```bash
     git clone https://github.com/TomazPecoraro/GS.NET.git
     ```
   - Navegue para o diretório do projeto:
     ```bash
     cd GS.NET
     ```

2. **Restaure as Dependências:**
   - Execute o comando para restaurar as dependências do projeto:
     ```bash
     dotnet restore
     ```
---

### Execução

1. **Rodar a API:**
   - Use o seguinte comando para rodar a API localmente:
     ```bash
     dotnet run --project JJSolution.API/JJSolution.API.csproj
     ```
   - A API estará disponível em `https://localhost:5031` por padrão.

2. **Acessar a Documentação da API:**
   - A documentação Swagger pode ser acessada navegando para:
     ```markdown
     http://localhost:5031/swagger/index.html
     ```

#### Requisição GET de todas a entidades

```bash
http://localhost:5031/swagger/index.html
```

---

### **Práticas de Clean Code**
O código segue os princípios de SOLID e boas práticas de organização e nomeação, garantindo:

- Manutenção simplificada.
- Redução do acoplamento.
- Escalabilidade do sistema.

---

### **Modelo ML**

Fizemos um modelo de previsão de dados que retorna o quanto é gasto de energia de acordo com o dispositivo, segue abaixo o link do Dataset.

#### 1. Previsão de Gasto de Energia
- **Objetivo** : Estimar o quantidade de energia gasta de um dispositivo com base em dados anteriores.
- **Como Funciona**: O modelo usa dados históricos para prever a energia gasta.

#### 2. Simplicidade e Integração

- **Objetivo**: Permitir o uso fácil das previsões de impressões diretamente na API.
- **Como Funciona**: A API disponibiliza um endpoint onde o usuário pode enviar os dados da campanha e receber a previsão de impressões, sem complexidades adicionais.
  ```markdown
     http://localhost:5025/swagger/predict
     ```

#### Link Dataset
https://www.kaggle.com/datasets/antoinelebrundu13/household-appliances-consumption

---

### **Integrantes do Grupo**

- Tomaz de Oliveira Pecoraro – RM98499
- Rennan Ferreira da Cruz – RM99364
- Jaisy Cibele Alves – RM552269
- Luiz Felipe Camargo Prendin – RM552475
- Gabriel Amâncio – RM97936
