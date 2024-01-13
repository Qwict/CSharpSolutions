# Reservaties (English version below)

Voor een lokale fitness club houden alle leden met hun eventuele abonnementen bij. Het is aan jou om hiervan enkele functionaliteiten te vervolledigen.

## Domein

Het domein is relatief eenvoudig. Er zijn slechts 2 klassen die opgeslagen worden in de databank, namelijk `Member` en `Subscription`. Je mag tijdens het examen geen visibiliteit van de properties aanpassen. De andere klassen in het domein zijn `ValueObjects` die mee opgeslaan worden bij de klasse `Member` in de databank. Het kan zijn dat sommige `ValueObjects` niet correct gemapped zijn (in het begin).

## Puntenverdeling

De punten staan naast de vragen. Indien je solution niet compileert, krijg je 0/20. Eventuele code in commentaar wordt niet bekeken.

## Functionaliteiten

Er zijn twee primaire functionaliteiten die je dient te implementeren: het opzoeken van leden en het toevoegen van een lid.

## Packages

Alle packages zitten reeds in de projecten. Je dient geen extra packages via NuGet toe te voegen, mogelijks wel te gebruiken of te implementeren.

## Vraag 1 - Domein (10)

Wanneer iemand een nieuw maandabonnement koopt, moet een `Subscription` toegevoegd worden aan de lijst van alle abonnementen (`Subscriptions`) voor een bepaald lid. Implementeer de methode `AddSubscription` in de `Member` klasse, **gebruik zoveel mogelijk bestaande code**. Zorg dat de onderstaande unit tests slagen en betekenisvol zijn. Hou rekening met de overlapping van abonnementen.

- `Member_Should.Have_one_subscription_after_adding_subscription`
- `Member_Should.Not_add_subscription_when_overlapping_with_another`

## Vraag 2 - Unit Test (10)

Wanneer er een `Phonenumber` gecreeert wordt, zouden -indien er zijn- lege spaties moeten verdwijnen zodat ` 0476 123 456 ` toch `0476123456` als waarde heeft, daarnaast mag bij creatie het telefoonnummer niet leeg zijn of enkel bestaan uit spaties. Gebruik een `Guard` clausule vanuit het `Ardalis.GuardClauses` package. Implementeer de Unit Test `Phonenumber_Should.Be_stripped_of__spaces` **en** de test te laten slagen door de constructor van `Phonenumber` aan te passen.

## Vraag 3 - Configurations (10)

In de database zijn er nog enkele problemen die opgelost moeten worden door de `MemberConfiguration` correct te implementeren, maak de mapping expliciet (steun dus niet op de nullable project setting):
- De tabel krijgt als naam `Member`.
- De `DateOfBirth`,`Firstname` en `Lastname` van een `Member` moeten ingevuld zijn.
- De `Email` moet ingevuld zijn en heeft een maximale lengte van 200, de kolomnaam is `Email`.
- De `Phone` moet ingevuld zijn  en heeft een maximale lengte van 100, de kolomnaam is `Phone`.
- Als een `Member` verwijdert wordt uit de databank, moeten ook alle `Subscriptions` van die `Member` verwijderd worden. Zorg ervoor dat een `Subscription` niet kan bestaan zonder een gelinkte `Member`.

## Vraag 4 - Autorisatie (10)

De pagina `Members.Create`  mag alleen beschikbaar zijn voor `Administrators`. Daarnaast mag de knop `Add` op de `Members.Index` pagina enkel zichtbaar zijn voor `Administrators`. Implementeer de autorisatie voor deze pagina's. 

> Je hoeft je geen zorgen te maken dat de API call niet afgeschermd is voor deze vraag, omdat we gebruik maken van de `FakeAuthenticationProvider`.

## Vraag 5 - Filter (15)

