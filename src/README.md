<style>
    .mermaid {
        background-color: white;
    }
</style>

# C4 Model PitStop

## Context Diagram

```mermaid
graph TD
    style Manager fill:#bbf,stroke:#333,stroke-width:1px,color:#000000
    style Monteur fill:#bbf,stroke:#333,stroke-width:1px,color:#000000
    style PitStop fill:#bbf,stroke:#333,stroke-width:1px,color:#000000
    style Externe_APIs fill:#bbf,stroke:#333,stroke-width:1px,color:#000000
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
        RepairManagementControllers[Controllers]
        RepairManagementCommands[Commands]
        RepairManagementDataAccess[DataAccess]
        RepairManagementDTO[DTO]
        RepairManagementEvents[Events]
        RepairManagementMigrations[Migrations]
        RepairManagementModel[Model]
        RepairManagementConfiguration[Configuration Files]
        RepairManagementProgram[Program.cs]
        RepairManagementDatabase[(Database)]

        RepairManagementProgram --> RepairManagement
        RepairManagementProgram --> RepairManagementMigrations
        RepairManagementProgram --> RepairManagementConfiguration
        RepairManagementControllers --> RepairManagementCommands
        RepairManagementControllers --> RepairManagementEvents
        RepairManagementControllers --> RepairManagementDTO
        RepairManagementControllers --> RepairManagementModel
        RepairManagementMigrations --> RepairManagementModel
        RepairManagementMigrations --> RepairManagementDataAccess
        RepairManagementDataAccess --> RepairManagementDatabase

    end

    subgraph NotificationService
        NotificationChannels[Notification Channels]
        NotificationServiceEmailNotifier[Email Notifier]
        NotificationServiceSlackMessenger[Slack Messenger]
        NotificationServiceEvents[Events]
        NotificationServiceModel[Model]
        NotificationServiceTemplates[Slack Templates]
        NotificationServiceProgram[Program.cs]
        NotificationServiceWorker[Program.cs]
        NotificationServiceRepository[(Database)]
        NotificationServiceProgram-->NotificationServiceWorker
        NotificationServiceWorker --> NotificationChannels
        NotificationServiceWorker --> NotificationServiceEvents
        NotificationServiceWorker --> NotificationServiceModel
        NotificationServiceWorker --> NotificationServiceRepository
        NotificationChannels --> NotificationServiceEmailNotifier
        NotificationChannels --> NotificationServiceSlackMessenger
        NotificationServiceSlackMessenger --> NotificationServiceTemplates
    end


    style RepairManagementAPI fill:#fff,stroke:#333,stroke-width:2px,color:#000000
    style RepairManagementControllers fill:#bbf,stroke:#333,stroke-width:1px,color:#000000
    style RepairManagementCommands fill:#bbf,stroke:#333,stroke-width:1px,color:#000000
    style RepairManagementDataAccess fill:#bfb,stroke:#333,stroke-width:1px,color:#000000
    style RepairManagementDTO fill:#fbb,stroke:#333,stroke-width:1px,color:#000000
    style RepairManagementEvents fill:#f9f,stroke:#333,stroke-width:1px,color:#000000
    style RepairManagementMigrations fill:#ff9,stroke:#333,stroke-width:1px,color:#000000
    style RepairManagementModel fill:#9bf,stroke:#333,stroke-width:1px,color:#000000
    style RepairManagementConfiguration fill:#f99,stroke:#333,stroke-width:1px,color:#000000
    style RepairManagementProgram fill:#9ff,stroke:#333,stroke-width:1px,color:#000000
    style RepairManagementDatabase fill:#cfc,stroke:#333,stroke-width:1px,color:#000000
    style NotificationService fill:#fff,stroke:#333,stroke-width:2px,color:#000000
    style NotificationChannels fill:#bbf,stroke:#333,stroke-width:1px,color:#000000
    style NotificationServiceEmailNotifier fill:#bfb,stroke:#333,stroke-width:1px,color:#000000
    style NotificationServiceSlackMessenger fill:#fbb,stroke:#333,stroke-width:1px,color:#000000
    style NotificationServiceEvents fill:#f9f,stroke:#333,stroke-width:1px,color:#000000
    style NotificationServiceModel fill:#9bf,stroke:#333,stroke-width:1px,color:#000000
    style NotificationServiceTemplates fill:#ff9,stroke:#333,stroke-width:1px,color:#000000
    style NotificationServiceProgram fill:#9ff,stroke:#333,stroke-width:1px,color:#000000
    style NotificationServiceRepository fill:#cfc,stroke:#333,stroke-width:1px,color:#000000
    style NotificationServiceWorker fill:#bbf,stroke:#333,stroke-width:1px,color:#000000
    
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