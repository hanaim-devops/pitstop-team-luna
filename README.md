# Pitstop - Garage Management System
This repo contains a sample application based on a Garage Management System for Pitstop - a fictitious garage / car repair shop. The primary goal of this sample is to demonstrate several software-architecture concepts like:  
* Microservices  
* CQRS  
* Event driven Architecture  
* Event sourcing  
* Domain Driven Design (DDD)  
* Eventual Consistency  

and how to use container-technologies like:

* Docker
* Kubernetes
* Istio (service-mesh)
* Linkerd (service-mesh)

See [the Wiki for this repository](https://github.com/EdwinVW/pitstop/wiki "Pitstop Wiki") for more information about the solution and instructions on how to build, run and test the application using Docker-compose and Kubernetes.

![](pitstop-garage.png)

> This is an actual garage somewhere in Dresden Germany. Thanks to Thomas Moerkerken for the picture!

slack invite: https://join.slack.com/t/pitstop-luna/shared_invite/zt-2spmmbuc5-0NxJT2TPwBu3YBC9zX6BDQ

## Casus: Notificatiesysteem voor Snellere Reactie en Efficiënter Gebruik van Werkplaatsen

Het doel van dit project is om het bestaande notificatiesysteem van Pitstop uit te breiden met real-time notificaties voor klanten. Deze notificaties zorgen ervoor dat klanten direct op de hoogte worden gebracht van de status van hun reparatie en dat monteurs efficiënter kunnen werken. Dit is een verbetering ten opzichte van het huidige systeem, dat enkel notificaties verstuurt over aankomende onderhoudsbeurten.

### Overzicht van het Nieuwe Notificatiesysteem

Het nieuwe systeem stuurt klanten notificaties bij de volgende gebeurtenissen:

1. **Reparatie Gestart** – De klant ontvangt een melding wanneer de monteur de reparatie heeft aangemeld en de klant informeert over de status.
2. **Klant Goedkeuring Vereist** – Indien extra kosten of werkzaamheden nodig zijn, ontvangt de klant een notificatie met een overzicht van de prijs en werkzaamheden. De klant kan de reparatie hier goedkeuren of afwijzen.
3. **Reparatie Voltooid** – Zodra de reparatie klaar is, ontvangt de klant een bevestiging dat het voertuig kan worden opgehaald.

### Proces en Rollen

Het systeem introduceert drie gebruikersrollen om de communicatie en het werkproces te optimaliseren:

**Monteur**: kan voertuigen aanmelden voor reparatie en specificeren wat er gerepareerd moet worden. De monteur ontvangt een bevestiging als de klant akkoord gaat of ziet een afwijzing als de klant niet akkoord gaat met de prijs.
**Klantenservice**: heeft een overzicht van alle berichtenuitwisselingen tussen monteurs en klanten en kan helpen bij vragen of problemen tijdens de communicatie.
**Werkplaatsmanager**: heeft toegang tot statistieken over reactietijden en goedkeuringstijden, wat helpt bij het verbeteren van de doorlooptijd en het efficiënter inzetten van werkplaatsen.

### Doel

Dit uitgebreide notificatiesysteem vermindert de wachttijden doordat klanten sneller reageren op statusupdates. Door de tijdige goedkeuring en afwijzing van reparaties kunnen werkplaatsen optimaal worden benut, wat uiteindelijk zorgt voor een betere klanttevredenheid en een efficiëntere workflow in de garage.

## CDMM Groep self assessment

* 🧑‍🤝‍🧑 **Cultuur & Organisatie: 8.4** 🦆🦆
  * **CO-301 Dedicated tools team**: Specifieke tools voor het beroepsproduct zijn gebruikt. Dit zijn namelijk de technologieën die per teamlid zijn onderzocht.
  * **CO-302 Team verantwoordelijk voor productie**: Het hele team heeft grote inzet getoond om een zo goed mogelijk project op te zetten. Iedereen heeft gewerkt naar productie.
  * **CO-345 Continuous Improvement**: We hebben bestaande functionaliteiten uitgebreid en daarnaast een extra microservice toegevoegd, namelijk [RepairManagementAPI](src/RepairManagementAPI), [CustomerSupportAPI](src/CustomerSupportAPI/) en [CustomerSupportService](src/CustomerSupportService/).
  * **CO-401 Cross-functional team (CO-201++)**: We zijn allemaal gevorderd in de Ops-culturen.

* ⛪ **Ontwerp & Architectuur: 6.5** 🦆
  * **OA-301 Volledige componentgebaseerde architectuur**: Pitstop is al een op microservices gebaseerde applicatie en wij hebben daar ook nog onze eigen microservices aan toegevoegd, namelijk [RepairManagementAPI](src/RepairManagementAPI), [CustomerSupportAPI](src/CustomerSupportAPI/) en [CustomerSupportService](src/CustomerSupportService/).
  * **OA-201 Geen of minimale branching**: De branches die zijn gemaakt, zijn short-lived en zijn alleen aangemaakt in gevallen waarin er veel moeite kan ontstaan als er tegelijkertijd aan gewerkt wordt.
  * **OA-203 Configuratie als Code**: Alle manifestbestanden zijn YAML-bestanden, evenals de gemaakte policies, SonarQube en Prometheus. Deze zijn allemaal in YAML geschreven, zie voor grotendeels van deze bestanden de [k8s directory](src/k8s/).
  * **OA-205 Modules omzetten naar componenten**: Wat op de WebApp draait, hebben we allemaal in aparte microservices ondergebracht. Bijvoorbeeld [WorkshopManagementAPI](src/WorkshopManagementAPI/), [CustomerSupportAPI](src/CustomerSupportAPI/) en [RepairManagementAPI](src/RepairManagementAPI). Dit zou een module zijn als deze allemaal binnen de WebApp zouden functioneren.

* 🏗️ **Build & Deploy: 6.2** 🦆
  * **BD-202 Geautomatiseerde tags & versies**: Automatische tagging is aangemaakt in de [pipeline.](../pitstop-team-luna/.github/workflows/pipeline.yaml).
  * **BD-205 Basis pipeline, prod deploy**: Er is een [pipeline](../pitstop-team-luna/.github/workflows/pipeline.yaml) gemaakt met de bijbehorende deployment naar productie.
  * **BD-207 Standaard proces voor alle omgevingen**: Alle omgevingen delen dezelfde pipeline en dezelfde manier van bouwen en deployen.
  * **BD-303 Volledig automatische DB deploys**: De database draait in een pod, waardoor deze volledig automatisch wordt gedeployed.

* 🧪 **Test & Verification: 2** 😴
  * **TV-001 Automatische unit tests**: De [pipeline](../pitstop-team-luna/.github/workflows/pipeline.yaml) is geconfigureerd om alle unit tests automatisch uit te voeren (Build & Test).
  * **TV-002 Aparte testomgeving**: Zie WorkshopManagementAPI.UnitTests en UITests.

* 📈 **Information & Reporting: 6.5** 🦆s
  * **IR-201 Gedeeld informatiemodel**: Zie [README.md](src/README.md) in de src-directory; daar staat een C4-model, ook zijn er verschillende ADR's beschikbaar, zie [ADR.md](docs/adr.md).
  * **IR-203 Rapportagehistorie is beschikbaar**: Alles wordt bijgehouden door de gebruikte tool, namelijk GitHub, van het creëren van branches tot het maken van taken en het voltooien van taken.
  * **IR-302 Dynamische testcoverage-analyse**: Dit wordt gedaan door SonarQube.