Momenteel worden de `Members` opgehaald zonder enige filterfunctionaliteit in de Index pagina. Implementeer de filterfunctionaliteit zodat, wannneer de gebruiker in het zoekveld een karakter invult, de leden gefilterd worden op basis van hun naam. Aangezien er niet veel leden in de database zullen bestaan, dien je de filtering te laten gebeuren op de client. Gebruik de functie `SearchMembers` in de `Index.razor.cs` die gekoppeld is aan het zoekveld. Alleen de leden met een naam die de zoekterm bevat (hou geen rekening met upper-/lowercase) worden geretourneerd. Sorteer de lijst alfabetisch op `naam`. Hou er rekening mee dat de originele lijst steeds moet weergegeven worden indien er geen filter ingegeven is, ook na het initieel filteren dien je terug te filteren op de volledige lijst.

### Eindresultaat - Zoeken naar leden

https://user-images.githubusercontent.com/10981553/185666694-786a8a4c-bbde-44c2-bcf3-956dbc6e8ece.mov

## Vraag 6 - Create (25)

Het aanmaken van leden is momenteel niet erg functioneel, het bevat enkel de basiselementen en styling. Implementeer het toevoegformulier met behulp van de `MemberRequest.Create`, `Member.Create.razor`, `MemberController` en `MemberService.CreateAsync`(back-/front-end). Gebruik een `EditForm` met `FluentValidation` om er zeker van te zijn dat er geen ongeldige leden kunnen worden aangemaakt. Controleer de databaseregels en maak ze consistent (regels in de databank gelden ook voor de validatie). De `Validator` is een geneste klasse binnen de `MemberRequest.Create`. Nadat het lid is toegevoegd, dien je terug te navigeren naar de index pagina.

Daarnaast dien je ook de Server / API te beschermen tegen ongeldige leden, doe ook dit aan de hand van het `FluentValidation.AspNetCore` package en middleware.

> Je hoeft geen extra eigenschappen toe te voegen aan de `MemberRequest.Create`.

### Eindresultaat - Toevoegen van een lid

https://user-images.githubusercontent.com/10981553/185666738-c395d4da-79c2-4894-b565-3a4f9dcb191e.mov

## Vraag 7 - Localstorage (10)

