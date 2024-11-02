# Architectural Decision Record

In dit document worden de architectuur-significante beslissingen en bijbehorende overwegingen beschreven. Hierin wordt het probleem dat zich voordeed, de gekozen oplossing, de overwogen alternatieven, en de argumenten voor de uiteindelijke keuze gedocumenteerd.

**Legenda:**

| Status     | Betekenis                                                                                                                      | Actie     |
|------------|---------------------------------------------------------------------------------------------------------------------------------|-----------|
|🟦 **TENTATIVE**  | De gemaakte (wijzigingen aan een) Architectural Decision Record word(en) voorgesteld, tot nadere keuring is dit voorlopig.      | Propose   |
|🟩 **DECIDED**    | De gemaakte (wijzigingen aan een) Architectural Decision Record is/zijn goedgekeurd door een belanghebbende.                    | Decision  |
|🟧 **REJECTED**   | De gemaakte (wijzigingen aan een) Architectural Decision Record is/zijn afgewezen door een belanghebbende omdat het niet (meer) kloppend is. | Decision |
|🟥 **DISCARDED**  | De betreffende Architectural Decision Record is niet meer van toepassing, het kan zijn dat er een andere keuze in plaats hier van is gekomen. | Decision |

## ADR 1: Implementatie van Jaeger voor Distributed Tracing

| Name              | Implementatie van Jaeger voor Distributed Tracing               |
|-------------------|-----------------------------------------------------------------|
| Current version   | 1                                                                 |
| Current status    | 🟥 **DISCARDED**                                                                |
| Problem/Issue     | In complexe architecturen die gebruik maken van microservices is het lastig om het verloop van requests over meerdere services te volgen, bottlenecks te identificeren en prestatieproblemen op te lossen. Zonder een systeem voor distributed tracing kan het debuggen en optimaliseren van prestaties tijdrovend en foutgevoelig zijn. Ons doel is om een oplossing te implementeren die end-to-end zicht biedt op service-interacties, zodat we latentie kunnen optimaliseren en problemen snel kunnen opsporen.                                                               |
| Decision          | Jaeger                                                                 |
| Alternatives      | 1. **SigNoz**: Open-source observatieplatform voor metrics en tracing. Het biedt een gebruiksvriendelijke interface en lokaal gegevensbeheer, maar heeft mogelijk minder geavanceerde tracing-mogelijkheden dan Jaeger. <br> 2. **Honeycomb**: Krachtig platform voor uitgebreide tracing, geschikt voor complexe systemen. Ondersteunt hoge gegevensvolumes en sterke query-mogelijkheden, maar kan duur zijn. <br> 3. **Tempo by Grafana**: Tracing-backend die integreert met Grafana. Efficiënt voor grootschalige data zonder database, maar beperkt in visualisatiemogelijkheden zonder andere Grafana-tools. Zie de blogpost van Harutjun Harutjunjan voor beredenering voor deze alternatieven. |
| Arguments         |   Jaeger is gekozen vanwege zijn unieke voordelen ten opzichte van andere tracing-tools. Ten eerste is het volledig open-source en gratis, wat het aantrekkelijk maakt voor teams die kosten willen beheersen, in tegenstelling tot commerciële alternatieven zoals Honeycomb. Jaeger biedt bovendien uitgebreide tracing-functionaliteiten en een krachtige integratie met microservices, wat het meer geschikt maakt voor complexe cloud-native omgevingen dan tools zoals SigNoz. De visuele interface van Jaeger maakt het eenvoudiger om bottlenecks en prestaties te analyseren, iets wat mogelijk beperkter is bij Tempo. Bovendien is Jaeger schaalbaar en kan het goed omgaan met een toenemend aantal microservices en aanvragen, wat essentieel is in een dynamische DevOps-context. Zie voor een meer gedetailleerd overzicht de blogpost van Harutjun Harutjunjan. |
| History | De history van de gemaakte keuze hieronder. Zie de reden voor de gemaakte keuze de [Individuele bijdrage van Harutjun](/docs/Harutjun-Harutjunjan.md) |

| **Stakeholder** | **Action**           | **Status**        | **Date**         |
|-----------------|---------------------|-------------------|------------------|
| H.Harutjunjan   | Decision             | 🟥 **DISCARDED**          | 31-10-2024|

## ARD 2: Gebruik van KEDA voor Autoscaling

| Name              | KEDA voor Autoscaling                                                   |
|-------------------|-----------------------------------------------------------|
| Current version   | 1                                                         |
| Current status    | 🟩 **DECIDED**                                            |
| Problem/Issue     | De huidige autoscaling-methode in Kubernetes is beperkt tot CPU- en geheugenmetrics, waardoor het moeilijk is om effectief te schalen op basis van event-driven workloads. |
| Decision          | Gebruik KEDA voor event-driven autoscaling in Kubernetes om resources efficiënter te gebruiken door te schalen op basis van externe triggers zoals message queues. |
| Alternatives      | Voortzetting van de standaard **Horizontal Pod Autoscaler (HPA)** voor CPU- en geheugengebaseerde autoscaling zonder event-driven ondersteuning. |
| Arguments         | 1. KEDA biedt een flexibele, event-driven benadering voor autoscaling.<br>2. Vermindert resourcekosten door alleen te schalen op specifieke events.<br>3. Ondersteunt meer dan 50 scalers, inclusief integraties met message brokers zoals RabbitMQ en Kafka. |

