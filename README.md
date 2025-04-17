# FinX Patient Management API

API REST desenvolvida para o desafio da Fin-X, com objetivo de gerenciar pacientes e seus históricos médicos, seguindo boas práticas de arquitetura, clean code e SOLID.

---

## ✨ Tecnologias Utilizadas

- .NET 7
- SQL Server
- Dapper
- Swagger (Documentação da API)
- Postman (testes)

---

## ⚖️ Arquitetura

O projeto segue o padrão Clean Architecture:

```
FinX.PatientManagement
├── FinX.Domain            # Entidades e interfaces
├── FinX.Application       # DTOs e serviços (casos de uso)
├── FinX.Infrastructure    # Repositórios e integrações externas
├── FinX.API               # Controllers, JWT e configuração da API
```

---

## 🔧 Como Executar

1. Clone o repositório:
```bash
git clone https://github.com/seu-usuario/finx-patient-api.git
```

2. Crie o banco de dados:
```sql
CREATE DATABASE FinXDb;
GO

USE FinXDb;
GO

CREATE TABLE Pacientes (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    CPF NVARCHAR(14) NOT NULL UNIQUE,
    DataNascimento DATE NOT NULL,
    Contato NVARCHAR(100)
);

CREATE TABLE HistoricoMedico (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    PacienteId UNIQUEIDENTIFIER NOT NULL,
    Diagnostico NVARCHAR(500),
    ExamesRealizados NVARCHAR(MAX),
    Prescricao NVARCHAR(MAX),
    DataRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Historico_Paciente FOREIGN KEY (PacienteId)
        REFERENCES Pacientes(Id) ON DELETE CASCADE
);
```

3. Configure a connection string no `appsettings.json`:
```json
"ConnectionStrings": {
  "Default": "Server=localhost;Database=FinXDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

4. Execute a aplicação com o Visual Studio ou CLI:
```bash
dotnet run --project FinX.API
```

---

## 🔍 Endpoints Disponíveis

### Pacientes
- `GET /api/pacientes`
- `GET /api/pacientes/{id}`
- `POST /api/pacientes`
- `PUT /api/pacientes/{id}`
- `DELETE /api/pacientes/{id}`
- `GET /api/pacientes/{cpf}/exames`

### Histórico Médico
- `GET /api/historicomedico/paciente/{pacienteId}`
- `GET /api/historicomedico/{id}`
- `POST /api/historicomedico`
- `PUT /api/historicomedico/{id}`
- `DELETE /api/historicomedico/{id}`

---

## 📊 Documentação via Swagger

Acesse em: `https://localhost:5001/swagger`

---

## 📥 Testes via Postman

Use o arquivo:

**FinX_Patient_Management_API.postman_collection.json**

Importe no Postman e edite os valores como `{{base_url}}`, `{{id}}`, etc.

---

## 🌟 Boas práticas adotadas

- Clean Architecture
- SOLID
- Dapper para consultas performáticas
- Validações básicas e tratamento de erros
- Controllers leves, regras nos services



