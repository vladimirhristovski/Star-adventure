# Star adventure
## Windows Forms Project by: Vladimir Hristovski(223030) and Magdalena Trajkovska(223156)

### Објаснување на проектот:
Нашата апликација Star adventure претставува едноставна видео игра со мотив од Star Wars франшизата во која играчот, односно ние, имаме за цел да собереме што е можно повеќе ѕвездички во вселената. 
Ние управуваме со славниот Millennium Falcon од Star Wars филмовите и со кој ние треба да одбегнуваме астероиди кои на почетокот на играта се во мал број но како што напредуваме во играта, односно како што собираме повеќе ѕвездички така се појавуваат и повеќе астероиди.
Исто така како што знаеме Millennium Falcon е еден од најбрзите вселенски бродови во Star Wars франшизата, па така и во нашата апликација со собирање на ѕвездички ние стануваме се побрзи и побрзи. Колку побрзи? Засега според познати извори знаеме дека во Star Wars франшизата максималната брзина на Millennium Falcon изнесува 1050 km/h. Пробајте и тестирајте ја вистинската брзина на нашиот Millennium Falcon во нашата апликација.

### Упатство за играње
При стартување на апликацијата првично ќе ви се појави карактеристичен текст, налик на воведот во Star Wars филмовите и под него копче Play.
Со притискање на копчето Play вие започнувате со играње.
Ваша цел е да соберите што е можно повеќе ѕвездички.
Бидете внимателни бидејќи во вселената има астероиди кои можат многу лесно да ве уништат.
Вие можите да се движите со помош на стрелките од тастатурата или со WASD копчињата, каде:
- W - придвижување на горе
- A - придвижување на лево
- S - придвижување на долу
- D - придвижување на десно

### Опис на решението


### Опис на функцијата ```public PictureBox checkIntersection(PictureBox e)```
```C#
public PictureBox checkIntersection(PictureBox e)
        {
            List<PictureBox> list = Everything.Where(v => v != e).ToList();
            foreach (PictureBox anything in list)
            {
                    while (anything.Bounds.IntersectsWith(e.Bounds) && anything.Visible)
                    {
                        e.Left = Random.Next(0, 381);
                    }
            }
            return e;
        }
```
        
Со оваа функција ние проверуваме дали некој објект од класата PictureBox, односно астероидите и ѕвездичките се наоѓа еден врз друг.
Првично се креира нова листа list во која од листата Everything, каде се наоѓаат сите астероиди и ѕвездички, се изоставува објектот од класата PictureBox кој што го праќаме како аргумент на функцијата, за да не дојдеме во бесконечен циклус.
Потоа итерираме низ листата list и доколку наидеме да објект од класата PictureBox кој што го препокрива објектот кој што го праќаме за проверка, објектот кој што е пратен на проверка добива нови координати по X - оската.
Ако случајно со новите координати по Х - оската повторно објектот е препокриен од објектот во листата list, повторно се доделуваат нови координати.
На крајот се враќа објектот од класата PictureBox со координати кои не препокриваат друг објект.


### Screenshots

   1. Старт на играта
      
   ![start](https://github.com/vladimirhristovski/Star-adventure/assets/139167699/a37819f7-0f22-4a1e-83b1-95609cbf9603)
   
   3. Играта во тек
      
   ![mid-play](https://github.com/vladimirhristovski/Star-adventure/assets/139167699/75667572-c5da-49b1-80b9-54ea6263c83c)
   
   5. Крај на играта
      
   ![gameover](https://github.com/vladimirhristovski/Star-adventure/assets/139167699/1448f566-8d10-473a-9168-3a1d8263a336)
   
   7. Приказ на табела со највисоки поени
      
   ![highscore-table](https://github.com/vladimirhristovski/Star-adventure/assets/139167699/f547032e-fc1f-4e8a-8f28-7012d3f52d3c)
   
   
   
      