| **Stakeholder**  | **Action**           | **Status**        | **Date**        |
|------------------|----------------------|-------------------|-----------------|
| Osama Halabi     | Decision             | 🟩 **DECIDED**    | 26-10-2024      |

## ADR 3: Implementatie van Prometheus en Alertmanager voor Monitoring en Alerting

| Name              | Implementatie van Prometheus en Alertmanager voor Monitoring en Alerting |
|-------------------|-----------------------------------------------------------|
| Current version   | 1                                                         |
| Current status    | 🟩 **DECIDED**                                            |
| Problem/Issue     | Er is momenteel geen monitoring- en waarschuwingssysteem aanwezig. Hierdoor is het moeilijk om de gezondheid van de systemen te bewaken en snel te reageren op incidenten. Er is behoefte aan een oplossing die zowel monitoring als alerting biedt. |
| Decision          | Implementatie van Prometheus voor monitoring en Alertmanager voor het beheren en routeren van alerts, inclusief ondersteuning voor verschillende meldingskanalen zoals e-mail en Slack. |
| Alternatives      | 1. **Grafana Alerts**: Ingebouwde alerting in Grafana, eenvoudig te gebruiken maar mogelijk minder flexibel in configuratie en schaalbaarheid.<br>2. **OpsGenie**: Krachtige incidentmanagementtool, maar vereist een betaald abonnement en is mogelijk overkill voor onze behoeften.<br>3. **VictorOps**: Integratie met monitoringtools en incidentmanagement, maar ook een betaalde oplossing met mogelijk te veel functies voor onze specifieke situatie. |
| Arguments         | 1. Prometheus biedt krachtige en flexibele monitoringmogelijkheden voor een breed scala aan systemen en applicaties.<br>2. Alertmanager biedt naadloze integratie met Prometheus, wat efficiëntie verhoogt.<br>3. Beide tools zijn open-source en kosteneffectief, wat past binnen onze budgettaire beperkingen.<br>4. Flexibiliteit in meldingskanalen zorgt voor snellere respons op incidenten.<br>5. Ondersteunt uitgebreide configuratie-opties voor het routeren en dempen van alerts. |

| **Stakeholder**  | **Action**           | **Status**        | **Date**        |
|------------------|----------------------|-------------------|-----------------|
| Tim van de Ven   | Decision             | 🟩 **DECIDED**    | 26-10-2024      |

## ADR 4: Gebruik van KEDA voor Design for Failure

| Name              | KEDA voor Design for Failure                                                   |
|-------------------|-----------------------------------------------------------|
| Current version   | 1                                                         |
| Current status    | 🟩 **DECIDED**                                           |
| Problem/Issue     |        Voor een fouttolerante en hoog beschikbare infrastructuur moeten applicaties automatisch kunnen reageren op wisselende belasting en onverwachte uitval van services of hardware. Zonder een systeem voor adaptieve schaalbaarheid riskeren we vertragingen, downtime en een negatieve impact op de gebruikerservaring bij onverwachte pieken of storingen. Dit belemmert onze doelstelling om "Design for Failure" te realiseren, waarbij eindgebruikers geen merkbare hinder ondervinden bij uitval van onderdelen.                                                   |
| Decision          | KEDA                                                          |
| Alternatives      | 1. **HPA(Horizontal Pod Autoscaler)**: Een Kubernetes-tool die pods automatisch schaalt op basis van CPU- en geheugengebruik. <br> 2. **Cluster Autoscaler**: Een autoscaler die het aantal nodes in een Kubernetes-cluster aanpast op basis van de resourcebehoeften van pods. <br> 3. **Knative Serving**: Een platform voor het automatisch schalen van serverless applicaties en microservices op basis van inkomend verkeer. |
| Arguments         | KEDA is gekozen vanwege zijn veelzijdige, event-driven autoscaling-mogelijkheden, die verder gaan dan de CPU- en geheugengebaseerde aanpak van HPA. Dit maakt het mogelijk om applicaties schaalbaar te maken op basis van diverse events, zoals berichten in wachtrijen of wijzigingen in databases, wat essentieel is voor fouttolerantie binnen "Design for Failure". In tegenstelling tot de Cluster Autoscaler, die zich richt op nodes, biedt KEDA applicatiespecifieke schaalbaarheid die direct kan inspelen op belasting- en faalpatronen zonder ingrijpende infrastructuuraanpassingen. Ook heeft KEDA, anders dan Knative Serving, geen beperkingen tot alleen serverless toepassingen en HTTP-verkeer, wat zorgt voor een bredere inzetbaarheid in een microservices-architectuur. Door de sterke integratie met Kubernetes en de ondersteuning voor een breed scala aan scalers is KEDA zowel flexibel als robuust voor uiteenlopende DevOps-omgevingen.                                                       |

| **Stakeholder**  | **Action**           | **Status**        | **Date**        |
|------------------|----------------------|-------------------|-----------------|
| Osama Halabi     | Decision             | 🟩 **DECIDED**    | 26-10-2024      |