Zelden worden er leden toegevoegd, het is dan ook omslachtig om steeds de leden uit de databank / vanop de server op te halen voor de Index pagina. Het idee is om via `LocalStorage` een cache aan te leggen die de eerste keer wordt opgevuld door een API call uit te voeren, nadien is er geen API call meer nodig om de leden op te halen, maar zal de data voor de `Index` pagina uit `LocalStorage` komen. Gebruik [Blazored.LocalStorage](https://github.com/Blazored/LocalStorage) in de `MemberService.GetIndexAsync` en `MemberService.CreateAsync` functie  (client-side). Vergeet ook niet als er een nieuw lid wordt toegevoegd, de localstorage met key `members` te verwijderen.

Gebruik de README.md en de examples van het project om de functionaliteit te implementeren.

## Vraag 8 - Theorie (10)

Beantwoord de volgende vragen inline in deze README.md:

1. Wat is het verschil tussen `internal` en `private` access modifiers?
  - Antwoord:
2. Wat zijn de nadelen van een moderne SPA applicatie?
  - Antwoord:

---

# Reservations (English version)

For a local fitness club, all members keep track of their subscriptions. It is up to you to complete some of these functionalities.

## Domain

The domain is relatively simple. There are only 2 classes that are stored in the database, namely `Member` and `Subscription`. You are not allowed to modify the visibility of the properties during the exam. The other classes in the domain are `ValueObjects` that are co-stored with the class `Member` in the database. However it could be that these properties are not mapped corrrectly from the start.

## Scoring

The points are next to the questions. If your solution does not compile, you will get 0/20. Any code in comments will not be considered.

## Functionalities.

There are two primary functionalities you need to implement: member lookup and adding a member.

## Packages

All packages are already included in the projects. You do not need to add additional packages via NuGet, possibly use or implement them.

## Question 1 - Domain (10)

When someone buys a new monthly subscription, a `Subscription` must be added to the list of all subscriptions (`Subscriptions`) for a given member. Implement the method `AddSubscription` in the `Member` class, **use as much existing code** as possible. Make sure the unit tests below are successful and meaningful. Keep in mind the overlap of subscriptions.

- `Member_Should.Have_one_subscription_after_adding_subscription`
- `Member_Should.Not_add_subscription_when_overlapping_with_another`

## Question 2 - Unit Test (10)

When a `Phonenumber` is created, -if there are- empty spaces should disappear so that ` 0476 123 456` still has `0476123456` as its value, in addition, at creation the phone number should not be empty or consist only of spaces. Use a `Guard` clause from the `Ardalis.GuardClauses` package. Implement the Unit Test `Phonenumber_Should.Be_stripped_of_spaces` **and** pass the test by modifying the constructor of `Phonenumber`.

## Question 3 - Configurations (10)

In the database there are still some problems to be solved by implementing the `MemberConfiguration` correctly, make the mapping explicit (i.e. do not rely on the nullable project setting):
- The table will be named `Member`.
- The `DateOfBirth`,`Firstname` and `Lastname` of a `Member` must be filled in.
- The `Email` must be populated and has a maximum length of 200, the column name is `Email`.
- The `Phone` must be populated and has a maximum length of 100, the column name is `Phone`.
- If a `Member` is removed from the database, all `Subscriptions` of that `Member` must also be removed. Make sure that a `Subscription` cannot exist without a linked `Member`.

## Question 4 - Authorization (10)

The `Members.Create` page must be available only to `Administrators`. In addition, the `Add` button on the `Members.Index` page should be visible only to `Administrators`. Implement authorization for these pages. 

> No need to worry that the API call is not shielded for this query because we are using the `FakeAuthenticationProvider`.

## Question 5 - Filter (15)

Currently the `Members` are retrieved without any filter functionality in the Index page. Implement filter functionality so that when the user enters a character in the search field, the members are filtered based on their name. Since not many members will exist in the database, you need to have the filtering done on the client. Use the `SearchMembers` function in the `Index.razor.cs` associated with the search field. Only members with a name containing the search term (do not consider upper/lowercase) will be returned. Sort the list alphabetically by `name`. Keep in mind that the original list should always be displayed if no filter is entered, even after initial filtering you should filter back to the full list.

### End result - Search for members

https://user-images.githubusercontent.com/10981553/185666694-786a8a4c-bbde-44c2-bcf3-956dbc6e8ece.mov

## Question 6 - Create (25)

Member creation is currently not very functional, containing only the basic elements and styling. Implement the add form using the `MemberRequest.Create`, `Member.Create.razor`, `MemberController` and `MemberService.CreateAsync`(back/front-end). Use an `EditForm` with `FluentValidation` to ensure that no invalid members can be created. Check the database rules and make them consistent (rules in the database also apply to validation). The `Validator` is a nested class within the `MemberRequest.Create`. After the member is added, you need to navigate back to the index page.

In addition, you also need to protect the Server / API from invalid members, again do this using the `FluentValidation.AspNetCore` package and middleware.

> You do not need to add additional properties to the `MemberRequest.Create`.

### End result - Adding a member

https://user-images.githubusercontent.com/10981553/185666738-c395d4da-79c2-4894-b565-3a4f9dcb191e.mov

## Question 7 - Localstorage (10)

Rarely members are added, therefore it is cumbersome to always fetch the members from the database / from the server for the Index page. The idea is to use `LocalStorage` to create a cache that is filled the first time by executing an API call, after that no API call is needed to retrieve the members, but the data for the `Index` page will come from `LocalStorage`. Use [Blazored.LocalStorage](https://github.com/Blazored/LocalStorage) in the `MemberService.GetIndexAsync` and `MemberService.CreateAsync` function (client-side). Also, when adding a new member, do not forget to remove the localstorage with key `members`.

Use the README.md and the project's examples to implement the functionality.

## Question 8 - Theory (10)

Answer the following questions inline in this README.md:

1. What is the difference between `internal` and `private` access modifiers?
  - Answer:
2. What are the disadvantages of a modern SPA application?
  - Answer:
