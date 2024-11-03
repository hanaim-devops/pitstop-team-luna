# Eigen bijdragen Osama Halabi

## Samenvatting van mijn Bijdrage

Tijdens het project heb ik in mijn rol als Developer en Ops-er bijgedragen aan verschillende onderdelen van de applicatie en infrastructuur, waarbij ik me richtte op code-ontwikkeling, configuratie en documentatie. Hieronder geef ik een kort overzicht van mijn belangrijkste bijdragen:

- **Microservices en Functionaliteit**:
  - Implementatie van een notificatie- en goedkeuringssysteem voor reparatiekosten. [Code](https://github.com/hanaim-devops/pitstop-team-luna/commit/7578af0db6a1a23fe64e7aef1442b7aaba590fda)
  - Aangepaste bestandenservice voor het versturen van notificaties via e-mail. [Code](https://github.com/hanaim-devops/pitstop-team-luna/commit/73bb6ff35d01904618fb5b23b3fe3c7aabbe1bcf)
  - Unit tests toegevoegd voor RepairManagementAPI om robuustheid te verbeteren. [Code](https://github.com/hanaim-devops/pitstop-team-luna/commit/75b87f71bdd418f84f363e35478a165ed0a617c3)

- **Configuratie en Containerization**:
  - Integratie van KEDA voor autoscaling op basis van werkbelasting in Kubernetes. [Pull Request](https://github.com/hanaim-devops/pitstop-team-luna/pull/44)
  - YAML-configuraties voor ScaledObjects en TriggerAuthentication opgezet voor event-driven autoscaling. [YAML Bestand](https://github.com/hanaim-devops/pitstop-team-luna/pull/44/files#diff-d72a9f0ad564819df062aded6468ab71252b49dc63cf16d7a7ee554c0bc8f02d)

- **Documentatie en Diagrammen**:
  - Ontwikkeling van C4 Model met Context-, Container- en Component Diagrammen voor overzicht en inzicht in architectuur. [C4 Diagrammen](https://github.com/hanaim-devops/pitstop-team-luna/pull/50/commits)
  - ADR opgesteld voor de keuze van KEDA als autoscaling-oplossing in Kubernetes. [ADR-2](./adr.md)

- **Scrum en Teamprocessen**:
  - Actieve deelname aan Sprint Planning, Daily Standups, en Retrospectives, met nadruk op het structureren van user stories en effectieve communicatie.
  - Ondersteuning van teamleden en zorg voor een goede sfeer en samenwerking binnen het project. [Miro Board](https://miro.com/app/board/uXjVLMAHh4U=/)

In deze rollen heb ik zowel mijn DevOps-vaardigheden als mijn samenwerkings- en communicatievaardigheden kunnen verbeteren, wat de voortgang en kwaliteit van het project ten goede kwam.

## 1. Code/platform bijdrage

Competenties: *DevOps-1 Continuous Delivery*

In mijn rol als [Developer en Ops-er] heb ik verschillende bijdragen geleverd binnen het project. Hieronder beschrijf ik mijn belangrijkste bijdragen:

### Bijdragen voor Developer (Dev)

Als Developer heb ik bijgedragen aan de volgende functionaliteiten:

1. **Bijdragen 1**  
   * Beschrijving: Ik heb een micro service geimplementeerd voor de usecase [Als klant wil ik de kosten van de reparatie kunnen goedkeuren via een notificatie, zodat de reparatie snel kan doorgaan zonder extra vertraging.](https://github.com/orgs/hanaim-devops/projects/26/views/1?pane=issue&itemId=83312279&issue=hanaim-devops%7Cpitstop-team-luna%7C6)
   * Link naar code: [commit](https://github.com/hanaim-devops/pitstop-team-luna/commit/7578af0db6a1a23fe64e7aef1442b7aaba590fda)

2. **Bijdragen 2**  
   * Beschrijving: Ik heb een bestanden micro service aan gepast om mail naar de klant te kunnen sturen via een event die binnen komt.
   * Link naar code: [commit](https://github.com/hanaim-devops/pitstop-team-luna/commit/73bb6ff35d01904618fb5b23b3fe3c7aabbe1bcf)

3. **Bijdragen 3**  
   * Beschrijving: Ik heb een aantal unit tests gemaakt voor de repairmanagementapi waarin ik bijna alle mogelijkheden tests.
   * Link naar code: [commit](https://github.com/hanaim-devops/pitstop-team-luna/commit/75b87f71bdd418f84f363e35478a165ed0a617c3)


## 2. Bijdrage app configuratie/containers/kubernetes

Competenties: *DevOps-2 Orchestration, Containerization*

Mijn belangrijkste bijdragen op het gebied van configuratie en containerization zijn:

1. **Bijdragen 1**  
   * **[KEDA](https://github.com/hanaim-devops/pitstop-team-luna/pull/44):** Beschrijving: Ik heb KEDA geïntegreerd in het Kubernetes-cluster om dynamische autoscaling toe te passen op de meest gebruikte deployments. Deze configuratie zorgt ervoor dat de schaalbaarheid automatisch wordt afgestemd op de werkbelasting.
  
2. **Bijdragen 2**  
   * **[Yaml en config bestand](https://github.com/hanaim-devops/pitstop-team-luna/pull/44/files#diff-d72a9f0ad564819df062aded6468ab71252b49dc63cf16d7a7ee554c0bc8f02d):**  Beschrijving: Ik heb voor elke scaledobject een yaml bestand gemaakt. Daarnaast heb ik een authenticatie trigger gemmakt voor het luisteren naar de events.


## 3. Bijdrage versiebeheer, CI/CD pipeline en/of monitoring

Competenties: *DevOps-1 - Continuous Delivery*, *DevOps-3 GitOps*, *DevOps-5 - SlackOps*

Ik heb tijdens deze opdracht niet echt direct bijgedragen vaan de pijpline aangezien ik tijdens de weekodrachten aan deze competentie gewerkt heb.

## 4. Onderzoek

Competenties: *Nieuwsgierige houding*

Tijdens de course BP heb ik onderzoek gedaan naar KEDA (Kubernetes Event-Driven Autoscaling), een tool die automatische scaling in Kubernetes mogelijk maakt op basis van externe events, zoals de belasting van message queues. Mijn blogpost, ["KEDA in Actie: Event-Driven Autoscaling voor Microservices binnen DevOps"](https://github.com/hanaim-devops/devops-blog-oshalabi/tree/main/src/keda-in-actie-event-driven-autoscaling-voor-microservices-binnen-devops), geeft een overzicht van wat KEDA is, hoe het werkt, en hoe het past binnen een microservices-omgeving zoals Pitstop. Ik heb KEDA succesvol toegepast door het te configureren voor autoscaling in een RabbitMQ-wachtrij. Dit stelde de Pitstop-applicatie in staat om dynamisch te schalen op basis van de werkelijke belasting, waardoor resources efficiënter werden ingezet.

Extra leerervaringen omvatten onder andere het werken met TriggerAuthentication en ScaledObject configuraties, wat inzicht gaf in hoe KEDA secure toegang tot externe bronnen kan beheren. Sinds mijn eerste toepassing heb ik ook verder gekeken naar alternatieve scaling-tools, zoals Knative en custom controllers, en onderzocht hoe deze zich verhouden tot KEDA. Dit bood waardevolle kennis voor toekomstige scenario’s waarin andere scaling-benaderingen relevanter kunnen zijn, afhankelijk van het type workload.

Aan gezien we minimaal resours hebben gekregen in onze cluster was het moelijk om keda te testen daarom zal heb ik hem werl locaal getest.


## 5. Bijdrage code review/kwaliteit anderen en security

Competenties: *DevOps-7 - Attitude*, *DevOps-4 DevSecOps*

Tijdens mijn werkzaamheden binnen DevOps heb ik meerdere code-reviews uitgevoerd, waarbij ik me heb gericht op zowel de kwaliteit van de code als de werking van de CI/CD-pijplijn. Hier zijn de twee belangrijkste review-acties die ik heb uitgevoerd:

1. **[Backend-Frontend Integratieprobleem in Pull Request](https://github.com/hanaim-devops/pitstop-team-luna/pull/46#pullrequestreview-2407655279)**  
   Tijdens de review van deze pull request ontdekte ik een foutieve implementatie in de communicatie tussen de frontend en backend. De backend-API verwachtte zowel een URL-parameter als een JSON-body bij een POST-request, maar de frontend stuurde enkel een JSON-body, wat resulteerde in een 404-respons. Ik heb dit probleem gemeld en geadviseerd om de frontend-aanroep aan te passen zodat de vereiste URL-parameter werd meegegeven. Dit verbeterde de communicatie tussen de frontend en backend en voorkwam foutieve API-responsen.

2. **[Pipeline-configuratie in Pull Request voor Customer Support Implementatie](https://github.com/hanaim-devops/pitstop-team-luna/pull/45)**  
   In deze pull request merkte ik dat de CI/CD-pijplijn faalde vanwege een misconfiguratie. Ik heb de ontwikkelaar geadviseerd om eerst de pijplijnconfiguratie te corrigeren, zodat de builds zouden slagen en een consistente implementatie mogelijk werd. Door de configuratie in orde te maken, kon het team verdere wijzigingen stabiel en betrouwbaar doorvoeren in de productie-omgeving.

Met deze reviews heb ik een actieve bijdrage geleverd aan het verbeteren van de kwaliteit en stabiliteit van de applicatie, evenals de betrouwbaarheid van de CI/CD-pijplijn. Deze acties ondersteunen de DevOps-competenties van *kwaliteit* en *continuïteit* door het implementeren van structurele verbeteringen en probleemoplossingen.

## 6. Bijdrage documentatie

Competenties: *DevOps-6 Onderzoek*

1. **C4 Diagrammen**  
   - - [Context Diagram en C4 Model](../src/README.md): Ik heb het initiatief genomen om een C4 Model te maken voor ons project om een visueel overzicht te bieden van de architectuur. Hierbij heb ik zowel het Context- als het Container Diagram opgesteld. Daarnaast heb ik Component Diagrammen gemaakt voor de Notification Service en de Repair Management API. Deze toevoegingen bieden een gedetailleerd inzicht in de structuur en interacties binnen ons systeem. [Pull Request](https://github.com/hanaim-devops/pitstop-team-luna/pull/50/commits).


2. **Architectural Decision Records (ADR's)**  
   - [ADR-2: Gebruik van KEDA voor Autoscaling](./adr.md): De beslissing voor het kiezen van KEDA als autoscaling-oplossing en de overwegingen die hierbij zijn gemaakt, zoals efficiëntie, event-driven scaling, en compatibiliteit met de huidige Kubernetes-architectuur. [commit](https://github.com/hanaim-devops/pitstop-team-luna/commit/086060a8d47dc8998a5d0b182c507b1d561e8a68#diff-d63e2326600a72e683dade5a5840c70099811a2416b302335319845f42fe053c)


3. **User Stories en Acceptatiecriteria**  
   - [Kosten van de reparatie kunnen goedkeuren](https://github.com/orgs/hanaim-devops/projects/26?pane=issue&itemId=83312279&issue=hanaim-devops%7Cpitstop-team-luna%7C6): Voor deze user story heb ik acceptatiecriteria vast geledg om een duidlijk beeld te krijgen over waaraan deze story moet voldoen.


## 7. Bijdrage Agile werken, groepsproces, communicatie opdrachtgever en soft skills

Competenties: *DevOps-1 - Continuous Delivery*, *Agile*

Tijdens het project heb ik actief deelgenomen aan Scrum ceremonies en bijgedragen aan zowel het groepsproces als de communicatie met de opdrachtgever. Enkele voorbeelden van mijn inbreng zijn:

1. **Sprint Planning**: Tijdens de sprint planning heb ik actief geholpen bij het inschatten van de benodigde tijd voor verschillende taken en het prioriteren van de backlog-items. Samen met het team heb ik gewerkt aan het opstellen van duidelijke sprintdoelen om een goed gefocuste en haalbare sprint te plannen.

2. **Daily Standup Meetings**: Om de dagelijkse communicatie en afstemming binnen het team te verbeteren, heb ik de Daily Standup meeting aangemaakt en op 9:30 gepland. Omdat een teamlid niet beschikbaar was op dit tijdstip, heb ik het tijdstip in overleg met het team verplaatst naar 10:00, zodat iedereen kon deelnemen.

3. **Retrospective**: Tijdens de retrospectives heb ik constructieve feedback gegeven over ons teamproces. Ik heb een aantal verbeterpunten genoemd, zoals het tijdig oppakken en afronden van individuele taken en heldere communicatie over voortgang. Ook heb ik enkele successen benadrukt om het team te motiveren. [Miro Board](https://miro.com/app/board/uXjVLMAHh4U=/)


Deze activiteiten hebben bijgedragen aan een goede samenwerking, duidelijke communicatie en een betere afstemming binnen het team en met de opdrachtgever.
  
## 8. Leerervaringen

Competenties: *DevOps-7 - Attitude*

Tot slot, enkele **tops** en **tips** op het gebied van professional skills die ik meeneem voor mijn verdere loopbaan:

### Tops
1. **Samenwerken**: De samenwerking binnen het team verliep soepel en effectief. We hebben elkaar goed ondersteund, wat de productiviteit en teamdynamiek bevorderde.
2. **Behulpzaamheid**: Ik heb actief mijn teamleden geholpen met hun taken wanneer ze ondersteuning nodig hadden. Dit heeft bijgedragen aan een positieve sfeer en een vlotte voortgang van het project.

### Tips
1. **User Stories beter verdelen**: Ik heb geleerd dat ik mijn user stories beter kan opdelen in kleinere, beheersbare taken. Dit zal de voortgang en overzichtelijkheid van mijn werk verbeteren.
2. **Sprinttaken tijdig oppakken**: Een ander aandachtspunt is om mijn taken eerder in de sprint op te pakken. Dit voorkomt last-minute stress en zorgt voor meer spreiding van werk.

Daarnaast heb ik tijdens het project waardevolle hulp en feedback ontvangen van mijn groepsgenoten. Eén van de meest opvallende momenten was toen een teamlid me op een constructieve manier feedback gaf over de indeling van mijn user story, wat me hielp mijn aanpak aan te passen en mijn werk effectiever te structureren.

## 9. Conclusie & feedback

Competenties: *DevOps-7 - Attitude*

Terugkijkend op dit project ben ik tevreden over mijn bijdrage en de geleverde inspanningen. Ik heb veel kunnen leren en bijdragen aan zowel technische als organisatorische aspecten, zoals het implementeren van nieuwe functionaliteiten, het opzetten van configuraties voor autoscaling met KEDA, en het maken van ondersteunende documentatie en diagrammen. Deze taken hebben me geholpen om meer inzicht te krijgen in de complete DevOps-levenscyclus en de samenwerking binnen een team.

Tijdens het project heb ik gemerkt dat heldere communicatie en een goede verdeling van user stories belangrijk zijn voor een soepel verloop. Het werken met KEDA en Kubernetes heeft me geholpen mijn DevOps-technieken te verfijnen, en het opzetten van een C4 Model en ADR's bood me waardevolle ervaring in het documenteren van beslissingen en architectuur.

Constructieve feedback aan docenten/beoordelaars:
- Het zou waardevol zijn om meer voorbeelden en richtlijnen te krijgen over het documenteren van beslissingen met ADR's in DevOps-projecten, zodat studenten vanaf het begin gestructureerd kunnen werken.
- Daarnaast zou een sessie over het opstellen van effectieve user stories en het opdelen ervan in kleine, beheersbare taken nuttig zijn om overzicht en controle te behouden in grotere projecten.

Deze opgedane kennis en vaardigheden zal ik meenemen naar toekomstige DevOps-projecten en mijn verdere loopbaan, waarin ik vooral de waarde van heldere communicatie, documentatie, en continue verbetering van de DevOps-pijplijn meeneem. Met deze ervaring voel ik me beter voorbereid op mijn afstudeeropdracht en ben ik ervan overtuigd dat ik de geleerde technieken kan toepassen in een professionele werkomgeving.