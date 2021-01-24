Vad du valt att testa och varför? 
- Du behöver lägga till enhetstest (inte ett integrations- eller end-to-end-test) som testar en metod. Förslagsvis en metod utan sidoeffekter. Gör även en kort beskrivning om varför det underlättar att testa en metod utan sidoeffekter. Denna text ska ha källhänvisningar (exempelvis till Clean code).

Valde att göra ett test för att se så man inte fick tillbaka några filmer med samma dubbletter.
Gjorde även ett test för att se så filmerna sorterades efter rating ordentligt. 

två utav de testerna du efterfrågar är RemoveDublicatesTest() och SortMovieListTest(). Detta är test som är isolerade och testar bara en grej. Det underlättar att göra enhetstester på funktioner utan sidoeffekter pga att man vill inte ha långa test funktioner där det händer massor av saker. Man vill ha tester som är lättförståliga och som endast gör det som den test metoden heter.

källhänvisningar från https://enos.itcollege.ee/~jpoial/oop/naited/Clean%20Code.pdf


Vilket/vilka designmönster har du valt, varför? Hade det gått att göra på ett annat sätt? 

Jag valde att lägga in singleton för httpclienten så att den skapas upp engång och sedan återanvänds under hela tiden. Att instansierar upp en ny httpclient för varje request kommer antalet sockets som är tillgängliga under tunga belastningar att tömmas. Detta kommer att resultera i SocketException-fel.

det är svårt och dumt att arbeta proaktivt med design mönster. De ska ju inte användast för att, de ska användas för att lösa ett problem och i en sån här liten uppgift är det svårt att hitta designmönster som är applicerbara.


Hur mycket valde du att optimera koden, varför är det en rimlig nivå för vårt program?

Jag försökte få en lättläslig kod med lättförståeliga metod- och variabelnamn. Flyttade ut all logik till MovieService klassen från controllern så det bara var anrop kvar i controllern till servicsen. 
