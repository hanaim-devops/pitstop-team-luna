# Eigen bijdrage Joris Wittenberg

In dit document beschrijf ik mijn bijdragen aan het DevOps project. Ik heb me met name gericht op het configureren van de Rancher omgeving en het implementeren van Sonarqube. 

## 1. Code/platform bijdrage

In dit gedeelte bespreek ik mijn bijdragen aan de code en het platform.

De planning was dat ik in week 1 Sonarqube zou implementeren en in week 2 tijd zou hebben voor het toevoegen van mijn functionele taak. Helaas ben ik niet toegekomen aan het implementeren van mijn functionele taak. Dit heeft verschillende redenen gehad. Junji zat bij ons in de groep en ik merkte dat hij redelijk veel moeite had met C# en zijn functionele taak. In week 1 heb ik hem veel geholpen, wat me de nodige tijd heeft gekost.

Verder ben ik tegen veel vertragingen aangelopen met het integreren van SonarQube. Dit probleem deed zich in eerste instantie voor bij de installatie en configuratie van de tool op ons Kubernetes-cluster. Ondanks dat de documentatie duidelijk leek, stuitte ik op verschillende technische obstakels, zoals netwerkconfiguraties en persistent storage-instellingen. Een complicerende factor was dat we maar één productieomgeving hadden, terwijl meerdere groepsleden tegelijkertijd aan de slag waren in deze omgeving. Dit leidde tot verwarring en overlapping van wijzigingen, waardoor het uitdagend was om de benodigde netwerkinstellingen correct door te voeren. Het extern benaderbaar maken van SonarQube bleek met name een uitdaging, omdat het vereiste dat ik een goed begrip had van de Kubernetes-ingress en serviceconfiguraties.

Tijdens dit proces was het noodzakelijk om samen te werken met andere teamleden, aangezien we slechts één productieomgeving hadden waar meerdere groepsleden tegelijkertijd aan het werk waren. Deze samenwerking hielp ons bij het coördineren van de benodigde wijzigingen, maar leidde ook tot extra vertragingen doordat we rekening moesten houden met elkaars werkzaamheden. Het was essentieel om ervoor te zorgen dat de SonarQube-instantie toegankelijk was voor het team zonder de voortgang van andere taken in gevaar te brengen. Hoewel ik mijn functionele taak nog niet heb kunnen toevoegen, heb ik waardevolle ervaring opgedaan in het werken met Kubernetes en het oplossen van integratieproblemen. In het komende eindproject hoop ik deze uitdagingen verder aan te pakken en alsnog mijn bijdrage aan de functionele aspecten van het project te leveren.

