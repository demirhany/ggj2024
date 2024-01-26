using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Character
{
    public string charname;
    public int happiness;

    public Character(string name, int happiness)
    {
        charname = name;
        this.happiness = happiness;
    }
    public void DisplayInfo()
    {
        //Console.WriteLine($"Name: {charname}, Happiness: {happiness}");
    }
    public void IncrementHappiness()
    {
        this.happiness += 10;
    }
    public void DecrementOpponent(Character character2)
    {
        if (character2.happiness > 0)
        {
            character2.happiness -= 10;
        }
        else
        {
            //Console.WriteLine("happinest can't be negative");
        }
    }
}

public class Characters: MonoBehaviour 
{ /*1  Feminist ? 2, 7, 10 
    2 Siyasal Ýslamci ? 1, ~3, 6, 8, 9, 10
    3 Doða sever ? 10, 2
    4 Milliyetçi ? 8, 9, 10
    5 Geekler ?
    6 Aþýrý Sanatçý (sanat sepet tayfa)? 2, 10
    7 Insel(erkocu) ? 1, 10
    8 Seküler ? 6, 4, 10
    9 Dünya barýþçýsý ? 6, 4, 10
    10 Satanist (metalci) ? 1, 6, 3, 4, 2, 7, 8, 9 */

    public Character[] characters = new Character[10];
    Character SelectedCharacter;
    //// Start is called before the first frame update
    public void deneme()
    {
        characters[0] = new Character("feminist", 50); //feminist -> 2 7 10  ARRAYDE 1 6 9
        characters[1] = new Character("siyasal islamci", 50); //siyasal islamci 1 3 6 8 9 10 ARRAYDE 0 2 5 7 8 9 
        characters[2] = new Character("doga sever", 50); //doga sever 2 10 ARRAYDE 1 9
        characters[3] = new Character("milliyetci", 50); // milliyetci 8 9 10 ARRAYDE 7 8 9
        characters[4] = new Character("geek", 50); // geekler 
        characters[5] = new Character("asiri sanatci", 50); //asiri sanatci 2 10 ARRAYDE 1 9
        characters[6] = new Character("insel", 50); //insel 1 10 ARRAYDE 0 9
        characters[7] = new Character("sekuler", 50); // sekuler 4 6 10 ARRAYDE 3 5 9
        characters[8] = new Character("dunya bariscisi", 50); // dunya bariscisi  4 6 10 ARRAYDE 3 5 9
        characters[9] = new Character("satanist", 50); // satanist 1 2 3 4 6 7 8 9 ARRAYDE 0 1 2 3 5 6 7 8

    }

    //// Update is called once per frame
    void Update()
    {

        if (SelectedCharacter == characters[0]) //feminist için
        {
            characters[0].IncrementHappiness();
            characters[0].DecrementOpponent(characters[1]);
            characters[0].DecrementOpponent(characters[6]);
            characters[0].DecrementOpponent(characters[9]);
        }
        if (SelectedCharacter == characters[1]) //siyasal islamcý için
        {
            characters[1].IncrementHappiness();
            characters[1].DecrementOpponent(characters[0]);
            characters[1].DecrementOpponent(characters[2]);
            characters[1].DecrementOpponent(characters[5]);
            characters[1].DecrementOpponent(characters[7]);
            characters[1].DecrementOpponent(characters[8]);
            characters[1].DecrementOpponent(characters[9]);
        }
        if (SelectedCharacter == characters[2]) //doða sever için
        {
            characters[2].IncrementHappiness();
            characters[2].DecrementOpponent(characters[1]);
            characters[2].DecrementOpponent(characters[9]);
        }
        if (SelectedCharacter == characters[3]) //milliyetçi için
        {
            characters[3].IncrementHappiness();
            characters[3].DecrementOpponent(characters[7]);
            characters[3].DecrementOpponent(characters[8]);
            characters[3].DecrementOpponent(characters[9]);
        }
        if (SelectedCharacter == characters[4]) //geek için
        {
            characters[4].IncrementHappiness();
        }
        if (SelectedCharacter == characters[5]) //asiri sanatci için
        {
            characters[5].IncrementHappiness();
            characters[5].DecrementOpponent(characters[1]);
            characters[5].DecrementOpponent(characters[9]);
        }
        if (SelectedCharacter == characters[6]) //insel için
        {
            characters[6].IncrementHappiness();
            characters[6].DecrementOpponent(characters[0]);
            characters[6].DecrementOpponent(characters[9]);
        }
        if (SelectedCharacter == characters[7]) //seküler için
        {
            characters[7].IncrementHappiness();
            characters[7].DecrementOpponent(characters[3]);
            characters[7].DecrementOpponent(characters[5]);
            characters[7].DecrementOpponent(characters[9]);
        }
        if (SelectedCharacter == characters[8]) //dünya barýþçýsý için
        {
            characters[8].IncrementHappiness();
            characters[8].DecrementOpponent(characters[3]);
            characters[8].DecrementOpponent(characters[5]);
            characters[8].DecrementOpponent(characters[9]);
        }
        if (SelectedCharacter == characters[9]) //siyasal islamcý için
        {
            characters[9].IncrementHappiness();
            characters[9].DecrementOpponent(characters[0]);
            characters[9].DecrementOpponent(characters[1]);
            characters[9].DecrementOpponent(characters[2]);
            characters[9].DecrementOpponent(characters[3]);
            characters[9].DecrementOpponent(characters[5]);
            characters[9].DecrementOpponent(characters[6]);
            characters[9].DecrementOpponent(characters[7]);
            characters[9].DecrementOpponent(characters[8]);
        }

        
    }
}


