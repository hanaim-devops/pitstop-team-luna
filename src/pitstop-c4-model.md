<style>
    .mermaid {
        background-color: white;
    }
</style>

# C4 Model PitStop

## Context Diagram

```mermaid
graph TD
    style Manager fill:#ffffff,stroke:#333,stroke-width:2px,color:#000000
    style Monteur fill:#ffffff,stroke:#333,stroke-width:2px,color:#000000
    style PitStop fill:#ffffff,stroke:#333,stroke-width:2px,color:#000000
    style Externe_APIs fill:#ffffff,stroke:#333,stroke-width:2px,color:#000000

    Manager -->|Beheert klant- en voertuiggegevens| PitStop
    Monteur -->|Werkt aan toegewezen taken| PitStop
    PitStop -->|Interageert met externe systemen| Externe_APIs

    Manager[Manager]
    Monteur[Monteur]
    PitStop[System: PitStop]
    Externe_APIs[Externe Systemen]
    
```
## Container

```mermaid
graph TD
    subgraph PitStop
        WebApp[User Interface]
        CustomerManagementAPI[Customer Management API]
        RepairManagementAPI[Repair Management API]
        VehicleManagementAPI[Vehicle Management API]
        NotificationService[Notification Service]
        WorkshopManagementAPI[Workshop Management API]
        InvoiceService[Invoice Service]
        WorkshopManagementEventHandler[Workshop Management EventHandler]

        WebApp --> CustomerManagementAPI
        WebApp --> RepairManagementAPI
        WebApp --> VehicleManagementAPI
        WebApp --> WorkshopManagementAPI
        RepairManagementAPI --> NotificationService
        WorkshopManagementAPI --> NotificationService
        WorkshopManagementAPI --> InvoiceService
        WorkshopManagementAPI --> WorkshopManagementEventHandler
    end

    style PitStop fill:#fff,stroke:#333,stroke-width:2px,color:#000000
    style CustomerManagementAPI fill:#bbf,stroke:#333,stroke-width:1px,color:#000000
    style RepairManagementAPI fill:#bbf,stroke:#333,stroke-width:1px,color:#000000
    style VehicleManagementAPI fill:#bbf,stroke:#333,stroke-width:1px,color:#000000
    style NotificationService fill:#bbf,stroke:#333,stroke-width:1px,color:#000000
    style InvoiceService fill:#bbf,stroke:#333,stroke-width:1px,color:#000000
    style WorkshopManagementAPI fill:#bbf,stroke:#333,stroke-width:1px,color:#000000
    style WorkshopManagementEventHandler fill:#bbf,stroke:#333,stroke-width:1px,color:#000000
    style WebApp fill:#f96,stroke:#333,stroke-width:1px,color:#000000
```

## Component

```mermaid
graph TD
    subgraph RepairManagementAPI
        Controllers[Controllers]
        Commands[Commands]
        DataAccess[DataAccess]
        DTO[DTO]
        Events[Events]
        Migrations[Migrations]
        Model[Model]
        Configuration[Configuration Files]
        Program[Program.cs]
        Database[(Database)]
        
        Program --> Controllers
        Program --> Commands
        Program --> Migrations
        Program --> Configuration
        Controllers --> Commands
        Controllers --> Model
        Controllers --> Events
        Controllers --> DTO
        Migrations --> DataAccess
        DataAccess --> Database

    end

    subgraph NotificationService
        NotificationController[Notification Controller]
        SMSGateway[SMS Gateway]
        EmailGateway[Email Gateway]
        TemplateEngine[Template Engine]

        NotificationController --> SMSGateway
        NotificationController --> EmailGateway
        NotificationController --> TemplateEngine
    end

    subgraph CustomerManagementAPI
        CustomerController[Customer Controller]
        CustomerRepository[Customer Repository]
        VehicleServiceClient[Vehicle Service Client]
        
        CustomerController --> CustomerRepository
        CustomerController --> VehicleServiceClient
    end

    style RepairManagementAPI fill:#fff,stroke:#333,stroke-width:2px,color:#000000
    style Controllers fill:#bbf,stroke:#333,stroke-width:1px,color:#000000
    style Commands fill:#bbf,stroke:#333,stroke-width:1px,color:#000000
    style DataAccess fill:#bfb,stroke:#333,stroke-width:1px,color:#000000
    style DTO fill:#fbb,stroke:#333,stroke-width:1px,color:#000000
    style Events fill:#f9f,stroke:#333,stroke-width:1px,color:#000000
    style Migrations fill:#ff9,stroke:#333,stroke-width:1px,color:#000000
    style Model fill:#9bf,stroke:#333,stroke-width:1px,color:#000000
    style Configuration fill:#f99,stroke:#333,stroke-width:1px,color:#000000
    style Program fill:#9ff,stroke:#333,stroke-width:1px,color:#000000
    style Database fill:#cfc,stroke:#333,stroke-width:1px,color:#000000
    style NotificationService fill:#ccf,stroke:#333,stroke-width:2px
    style CustomerManagementAPI fill:#ccf,stroke:#333,stroke-width:2px

```

[//]: # (## Code)

[//]: # ()
[//]: # (```mermaid)

[//]: # (graph TD)

[//]: # (    subgraph RepairManagementAPI)

[//]: # (        RepairController[RepairController.cs] --> HandleRepairRequest[HandleRepairRequest])

[//]: # (        RepairRepository[RepairRepository.cs] --> SaveRepairOrder[SaveRepairOrder])

[//]: # (        EventPublisher[EventPublisher.cs] --> PublishRepairEvent[PublishRepairEvent])

[//]: # (    end)

[//]: # ()
[//]: # (    subgraph CustomerManagementAPI)

[//]: # (        CustomerRepository[CustomerRepository.cs] --> GetCustomerById[GetCustomerById])

[//]: # (        CustomerRepository --> AddCustomer[AddCustomer])

[//]: # (    end)

[//]: # ()
[//]: # (    subgraph Notification_Service)

[//]: # (        NotificationSender[NotificationSender.java])

[//]: # (    end)

[//]: # ()
[//]: # ()
[//]: # (    style RepairManagementAPI fill:#ccf,stroke:#333,stroke-width:2px)

[//]: # (    style CustomerManagementAPI fill:#ccf,stroke:#333,stroke-width:2px)

[//]: # (    style Notification_Service fill:#ccf,stroke:#333,stroke-width:2px)

[//]: # (```)