1. [Sonarqube](https://github.com/hanaim-devops/pitstop-team-luna/pull/52) Implementatie van SonarQube voor het bewaken van codekwaliteit.
2. [Integration Test](https://github.com/hanaim-devops/pitstop-team-luna/commit/f0aba372320462a5d8ce7a2e2182ab3f3d6b3417) Integratietest toegevoegd om de melding te verifiëren wanneer een reparatie is voltooid.



## 2. Bijdrage app configuratie/containers/kubernetes

In de afgelopen week heb ik me gericht op het implementeren van de ingress-configuratie om zowel de webapp als SonarQube extern bereikbaar te maken. Hiervoor heb ik het `config.yaml`-bestand gebruikt om via de command line direct commando’s aan ons cluster aan te roepen, wat me in staat stelde om gebruik te maken van HELM voor het beheer van de applicaties. Tijdens deze implementatie ondervond ik echter verschillende problemen met de HELM-installatie, met name met betrekking tot de persistent volumes.

Om deze obstakels te overwinnen, besloot ik om handmatig alle YAML-bestanden voor SonarQube te schrijven. Zodra ik deze configuratie gereed had, stuitte ik op nieuwe uitdagingen met de ingress-instellingen. Omdat ik niet erg vertrouwd was met Kubernetes, en met name met de Rancher-omgeving, vond ik het lastig om te bepalen of de problemen voortkwamen uit mijn eigen configuratiefouten of dat ze gerelateerd waren aan de Rancher-omgeving zelf. Deze leercurve vereiste veel tijd en geduld, maar ik heb waardevolle ervaring opgedaan in het werken met Kubernetes en het configureren van ingresses.

1. [Sonarqube](https://github.com/hanaim-devops/pitstop-team-luna/pull/52/files) Sonarqube toegevoegd aan automatisch start-up script.

## 3. Bijdrage aan Versiebeheer, CI/CD Pipeline en Monitoring

1. [CI/CD Pipeline](https://github.com/hanaim-devops/pitstop-team-luna/pull/31): In week 1 hebben Tim en ik ons beziggehouden met het implementeren van onze onderzoeken, terwijl de rest van het team zich richtte op de functionele taken. We hebben samen gekeken naar het opzetten van de CI/CD-pipeline en geprobeerd om SonarQube in deze pipeline te integreren. We hebben de basisstructuur van de CI/CD-pipeline gedefinieerd om een efficiënte workflow voor ons project te waarborgen. Tijdens mijn poging om SonarQube in de pipeline te implementeren, stuitte ik op het obstakel dat SonarQube een webhook URL vereist voor integratie, wat een ingress-configuratie noodzakelijk maakte. Aangezien SonarQube aanvankelijk alleen via localhost draaide, was het niet mogelijk om deze effectief in de pipeline te integreren zonder de juiste ingresses in te stellen. Deze ervaring heeft me waardevolle inzichten gegeven in de uitdagingen van CI/CD-integraties en het belang van een goede configuratie van netwerkcomponenten.

2. Gitops: Ik heb bijgedragen aan de implementatie van GitOps-principes door het toepassen van een pull-model en het automatiseren van de deploymentprocessen. Deze aanpak heeft niet alleen de samenwerking binnen ons team verbeterd, maar ook de controle over de gehele ontwikkelingscyclus versterkt.

## 4. Onderzoek

Mijn onderzoek richtte zich op de implementatie van SonarQube binnen onze ontwikkelomgeving. Gedurende dit proces heb ik verschillende uitdagingen overwonnen en waardevolle inzichten opgedaan.

In eerste instantie slaagde ik erin om SonarQube lokaal aan de praat te krijgen, wat me hielp om de functionaliteit en de voordelen van de tool te begrijpen. Echter, toen ik probeerde SonarQube op ons Kubernetes-cluster te implementeren, stuitte ik op verschillende problemen. Een belangrijk obstakel was dat SonarQube een webhook URL vereiste voor integratie, wat een ingress-configuratie noodzakelijk maakte. Aangezien SonarQube aanvankelijk alleen via localhost draaide, bleek het een uitdaging om deze tool extern toegankelijk te maken.

Om deze problemen aan te pakken, heb ik handmatig de benodigde YAML-bestanden voor SonarQube geschreven, omdat er complicaties waren met de HELM-installatie en de persistent volumes. Mijn beperkte ervaring met Kubernetes en de Rancher-omgeving maakte het moeilijk om alles in één keer goed te configureren. Dit leidde tot frustratie, maar tegelijkertijd was het een leerzame ervaring. Ondanks deze uitdagingen heb ik veel geleerd over het configureren van ingresses en het beheer van netwerkinstellingen. Deze ervaring heeft niet alleen mijn technische vaardigheden vergroot, maar ook mijn begrip van de waarde van SonarQube in het verbeteren van de codekwaliteit en het bevorderen van teamcommunicatie.

## 5. Bijdrage code review/kwaliteit anderen en security

In mijn rol binnen het team heb ik bijgedragen aan het verbeteren van de codekwaliteit van ons project door SonarQube te implementeren. Deze tool is cruciaal voor het bewaken van de codekwaliteit en het identificeren van technische schulden, wat essentieel is voor het succes van ons project. Door SonarQube te integreren, hebben we in staat gesteld om automatisch feedback te ontvangen over de kwaliteit van de code, wat ons helpt om een hoge standaard te handhaven.

Helaas, door tijdnood en de uitdagingen die gepaard gingen met de implementatie van SonarQube, ben ik niet in staat geweest om actief deel te nemen aan de code reviews van mijn teamleden. Dit was een gemis, omdat code reviews niet alleen bijdragen aan de kwaliteit van de code, maar ook aan de ontwikkeling van de vaardigheden van het team. Ondanks het ontbreken van directe reviews, blijft de implementatie van SonarQube een belangrijke stap in het verbeteren van de algehele codekwaliteit en het bevorderen van best practices binnen ons team.

In de toekomst hoop ik in staat te zijn om meer tijd te besteden aan het uitvoeren van code reviews, zodat ik mijn bijdragen aan de kwaliteit en beveiliging van de code van anderen verder kan versterken.

## 6. Bijdrage documentatie

Ik heb bijgedragen aan de documentatie door user stories om te zetten in GitHub issues met de bijbehorende acceptatiecriteria, wat helpt bij het structureren en prioriteren van ons werk. Daarnaast heb ik Architectural Decision Record (ADR) 5 opgesteld, waarin belangrijke beslissingen en overwegingen omtrent ons project zijn vastgelegd. Deze bijdragen zijn essentieel voor de transparantie en continuïteit van onze ontwikkelingsprocessen.

1. [GitHub Issues/Acceptatie criteria](https://github.com/hanaim-devops/pitstop-team-luna/issues)
2. [ADR-5](/docs/adr.md)

## 7. Bijdrage Agile werken, groepsproces, communicatie opdrachtgever en soft skills

Tijdens het project heb ik actief deelgenomen aan de Scrum-ceremonies en heb ik bijgedragen aan zowel het groepsproces als de communicatie met de opdrachtgever. Enkele voorbeelden van mijn bijdragen zijn:

### Activiteiten als Scrummaster

1. **Leiden van Scrum Ceremonies**: De Scrum-ceremonies, zoals Sprint Planning, Daily Stand-ups, Sprint Review en Retrospective, faciliteren en ervoor zorgen dat deze efficiënt en doelgericht verlopen.

2. **Ondersteunen van Teamleden**: Teamleden coachen en ondersteunen in hun rol, evenals het bevorderen van een cultuur van samenwerking en open communicatie.

### Activiteiten als Teamlid

1. **Deelnemen aan Sprint Planning**: Actief bijdragen aan het plannen van de sprint door user stories te bespreken, prioriteiten te stellen en schattingen te geven.

2. **Bijwonen van Daily Stand-ups**: Dagelijks deelnemen aan de stand-up meetings om updates te geven over de voortgang, obstakels te bespreken en de focus voor de dag te bepalen.

## 8. Leerervaringen

Gedurende dit project heb ik waardevolle leerervaringen opgedaan die me zullen helpen in mijn verdere loopbaan. Hieronder deel ik enkele tips en tops die ik uit deze ervaringen heb gehaald:

### Tips

1. **Beter tijdsmanagement**: Plan tijd voor zowel onderzoek als implementatie om ervoor te zorgen dat er voldoende tijd is om een onderwerp grondig te verkennen en te integreren in het project. 
2. **Proactieve communicatie**: Communiceer vroegtijdig met teamgenoten en de opdrachtgever over eventuele problemen of obstakels, zodat er samen naar oplossingen kan worden gezocht.

### Tops

1. **Teamwerk**: De samenwerking binnen ons team was uitstekend en efficiënt. We hebben elkaar effectief ondersteund.

2. **Ondersteuning**: Ik heb proactief mijn teamgenoten bijgestaan in hun taken wanneer zij hulp nodig hadden. Dit heeft bijgedragen aan een positieve werksfeer en een gestage voortgang van het project.

## 9. Conclusie & feedback

Terugkijkend op dit project baal ik er ontzettend van dat we tegen zoveel verschillende problemen zijn aangelopen. Allemaal kostbare tijd die ik veel liever in Pitstop zelf gestoken had. Achteraf hoorde ik dat voorgaande jaren Pitstop al in een veel vroeg stadium hadden gedeployed. Dit had voor ons ook een hoop tijd kunnen schelen.

Verder kijk ik voor mijn persoonlijke ontwikkeling goed terug op het project. Wanneer je tegen problemen aanloop duik je dieper in de desbetreffende technologie. Zo is Kubernetes en het gebruik van Yaml-bestanden voor mij een heel stuk duidelijker geworden en weet ik zeker dat dit ook voor een positieve groei heeft gezorgd. 

