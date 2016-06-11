# Projekt_Dy-ury
Kod

# Projekt_Dyzury
Moim projektem jest program konsolowy który wspomaga naczelnego lekarza w tworzeniu planu dyzurow w szpitalu na dany miesiąc. 
Kolejne kroki jak stworzyć plan:

1. Podajemy nazwę miesiąca

2. Podajemy ilośc dni w danym miesiącu

3. Podajemy od jakiego dnia tygodnia rozpoczyna się dany miesiąc

4. Zaczynamy dodawać lekarzy (Warto tutaj dodać, że jeżeli liczba lekarzy będzie mniejsza niż 4 plan nie zostanie stworzony, 
dodawanie lekarzy powinno być pierwszą czynnością po otwarciu menu gdyż inne opcje nie mają większego sensu, 
program w niektórych istotnych fragmentach jest "błędoodporny" jeżeli chodzi o próby popsucia go jednak nie wszędzie.)

5. Po stworzeniu listy lekarzy możemy ją obejrzeć jak również włączyć tworzenie planu (lub poprawić błędy)

6. Gdy plan zostanie stworzony możemy go obejrzeć jak i zapisać do pliku w notatniku
(specjalnie stworzyłem zapisywanie przez wprowadzanie dokładnej ścieżki gdzie ma trafić aby zadziałało to na każdym komputerze).


Wybory które podjąłem :
Tworząc ten program konsultowałem się z moim ojcem który co miesiąc musi takie plany pisać. 
Dzięki niemu wiem, że w większości przypadków "tworzenie osoby" własnie tak działa. Większość lekarzy posiada swój ulubiony 
dzien w którym chce mieć dyzury, opcja dni niechcianych jest stworzona dla przypadku urlopów. 
Również program stara się dopasować aby wszyscy lekarze mieli identyczną ilość dyżurów żeby nikt nie czuł sie pokrzywdzony.
Zastanawiałem się nad stworzeniem programu tak aby zapisywał listę lekarzy, ich ulubione pory itd.
jednak dowiedziałem się, że ulubione dni czy pory praktycznie co miesiąc się dla danej osoby zmieniają, 
jak również zmieniają się dni niechciane. Często bywa też, że do danego szpitala na miesiąc przychodzą rezydenci czy 
studenci odbywający praktyki, tak więc lista zmienia się co miesiąc i nie uważam, że potrzebne jest zapisywanie jej.
Samo tworzenie zajmuje wystarczająco krótko.
Mój tata używając tego programu tworzy plan dyżurów w maksymalnie 10-15 minut gdzie wcześniej zajmowało mu to okolo 2 godzin.
Program nie jest doskonały, są przypadki gdy trzeba po stworzeniu planu ręcznie go lekko poprzesuwać,
ale takie rzeczy zawzyczaj lekarze ustalają już między sobą za obopólną zgodą.
Jedyną opcją której rozważałem dodanie jest ingerencja w stworzone już osoby. Z jednej strony mogło by to być użyteczne podczas pomyłki, z drugiej jednak strony gdy stworzy się daną listę raz czy dwa razy ciężko tutaj o pomyłkę, wszystko idzie automatycznie. W razie czego jestem skory do dodania takiej opcji, jak również czekam na inne propozycje rozwinięcia programu (nic innego nie przychodziło mi do głowy ;) )


Ponieważ wymyślić przykład działania programu nie jest łatwo 
(można oczywiście stworzyć miesiąc 10 dniowy i podac 4 lekarzy ale to nie ma zbyt dużego sensu, 
dodatkowo łatwo przez przypadek dla tak małej liczby dni stworzyć niemożliwe zadanie dla naszego programu) 
podam tutaj rzeczywistą liste które ostatnio w szpitalu mojego ojca zostały stworzone :

Czerwiec: (30 dni start od Sr'ody)

(Imie, nazwisko -> ulubiony dzien('No' oznacza brak ulubionego dnia), ilosc niechcianych dni, te dni)

Lekarz jeden -> Czw N 0

Lekarz dwa -> Sr D 0

Lekarz trzy -> Wt D 0

Lekarz cztery -> No 0

Lekarz piec -> No 9  [7, 14, 21, 28, 2, 9, 16, 23, 30]

Lekarz szesc -> No 25 [2, 3, 4, 5, 6, 7, 9, 10, 11, 12, 13, 14, 16, 17, 18, 19, 20, 21, 23, 24, 25, 26, 27, 28, 30] 

Lekarz siedem -> No 0

Lekarz osiem -> No 0 

Lekarz dziewiec -> 5 [1, 8, 15, 22, 29]

Lekarz dziesiec -> Sb D

Lekarz jedenascie  -> Sb N

Lekarz dwanascie -> Nd D

Aby program miał więcej roboty osobom bez niechcianych dni można spróbować podopisywać kilka losowych ;) 

Uzywałem nazw polskich, żeby w niektórych momentach samemu sie w tym nie pogubić.

