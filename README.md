
# Osobný projekt - C# a SQL

Jedná sa o osobný projekt ktorý som robil vo svojom voľnom čase aby som dokázal ukázať
že dokážem pracovať s týmito technológiami.

Priečinok SQLSkripty obsahuje 4 súbory a to:
* DDL.sql - SQL príkazy potrebné na vytvorenie databázy
* DML.sql - obsahuje odkaz na Google drive kde sú všetky príkazy na naplnenie databázy
* Procedury.sql - SQL príkazy na vytvorenie všetkých uložených procedúr ktoré boli využívané pri projekte
* udaje.txt - prihlasovacie údaje k dátam

Priečinok DataLayer obsahuje tri súbory a to:
* DataPristup.cs - obsahuje všetko ohľadom komunikácie s databázou
* Pomocky.cs - obsahuju dve funkcie na generáciu saltu (náhodný string) a na SHA256 hashovanie
* Queries.cs - využíva funkcie z DataPristup.cs a obsahuje všetky volanie uložených procedúr
V projekte bolo využité ORM Drapper. V priečinku DataLayer/Entities sa nachádzajú všetky
využíté triedy pre toto ORM.

Hlavná zložka obsahuje všetko GUI.