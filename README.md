# Random getter deck card ❤️ ♣ ♦️ ♠️ 

**Project description:**<br>
This is a library that returns a deck card and it is possible to use it in projects related to deck card games. 
More information regarding code explanations is available in *Code discussion* section.
 &nbsp;<br><br> 
An example test code can be cloned [here](https://github.com/delpitec/Csharp_.NETFramework_TestRandomic.dll.git). <br> 
Check its README.md and the code for understand the application. 
 &nbsp;<br><br>
![print_pgm](https://user-images.githubusercontent.com/58537514/134566378-a1337d74-32d9-4ba7-afa1-e5af1577a56b.png)
 &nbsp;<br><br><br>
**Project status:**<br>
✅ Done 
 &nbsp;<br><br> 
**Project steps:**<br>
> Random values getters: <br>
  ✅ DeckCard Get()<br>
  ✅ DeckCard GetExceptingOne()<br>
  ✅ DeckCard GetExceptingList()<br> 

**Code discussion:**<br>
🔴 1 - Why "DeckCard" instead of "Card" names usage? <br>
Because maybe one day me (or you, or anyone) may increase the lib feature and insert other cards type random selection like Yu Gi Oh cards, Uno cards, Truco cards, etc.<br><br>
🔴 2 - How to use this .dll file:<br>
- Clone this repository;<br>
- Add the .dll file and .xml files at the same folder in the new project;<br>
- In Solution Explorer, double-click the My Project node for the project;<br>
- In the Project Designer, click the References tab (if the file is not available, go to Browse tab and search the .dll file);<br>
- In the Add Reference dialog box, select the tab indicating the type of component you want to reference;<br>
- Add the following comand where the .dll functions will be used:<br>
```ruby
using Randomic;
```

🔴 3 - public enum DeckCardSuit:<br>
Deck Card Suit are defined at this enum using attributes containing the UTF-16 code and the suit color.
I used at this way because of two reasons:<br> 
1st: It was to facilitate the selection of the suit (By Random.Next), since we can use the function with range of values from 0 to 3 and associate it to the enum that contains all the attributes of the randomlys elected suit (obviously this could have been done using a class in a list/vector but this introduces the second reason). <br>
2nd: I wanted to understand the use of attributes in C# a little better.<br><br>
I could get both attributes values with these code lines (i really suggest you search it on code to understando whole context):<br>

```ruby
SuitUTF16 = typeof(DeckCardSuit).GetField(Enum.GetName(typeof(DeckCardSuit), suit)).GetCustomAttribute<SuitAttribute>(false).Utf16Code;
SuitColor = typeof(DeckCardSuit).GetField(Enum.GetName(typeof(DeckCardSuit), suit)).GetCustomAttribute<SuitAttribute>(false).SuitColor;
```
&nbsp;<br>
🔴 4 - Card properties and methods:<br>
I could explain all the cards propierties, but I thik the image bellow will help a lot to understand the Card Class and just bellow picture, I made some clarifications:<br>
![print_cardex](https://user-images.githubusercontent.com/58537514/134568738-15646ef3-ba16-4fc7-aa21-a30a7dbe8651.png)
&nbsp;<br>
1) Why do I used the card value instead of only card symbol?<br>
Answer: Because of the A card may have two values, and this bring us a uncomfortable situation due ramdon get card (more explained in the next topic *5 - Compare cards definitions*<br>
2) Why used a property for the Suit Color if it is a Suit attribute?<br>
Answer: Because I wanna get fast and direct the color value (Console Color type) for use due the Console Write as we can see in the previously presented example. For use it with windows forms, a color conversion will be need.<br><br>
All methodos are self descriptive and the external methodos/properties has code comments.<br><br>
Following is the only method I would like talk about. As we saw, the A card can have numeric value 1 or 14. Because of this, I added this method for change an A card numeric value (this could be helpfull for use in a card game situation. This only works with A card because is the only card that may have two values.
&nbsp;<br>
```ruby
 public static void ChangeAceNumericValue(DeckCard aceCard)
```

🔴 5 - Compare cards definitions:<br>
Here we can see the code section where the comparison is done. As we saw before, we give a card value according to the symbol (2 to 10, J, Q, K, A) but the problem is the A symbol can represents a numeric value of 1 or 14. Because of this, I decided to use the Symbol (with the suit) to compare one card to other. At this way, we have only 13 values (per suit) that wil be comparated instead of 14 ( 1 to 14 = 2x A card). Using this way, we will have the same probability to get each card (at other way - using the numeric value to compare cards -, it would be 1/7 (14%) to get A and 1/13 (7%) to get each of other cards in a randomic selection.
&nbsp;<br>
```ruby
 public override int GetHashCode()
        {
            return SuitUTF16.GetHashCode() + Symbol.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DeckCard))
            {
                return false;
            }
            else
            {
                DeckCard InputObj = obj as DeckCard;
                return this.SuitUTF16.Equals(InputObj.SuitUTF16) && this.Symbol.Equals(InputObj.Symbol);
            }
        }
```
 &nbsp;<br> 
## Contact me:
💼[LinkedIn](https://br.linkedin.com/in/rafaeldelpino)&nbsp;&nbsp;&nbsp;
📹[Youtube](https://www.youtube.com/delpitec)&nbsp;&nbsp;&nbsp;
📸[Instagram](https://www.instagram.com/delpitec_/)&nbsp;&nbsp;&nbsp;
📧[E-mail](delpitec@gmail.com)&nbsp;&nbsp;&nbsp;
