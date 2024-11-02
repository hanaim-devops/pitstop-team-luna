# Eigen bijdrage Osama Halabi

```markdown
Je begin hier onder het hoofdkopje met een samenvatting van je bijdrage zoals je die hieronder uitwerkt. Best aan het einde schrijven. Zorg voor een soft landing van de beoordelaar, maar dat deze ook direct een beeld krijgt. Je hoeft geen heel verslag te schrijven. De kopjes kunnen dan wat korter met wat bullet lijst met links voor 2 tot 4 zaken en 1 of 2 inleidende zinnen erboven. Een iets uitgebreidere eind conclusie schrijf je onder het laatste kopje.
```

## 1. Code/platform bijdrage

Competenties: *DevOps-1 Continuous Delivery*

In mijn rol als [Developer en Ops-er] heb ik verschillende bijdragen geleverd binnen het project. Hieronder beschrijf ik mijn belangrijkste bijdragen:

### Bijdragen voor Developer (Dev)

Als Developer heb ik bijgedragen aan de volgende functionaliteiten:

1. **Bijdragen 1**  
   * Beschrijving: [Ik heb een micro service geimplementeerd voor de usecase (Als klant wil ik de kosten van de reparatie kunnen goedkeuren via een notificatie, zodat de reparatie snel kan doorgaan zonder extra vertraging.)[https://github.com/orgs/hanaim-devops/projects/26/views/1?pane=issue&itemId=83312279&issue=hanaim-devops%7Cpitstop-team-luna%7C6]]
   * Link naar code: (commit)[https://github.com/hanaim-devops/pitstop-team-luna/commit/7578af0db6a1a23fe64e7aef1442b7aaba590fda]

2. **Bijdragen 2**  
   * Beschrijving: Ik heb een bestanden micro service aan gepast om mail naar de klant te kunnen sturen via een event die binnen komt.
   * Link naar code: (commit)[https://github.com/hanaim-devops/pitstop-team-luna/commit/73bb6ff35d01904618fb5b23b3fe3c7aabbe1bcf]


## 2. Bijdrage app configuratie/containers/kubernetes

Competenties: *DevOps-2 Orchestration, Containerization*

Mijn belangrijkste bijdragen op het gebied van configuratie en containerization zijn:

1. **Bijdragen 1**  
   * Beschrijving: Ik heb KEDA geïntegreerd in het Kubernetes-cluster om dynamische autoscaling toe te passen op de meest gebruikte deployments. Deze configuratie zorgt ervoor dat de schaalbaarheid automatisch wordt afgestemd op de werkbelasting.
   * [KEDA](https://github.com/hanaim-devops/pitstop-team-luna/pull/44)
2. **Bijdragen 2**  
   * Beschrijving: Ik heb voor elke scaledobject een yaml bestand gemaakt. Daarnaast heb ik een authenticatie trigger gemmakt voor het luisteren naar de events.
   * [Yaml en config bestand](https://github.com/hanaim-devops/pitstop-team-luna/pull/44/files#diff-d72a9f0ad564819df062aded6468ab71252b49dc63cf16d7a7ee554c0bc8f02d).

## 3. Bijdrage versiebeheer, CI/CD pipeline en/of monitoring

Competenties: *DevOps-1 - Continuous Delivery*, *DevOps-3 GitOps*, *DevOps-5 - SlackOps*

1. **Bijdragen 1**  
   * Beschrijving: Ik heb KEDA geïntegreerd in het Kubernetes-cluster om dynamische autoscaling toe te passen op de meest gebruikte deployments. Deze configuratie zorgt ervoor dat de schaalbaarheid automatisch wordt afgestemd op de werkbelasting.
   * [KEDA](https://github.com/hanaim-devops/pitstop-team-luna/pull/44)
2. **Bijdragen 2** 
   * Beschrijving: Ik heb KEDA geïntegreerd in het Kubernetes-cluster om dynamische autoscaling toe te passen op de meest gebruikte deployments. Deze configuratie zorgt ervoor dat de schaalbaarheid automatisch wordt afgestemd op de werkbelasting.
   * [KEDA](https://github.com/hanaim-devops/pitstop-team-luna/pull/44)


## 4. Onderzoek

Competenties: *Nieuwsgierige houding*

Tijdens de course BP heb ik onderzoek gedaan naar KEDA (Kubernetes Event-Driven Autoscaling), een tool die automatische scaling in Kubernetes mogelijk maakt op basis van externe events, zoals de belasting van message queues. Mijn blogpost, ["KEDA in Actie: Event-Driven Autoscaling voor Microservices binnen DevOps"](https://github.com/hanaim-devops/devops-blog-oshalabi/tree/main/src/keda-in-actie-event-driven-autoscaling-voor-microservices-binnen-devops), geeft een overzicht van wat KEDA is, hoe het werkt, en hoe het past binnen een microservices-omgeving zoals Pitstop. Ik heb KEDA succesvol toegepast door het te configureren voor autoscaling in een RabbitMQ-wachtrij. Dit stelde de Pitstop-applicatie in staat om dynamisch te schalen op basis van de werkelijke belasting, waardoor resources efficiënter werden ingezet.

Extra leerervaringen omvatten onder andere het werken met TriggerAuthentication en ScaledObject configuraties, wat inzicht gaf in hoe KEDA secure toegang tot externe bronnen kan beheren. Sinds mijn eerste toepassing heb ik ook verder gekeken naar alternatieve scaling-tools, zoals Knative en custom controllers, en onderzocht hoe deze zich verhouden tot KEDA. Dit bood waardevolle kennis voor toekomstige scenario’s waarin andere scaling-benaderingen relevanter kunnen zijn, afhankelijk van het type workload.

Aan gezien we minimaal resours hebben gekregen in onze cluster was het moelijk om keda te testen.


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



## 7. Bijdrage Agile werken, groepsproces, communicatie opdrachtgever en soft skills

Competenties: *DevOps-1 - Continuous Delivery*, *Agile*

```markdown
Beschrijf hier minimaal 2 en maximaal 4 situaties van je inbreng en rol tijdens Scrum ceremonies. Beschrijf ook feedback of interventies tijdens Scrum meetings, zoals sprint planning of retrospective die je aan groespgenoten hebt gegeven.

Beschrijf tijdens het project onder dit kopje ook evt. verdere activiteiten rondom communicatie met de opdrachtgever of domein experts, of andere meer 'professional skills' of 'soft skilss' achtige zaken.
```

Tijdens het project heb ik actief deelgenomen aan Scrum ceremonies en bijgedragen aan het groepsproces en de communicatie met de opdrachtgever. Enkele voorbeelden van mijn inbreng zijn:

1. Tijdens de sprint planning heb ik geholpen bij het inschatten van de benodigde tijd, prioritering van taken en inplannen van de sprintdoelen.
2. Tijdens de technische discussie met de opdrachtgever heb ik het proces [genotuleerd](https://github.com/hanaim-devops/pitstop-team-luna/commit/c9f2829c4debd22ce8c2707c887216650d54e0b8).
3. Om het groepsproces te verbeteren heb ik een Daily Standup meeting aangemaakt, dagelijks om 10.00.
4. ...
  
## 8. Leerervaringen

Competenties: *DevOps-7 - Attitude*

```markdown
Geef tot slot hier voor jezelf minimaal 2 en maximaal **4 tops** en 2 dito (2 tot 4) **tips** á la professional skills die je kunt meenemen in je verdere loopbaan. Beschrijf ook de voor jezelf er het meest uitspringende hulp of feedback van groepsgenoten die je (tot dusver) hebt gehad tijdens het project.
```

## 9. Conclusie & feedback

Competenties: *DevOps-7 - Attitude*

```markdown
Schrijf een conclusie van al bovenstaande punten. En beschrijf dan ook wat algemener hoe je terugkijkt op het project. Geef wat constructieve feedback, tips aan docenten/beoordelaars e.d. En beschrijf wat je aan devops kennis, vaardigheden of andere zaken meeneemt naar je afstudeeropdracht of verdere loopbaan.
```
