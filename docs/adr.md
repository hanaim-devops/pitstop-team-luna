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
| Current status    | 🟥 **DISCARDED**                                                                 |
| Problem/Issue     | In complexe architecturen die gebruik maken van microservices is het lastig om het verloop van requests over meerdere services te volgen, bottlenecks te identificeren en prestatieproblemen op te lossen. Zonder een systeem voor distributed tracing kan het debuggen en optimaliseren van prestaties tijdrovend en foutgevoelig zijn. Ons doel is om een oplossing te implementeren die end-to-end zicht biedt op service-interacties, zodat we latentie kunnen optimaliseren en problemen snel kunnen opsporen.                                                               |
| Decision          | Jaeger                                                                 |
| Alternatives      | 1. **SigNoz**: Open-source observatieplatform voor metrics en tracing. Het biedt een gebruiksvriendelijke interface en lokaal gegevensbeheer, maar heeft mogelijk minder geavanceerde tracing-mogelijkheden dan Jaeger. 2. **Honeycomb**: Krachtig platform voor uitgebreide tracing, geschikt voor complexe systemen. Ondersteunt hoge gegevensvolumes en sterke query-mogelijkheden, maar kan duur zijn. 3. **Tempo by Grafana**: Tracing-backend die integreert met Grafana. Efficiënt voor grootschalige data zonder database, maar beperkt in visualisatiemogelijkheden zonder andere Grafana-tools. |
| Arguments         |   Jaeger is gekozen vanwege zijn unieke voordelen ten opzichte van andere tracing-tools. Ten eerste is het volledig open-source en gratis, wat het aantrekkelijk maakt voor teams die kosten willen beheersen, in tegenstelling tot commerciële alternatieven zoals Honeycomb. Jaeger biedt bovendien uitgebreide tracing-functionaliteiten en een krachtige integratie met microservices, wat het meer geschikt maakt voor complexe cloud-native omgevingen dan tools zoals SigNoz. De visuele interface van Jaeger maakt het eenvoudiger om bottlenecks en prestaties te analyseren, iets wat mogelijk beperkter is bij Tempo. Bovendien is Jaeger schaalbaar en kan het goed omgaan met een toenemend aantal microservices en aanvragen, wat essentieel is in een dynamische DevOps-context.|
| History | De history van de gemaakte keuze hieronder |

| **Stakeholder** | **Action**           | **Status**        | **Date**         |
|-----------------|---------------------|-------------------|------------------|
| H.Harutjunjan   | Decision             | 🟥 **DISCARDED**          | 31-10-2024|
