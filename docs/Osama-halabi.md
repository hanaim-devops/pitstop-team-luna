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

```markdown
Beschrijf hier voor het Course BP kort je onderzochte technologie met een link naar je blog post, of het toepassen ervan gelukt is en hoe, of waarom niet. Beschrijf evt. kort extra leerervaringen met andere technologieen of verdieping sinds het blog. 

Tijdens het grote project beschrijf je hier onderzoek naar het domein en nieuwe onderzochte/gebruikte DevOps technologieën. Wellicht heb je nogmaals de voor blog onderzochte technologie kunnen toepassen in een andere context. Verder heb je nu een complex domein waar je in moet verdiepen en uitvragen bij de opdrachtgever. Link bijvoorbeeld naar repo's met POC's of, domein modellen of beschrijf andere onderwerpen en link naar gebruikte bronnen.

Als de tijdens course onderzochte technologie wel toepasbaar is kun je dit uiteraard onder dit punt noemen. Of wellicht was door een teamgenoot onderzochte technologie relevant, waar jij je nu verder in verdiept hebt en mee gewerkt hebt, dus hier kunt beschrijven. Tot slot kun je hier ook juist een korte uitleg geef over WAAROM  jouw eerder onderzochte technologie dan precies niet relevant of inpasbaar was. Dit is voor een naieve buitenstaander niet altijd meteen duidelijk, maar kan ook heel interessant zijn. Bijvoorbeeld dat [gebruik van Ansible in combi met Kubernetes](https://www.ansible.com/blog/how-useful-is-ansible-in-a-cloud-native-kubernetes-environment) niet handig blijkt. Ook als je geen uitgebreid onderzoek hebt gedaan of ADR hebt waar je naar kunt linken, dan kun je onder dit kopje wel alsnog kort conceptuele kennis duidelijk maken.
```

Tijdens het project heb ik onderzoek gedaan naar het gebruik van Prometheus en Alertmanager in combinatie met Kubernetes. Dit heeft geleid tot de implementatie van deze technologieën in ons project, zoals beschreven in mijn bijdragen aan de app configuratie en Kubernetes scripts.

## 5. Bijdrage code review/kwaliteit anderen en security

Competenties: *DevOps-7 - Attitude*, *DevOps-4 DevSecOps*

```markdown
Beschrijf hier en geef links naar de minimaal 2 en maximaal 4 grootste *review acties* die je gedaan hebt, bijvoorbeeld pull requests incl. opmerkingen. Het interessantst zijn natuurlijk gevallen waar code niet optimaal was. Zorg dat je minstens een aantal reviews hebt waar in gitlab voor een externe de kwestie ook duidelijk is, in plaats van dat je dit altijd mondeling binnen het team oplost.
```
1. [Pull request review](https://github.com/hanaim-devops/pitstop-team-luna/pull/46#pullrequestreview-2407655279): Ik heb de ##TODO


## 6. Bijdrage documentatie

Competenties: *DevOps-6 Onderzoek*

```markdown
Zet hier een links naar en geef beschrijving van je C4 diagram of diagrammen, README of andere markdown bestanden, ADR's of andere documentatie. Bij andere markdown bestanden of doumentatie kun je denken aan eigen proces documentatie, zoals code standaarden, commit- of branchingconventies. Tot slot ook user stories en acceptatiecriteria (hopelijk verwerkt in gitlab issues en vertaalt naar `.feature` files) en evt. noemen en verwijzen naar handmatige test scripts/documenten.
```

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
