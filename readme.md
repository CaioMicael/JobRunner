# Job Runner – External API Scheduler

## Visão Geral

Este projeto implementa um **Job Scheduler genérico** capaz de executar tarefas recorrentes que **consomem APIs externas**, processam os dados retornados e realizam persistência de forma **performática, desacoplada e escalável**.

O foco do projeto **não é uma API específica**, mas sim a **arquitetura de execução de jobs**, permitindo que qualquer API externa seja integrada desde que siga um contrato bem definido.

O projeto foi pensado como um **laboratório prático de arquitetura backend**, simulando problemas reais encontrados em sistemas de produção.

---

## Objetivos do Projeto

- Criar um **scheduler de jobs recorrentes**
- Executar jobs em intervalos configuráveis (ex: a cada 30 segundos)
- Consumir **APIs externas de forma desacoplada**
- Processar dados retornados (validação e deduplicação)
- Persistir dados em banco
- Executar múltiplas instâncias do mesmo job em paralelo
- Medir tempo de execução e performance
- Registrar logs detalhados em arquivos TXT
- Evoluir a solução de forma incremental e sustentável

---

## Motivação

Em sistemas reais, é comum a necessidade de:

- sincronizar dados entre sistemas
- consumir APIs de terceiros
- executar tarefas em background
- processar grandes volumes de dados periodicamente
- lidar com concorrência, performance e idempotência

Este projeto simula esse cenário, focando mais na **qualidade da arquitetura e separação de responsabilidades** do que em regras de negócio específicas.

---

## Arquitetura Geral

A arquitetura é baseada em **orquestração centralizada em um Job Service**, com responsabilidades bem definidas e desacopladas.

### Fluxo conceitual:

Job Scheduler
↓
Job Service (Orquestrador)
├─ External API Consumer
├─ Data Validator
├─ Persistence Layer
└─ Logging / Metrics


O **Job Service** atua como um maestro, coordenando todas as etapas do fluxo sem que as camadas inferiores conheçam regras de negócio ou persistência.

---

## Componentes da Arquitetura

### Job Scheduler

Responsável por:
- Definir a periodicidade de execução dos jobs
- Disparar múltiplas execuções simultâneas
- Controlar concorrência em alto nível

---

### Job Service (Orquestrador)

Responsável por:
- Orquestrar o fluxo completo do job
- Controlar a execução das etapas
- Medir tempo de execução
- Decidir quando persistir ou descartar dados
- Interromper o fluxo em caso de falhas
- Centralizar logs e métricas

---

### External API Consumer

Responsável apenas por:
- Consumir APIs externas via HTTP
- Desserializar respostas JSON em DTOs
- Encapsular detalhes de comunicação externa

Não possui responsabilidade de:
- validar regras de negócio
- persistir dados
- tratar duplicidade

Cada API externa implementa um contrato genérico, permitindo que o Job Runner consuma diferentes fontes de dados sem acoplamento.

---

### Data Validator

Responsável por:
- Validar dados retornados pelas APIs
- Garantir integridade mínima
- Evitar processamento de dados duplicados
- Preparar os dados para persistência

---

### Persistence Layer

Responsável por:
- Persistir dados processados no banco
- Garantir idempotência
- Isolar regras de acesso a dados
- Abstrair o banco de dados do Job Service

---

### Logging & Metrics

Responsável por:
- Registrar logs em arquivos TXT
- Medir tempo de execução de cada etapa
- Auxiliar na análise de performance
- Facilitar troubleshooting
- Usado durante todo o processo


---

## Desafios Técnicos Trabalhados

- Concorrência e execução paralela de jobs
- Performance no consumo de APIs
- Separação clara de responsabilidades
- Uso de interfaces e generics
- Idempotência no processamento de dados
- Logging e métricas de execução
- Arquitetura orientada à orquestração