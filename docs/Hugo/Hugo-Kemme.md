# Eigen bijdrage Hugo Kemme

Voor dit project had iedereen een eigen user story en een onderzochte tool om te implementeren. Ik heb gewerkt aan de user story “[update ontvangen wanneer reparatie voltooid](https://github.com/orgs/hanaim-devops/projects/26?pane=issue&itemId=83312313&issue=hanaim-devops%7Cpitstop-team-luna%7C2).” Voor dit issue heb ik een [SlackMessenger](../src/NotificationService/NotificationChannels/ISlackMessenger.cs) geïmplementeerd, zodat de klant op Slack een bericht ontvangt wanneer zijn voertuig opgehaald kan worden. Verder heb ik Cloud Custodian onderzocht en geprobeerd te implementeren. Dit is echter niet gelukt. Voor Cloud Custodian had ik de live omgeving nodig om bepaalde policies te kunnen hanteren, maar wij hadden veel problemen met de live omgeving. Ik ben dus veel bezig geweest met de live omgeving en heb de pipeline opgezet voor het automatisch deployen en releasen naar de live omgeving.

## 1. Code/platform bijdrage

**Competenties**: *DevOps-1 Continuous Delivery*

Ik heb aan meerdere microservices gewerkt:

- Ik heb de SlackMessenger geïmplementeerd in de NotificationService. Zie [pull-request](https://github.com/hanaim-devops/pitstop-team-luna/pull/38).
- Voor mijn user story heb ik aanpassingen gemaakt in de WebApp en WorkshopManagementAPI.

## 2. Bijdrage app configuratie/containers/Kubernetes

**Competenties**: *DevOps-2 Orchestration, Containerization*

Ik ben verantwoordelijk geweest voor het opzetten van de live omgeving:
- Live omgeving opgezet ([Rancher PR](https://github.com/hanaim-devops/pitstop-team-luna/pull/41)).

## 3. Bijdrage versiebeheer, CI/CD pipeline en/of monitoring

**Competenties**: *DevOps-1 Continuous Delivery*, *DevOps-3 GitOps*, *DevOps-5 SlackOps*

Ik heb de pipeline ingericht voor het automatisch deployen en releasen:
- [Pipeline changes](./img/pipeline_bewijs.png).

## 4. Onderzoek

**Competenties**: *Nieuwsgierige houding*

Ik heb onderzoek gedaan naar Cloud Custodian. Dit is een tool die het principe “policy as code” hanteert. Hiermee kunnen op eenvoudige wijze policies worden geschreven in YAML-bestanden. Ik heb dit echter niet werkend kunnen krijgen. Ik wilde policies schrijven voor de verschillende "Persistent Volumes" die wij gebruikten op Rancher, waarbij ik wilde afdwingen dat de volumes versleuteld moesten zijn. Helaas lukte dit niet omdat de Helm-installatie voor Cloud Custodian verouderd is en niet door Rancher wordt ondersteund. Vervolgens probeerde ik Cloud Custodian zelf te draaien in een [pod](../../src/c7n), maar dit bracht te veel complicaties met zich mee.

### Gedetailleerde Foutanalyse

Rancher biedt zelf de mogelijkheid om charts te installeren. Toen ik hier zocht naar Cloud Custodian stond die er niet tussen. Op de website van Cloud Custodian is echter een repo die je kan installeren en een helm command om Cloud Custodian te installeren. Dit heb ik gedaan. Er was nu op Rancher een aparte namespace met een pod voor Cloud Custodian. Deze bleef echter crashen. Toen ben ik naar de GitHub-pagina gegaan van Cloud Custodian helm charts en zag ik dat deze al twee jaar niet meer is geüpdatet. Vervolgens heb ik zelf geprobeerd Cloud Custodian in een pod te draaien, maar dit werkte niet omdat die het cluster niet kon bereiken. Ik heb toen zelf Minikube geïnstalleerd op de pod om de context naar de groep 5-config te zetten, maar dat werkte ook niet.

## 5. Bijdrage code review/kwaliteit anderen en security

**Competenties**: *DevOps-7 Attitude*, *DevOps-4 DevSecOps*

Ik heb een aantal PR's gereviewd. Zie [afbeelding](./img/review_bewijs.png) en [GitHub](https://github.com/hanaim-devops/pitstop-team-luna/pulls?q=is%3Apr+reviewed-by%3A%40me).

## 6. Bijdrage documentatie

**Competenties**: *DevOps-6 Onderzoek*

In dit project heb ik geholpen met het opzetten van het planbord met alle bijbehorende issues. Daarnaast heb ik het C4-model gereviewd.
- [Review op C4 pull-request](https://github.com/hanaim-devops/pitstop-team-luna/pull/50).

## 7. Bijdrage Agile werken, groepsproces, communicatie opdrachtgever en soft skills

**Competenties**: *DevOps-1 Continuous Delivery*, *Agile*

Voor de planning van sprint 2 was ik voorzitter. Ik heb ook een paar keer de DSU geleid en het initiatief genomen om deze te starten.
- Scrum master in sprint 2 planning
- Altijd aanwezig bij DSU’s
- Teamgenoten geholpen met problemen

## 8. Leerervaringen

**Competenties**: *DevOps-7 Attitude*

Ik heb vooral veel geleerd rondom de pipeline. Ik had zelf nog nooit eerder een pipeline opgezet. Ik vond dit leuk om te doen en ook erg leerzaam, al kostte het veel tijd. Ook was het een nieuwe ervaring om code te schrijven en data door te geven op basis van events en commands. Dit was in het begin nogal een doolhof.

## 9. Conclusie & Feedback

**Conclusie**: In dit project heb ik waardevolle ervaring opgedaan met verschillende DevOps-praktijken. Ik heb een pipeline opgezet, in meerdere microservices gewerkt, en Kubernetes-configuraties opgezet, wat mijn kennis van CI/CD-processen en containerbeheer aanzienlijk heeft vergroot. Hoewel het implementeren van Cloud Custodian niet ging zoals gehoopt, heeft het proberen op te lossen van de problemen mij geholpen om mijn troubleshooting-vaardigheden te verbeteren. Door deel te nemen aan scrum-processen, zoals de planning en dagelijkse stand-ups, heb ik mijn vaardigheden in teamcommunicatie en probleemoplossing verbeterd, wat mijn bijdrage aan het team en mijn professionele ontwikkeling verder heeft versterkt.
