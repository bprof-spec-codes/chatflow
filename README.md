# Chatflow

## Tartalomjegyzék:

 - [Csapat felállás](#csapat-felállás)
 - [Telepítési, és lokális futtatási útmutató](#telepítési-és-lokális-futtatási-útmutató)
 - [Megadott bejelentkezési adatok](#megadott-bejelentkezési-adatok)
 - [Használt API-k](#használt-api-k)
 - [Oldal ismertetése a felhasználó számára](#oldal-ismertetése-a-felhasználó-számára)
 - [Probléma jegyzőkönyv](#probléma-jegyzőkönyv)

## Csapat felállás
Fejlesztők:
	-Frontend: Lengyel Tamás, Szabó Dáriusz  
	-Backend: Buzási Simon, Bihari Boldizsár  
	-Csapatkapitány: Bogdán Roland  
  
Használt technológiák:  
	-Frotend: React  
	-Backend: ASP .NET  
	-Adatbázis: Microsoft Azure  

## Telepítési és lokális futtatási útmutató
Az alkalmazás lokális hostolásához és futtatásához, első sorban a következőket kell telepítenünk, feltéve hogy még nincsenek telepítve:

 - [.NET core 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)
 - [Node.js](https://nodejs.org/en/)
 - [Visual Studio Code](https://code.visualstudio.com/)

Ezek után, először a backendet kell elindítanunk, amit a következő képpen tudunk megtenni:

 - Először egy Visual Studio Code-ot kell nyitnunk, majd bal fent a *File -> Open Folder...* opciónál ki kell keressük a projekt mappáját, azon belül is a *ChatFlow* nevű mappát, és ezt megnyitnunk.
![Step1](https://i.imgur.com/TB0yxwk.png)
![Step2](https://i.imgur.com/9kv3Hrh.png)
 - Ezután az alkalmazásban a *Terminal -> New Terminal* segítségével nyitni egy terminált, ahova a `dotnet build` parancsot kell beírjuk, majd egy entert nyomnunk. Ez pár másodpercig el fog tartani.
![Step3](https://i.imgur.com/FMslTqs.png)
 - Következő lépésként, tegyük le tálcára a Visual Studio alkalmazást (még szükség lesz rá), és a projekt könyvtárába navigáljunk. Itt a *ChatFlow/ChatFlow/bin/Debug/net5.0/* mappát, ahol (windows-on) egy *ChatFlow.exe* fájlt találunk, ezt indítsuk el.
![step4](https://i.imgur.com/x0peiAC.png)
 - Utolsó lépésként, menjünk vissza a Visual Studio Code-ba, ahol *File -> Open Folder...* segítségével most a *chatflow-web* mappát nyissuk meg. Ezután a terminál segítségével (ha nincs már ott a terminál a korábbi lépésekben látható a megnyitása) írjunk be egy *npm install* parancsot, ezt enterrel futtassuk le (ezt egyszer kell megtenni, későbbi indításoknál elég a következő parancs), majd egy *npm start* parancs segítségével elindul az alkalmazás frontend része.
![Step5](https://i.imgur.com/zxtck9v.png)
![Step6](https://i.imgur.com/QdKwx3Q.png)

## Megadott bejelentkezési adatok
A bejelentkezéshez egy felhasználóra van szükségünk, ezt a rendszerben adminok által előre elkészített felhasználókkal tehetjük meg, a felhasználónév és jelszó kombinációjával. A jelenlegi létező felhasználók, és szerepköreik a következők:
 - Admin felhasználó, admin szerepkör
	 - Email: admin@mail.com
	 - Felhasználónév: admin
	 - Jelszó: admin
  - Kovács András, tanár szerepkör
	 - Email: kovacs.andras@uni-obuda.hu
	 - Felhasználónév: kovacs.andras
	 - Jelszó: andras
 - Sipos Miklós, tanár szerepkör
	 - Email: sipos.miklos@uni-obuda.hu
	 - Felhasználónév: sipos.miklos
	 - Jelszó: miklos
 - Bihari Boldizsár, diák szerepkör
	 - Email: boldibihari@stud.uni-obuda.hu
	 - Felhasználónév: boldi.bihari
	 - Jelszó: boldi
 - Bogdán Roland, diák szerepkör
	 - Email: bogdanroland@stud.uni-obuda.hu
	 - Felhasználónév: bogdan.roland
	 - Jelszó: roland
 - Buzási Simon, diák szerepkör
	 - Email: buzasi.simon@stud.uni-obuda.hu
	 - Felhasználónév: buzasi.simon
	 - Jelszó: simon
 - Lengyel Tamás, diák szerepkör
	 - Email: tamas.lengyel@stud.uni-obuda.hu
	 - Felhasználónév: tamas.lengyel
	 - Jelszó: tamas
 - Szabó Dáriusz, diák szerepkör
	 - Email: dariusz@stud.uni-obuda.hu
	 - Felhasználónév: dariusz.szabo
	 - Jelszó: dariusz
	 
## Használt API-k
Az alkalmazás a következő API-okat használja:
|Controller|Http request|API|Role|Description|
|--|--|--|--|--|
|Auth|$POST(userid)(roomid)|/auth/{userid}/{roomid}|A|Add a user to a room|
|Auth|$DELETE(userid)(roomid)|/auth/{userid}/{roomid}|A|Remove a user from a room|
|Auth|$GET|/auth|A|Get every user|
|Auth|$POST|/auth/login + JSON|-|User login|
|Auth|$GET|/auth/allroom|S,T|Get every room of a user|
|Room|$GET|/room|A|Get every room|
|Room|$GET(idRoom)|/room/{idRoom}|A,S,T|Get one room with all of its data|
|Room|$POST|/room + JSON|A|Add a room|
|Room|$DELETE(idRoom)|/room/{idRoom}|A|Delete a room|
|Room|$PUT|/room + JSON|A|Edit a room|
|Room|$POST(idRoom)|/room/{idRoom} + JSON|S,T|Add a thread to a room (write a thread)|
|Room|$GET(idRoom)|/room/alluser/{idRoom}|A,S,T|Get every user of a room|
|Thread|$GET(idRoom)|/threads/Room/{idRoom}|S,T|Get every thread of a room|
|Thread|$GET(idRoom)|/threads/Pinned/{idRoom}|S,T|Get every pinned thread of a room|
|Thread|$PUT(idThreads)|/threads/Pin/{idThreads}|T|Pin a thread (max 3)|
|Thread|$PUT(idThreads)|/threads/DeletePin/{idThreads}|T|Unpin a thread|
|Thread|$POST(idThreads)|/threads/AddReaction/{idThreads} + JSON|S,T|React to thread|
|Thread|$DELETE(idThreads)|/threads/DeleteReaction/{idThreads}|S,T|Remove the reaction from the thread|
|Thread|$PUT|/threads/UpdateReaction + JSON|S,T|Change the reaction|
|Thread|$GET(idThreads)|/threads/Reactions/{idThreads}|S,T|Get one thread's every reaction|
|Message|$GET(idThreads)|/messages/{idThreads}|S,T|Get every message of a thread|
|Message|$POST(idThreads)|/messages/{idThreads} + JSON|S,T|Reply to a thread (add message to thread)|
|Message|$POST(idMessages)|/messages/AddReaction/{idMessages} + JSON|S,T|React to a message|
|Message|$DELETE(idReaction)|/messages/DeleteReaction/{idMessages}|S,T|Delete the reaction from the message|
|Message|$PUT|/messages/UpdateReaction + JSON|S,T|Change the reaction|
|Message|$GET(idMessages)|/messages/Reactions/{idMessages}|S,T|Get one messages every reaction|

## Oldal ismertetése a felhasználó számára
Bejelentkezési felület
 - Ezen a felületen lehet bejelentkezni a felhasználónevünkkel, és a jelszavunkkal ![ui1](https://i.imgur.com/FD5Symv.png)

Főoldal
 - Ha bejelentkeztünk, az alkalmazás főoldalán találjuk magunkat.
 - Bal oldalsó oszlopban találhatóak a különböző szobák ahová a felhasználó tartozik, ezek között lehet váltani, ekkor a többi panel is frissül.
 - A középső része az oldalnak a szobában található posztok/thread-ek. Ezekre lehet reagálni, válaszolni, és tanárok tudnak pinnelni is.
 - Alul tudunk írni új posztot a kiválasztott szobába.
![ui2](https://i.imgur.com/PHMiOc7.png)
 - A jobb felső sarokban egy gombostűre kattintva láthatjuk a pinnelt üzeneteket
![ui4](https://i.imgur.com/PU60Xgc.png)
 - A posztokon a *Reply to* gombra kattintva, megjelennek jobb oldalt a poszthoz fűzött kommentek, üzenetek.
 - Itt ugyanúgy alul tudunk válaszolni.
![ui3](https://i.imgur.com/170WHZF.png)
 
 Admin felület

 - Ha admin felhasználóval (admin <> admin) lépünk be, és utána a link végére odaírjuk hogy */admin*, akkor az admin felületre jutunk, ahol a felhasználókat és a szobákat tudjuk kezelni.
![adminui1](https://i.imgur.com/KpmxzlK.png)
 - Az oldalon tudunk tanulót szobához rendelni.
![adminui2](https://i.imgur.com/TBdxqzs.png)
 - Szobát létrehozni.
![adminui3](https://i.imgur.com/EKtEcwY.png)
 - És szobát törölni.
![adminui4](https://i.imgur.com/3pqdjTe.png)
 

## Probléma jegyzőkönyv

 1. Első problémaként egy nehézséget írnék, ami pedig a frontend csapatnál volt, a React megtanulása. Korábban nem használt egyikünk sem semmiféle frontend library-t sem, így az, hogy egyből egy nagyobb volumenű projektben kellett bevetni a frissen megtanult tudást, sok időt vett igénybe.
	 - Megoldásként igazából a frontendesek szorgos munkáját, és tanulásra való affinitását tudnám mondani.
2. Második probléma ami fellépett, az az adatbázis tervezése során volt, mégpedig egy many-to-many kapcsolat a megtervezett adatbázis táblái között.
	 - Ezt a problémát egy kapcsolótábla segítségével oldottuk meg.
 3. Frontend részen még probléma volt, az @-el való user-ek megjelölése a thread-ekben. A beépített input mezőkben erre nem volt lehetőség, se html-ben, se a használt Ant design komponensekben.
	 - Egy saját input komponenst kellett létrehoznunk, amiben regular expression segítségével határozható meg például a link, vagy a leütött @ karakter. Ha ezeket megtalálja a szövegben, akkor html tag-be wrap-eli őket, hogy elküldéskor látható legyen.
 4. A backend részen még felmerült probléma, hogy az authentikációnál, a beépített IdentityUser osztálynak nem voltak olyan tulajdonságai amire szükségünk volt.
	 - Ezt egy egyszerű öröklődéssel sikerült megoldani.
 5. Ötödik problémaként, a tervezés során felmerült, hogy a szobákban a thread-ek, és a thread-ekre való válasz üzenetek majdnem teljesen ugyanazok az osztályok voltak, így redundancia miatt próbáltuk ezt elkerülni.
	 - Végül hogy ne legyen végtelenül egymásba ágyazva egy ("üzenetbe egy üzenet amiben van egy üzenet..."), külön lettek szedve a Thread és a Message osztályok.
