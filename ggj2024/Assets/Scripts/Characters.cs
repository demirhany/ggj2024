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
    2 Siyasal �slamci ? 1, ~3, 6, 8, 9, 10
    3 Do�a sever ? 10, 2
    4 Milliyet�i ? 8, 9, 10
    5 Geekler ?
    6 A��r� Sanat�� (sanat sepet tayfa)? 2, 10
    7 Insel(erkocu) ? 1, 10
    8 Sek�ler ? 6, 4, 10
    9 D�nya bar����s� ? 6, 4, 10
    10 Satanist (metalci) ? 1, 6, 3, 4, 2, 7, 8, 9 */

    public Character[] characters = new Character[10];
    //// Start is called before the first frame update
    public void createCharacters()
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

    public void UpdateJudgeStats(Character bizimChar)
    {
        if (bizimChar == characters[0]) //feminist i�in
        {
            characters[0].IncrementHappiness();
            characters[0].DecrementOpponent(characters[1]);
            characters[0].DecrementOpponent(characters[6]);
            characters[0].DecrementOpponent(characters[9]);
        }
        if (bizimChar == characters[1]) //siyasal islamc� i�in
        {
            characters[1].IncrementHappiness();
            characters[1].DecrementOpponent(characters[0]);
            characters[1].DecrementOpponent(characters[2]);
            characters[1].DecrementOpponent(characters[5]);
            characters[1].DecrementOpponent(characters[7]);
            characters[1].DecrementOpponent(characters[8]);
            characters[1].DecrementOpponent(characters[9]);
        }
        if (bizimChar == characters[2]) //do�a sever i�in
        {
            characters[2].IncrementHappiness();
            characters[2].DecrementOpponent(characters[1]);
            characters[2].DecrementOpponent(characters[9]);
        }
        if (bizimChar == characters[3]) //milliyet�i i�in
        {
            characters[3].IncrementHappiness();
            characters[3].DecrementOpponent(characters[7]);
            characters[3].DecrementOpponent(characters[8]);
            characters[3].DecrementOpponent(characters[9]);
        }
        if (bizimChar == characters[4]) //geek i�in
        {
            characters[4].IncrementHappiness();
        }
        if (bizimChar == characters[5]) //asiri sanatci i�in
        {
            characters[5].IncrementHappiness();
            characters[5].DecrementOpponent(characters[1]);
            characters[5].DecrementOpponent(characters[9]);
        }
        if (bizimChar == characters[6]) //insel i�in
        {
            characters[6].IncrementHappiness();
            characters[6].DecrementOpponent(characters[0]);
            characters[6].DecrementOpponent(characters[9]);
        }
        if (bizimChar == characters[7]) //sek�ler i�in
        {
            characters[7].IncrementHappiness();
            characters[7].DecrementOpponent(characters[3]);
            characters[7].DecrementOpponent(characters[5]);
            characters[7].DecrementOpponent(characters[9]);
        }
        if (bizimChar == characters[8]) //d�nya bar����s� i�in
        {
            characters[8].IncrementHappiness();
            characters[8].DecrementOpponent(characters[3]);
            characters[8].DecrementOpponent(characters[5]);
            characters[8].DecrementOpponent(characters[9]);
        }
        if (bizimChar == characters[9]) //siyasal islamc� i�in
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

    //// Update is called once per frame
    // void Update()
    // {
    //
    //     if (bizimChar == characters[0]) //feminist i�in
    //     {
    //         characters[0].IncrementHappiness();
    //         characters[0].DecrementOpponent(characters[1]);
    //         characters[0].DecrementOpponent(characters[6]);
    //         characters[0].DecrementOpponent(characters[9]);
    //     }
    //     if (bizimChar == characters[1]) //siyasal islamc� i�in
    //     {
    //         characters[1].IncrementHappiness();
    //         characters[1].DecrementOpponent(characters[0]);
    //         characters[1].DecrementOpponent(characters[2]);
    //         characters[1].DecrementOpponent(characters[5]);
    //         characters[1].DecrementOpponent(characters[7]);
    //         characters[1].DecrementOpponent(characters[8]);
    //         characters[1].DecrementOpponent(characters[9]);
    //     }
    //     if (bizimChar == characters[2]) //do�a sever i�in
    //     {
    //         characters[2].IncrementHappiness();
    //         characters[2].DecrementOpponent(characters[1]);
    //         characters[2].DecrementOpponent(characters[9]);
    //     }
    //     if (bizimChar == characters[3]) //milliyet�i i�in
    //     {
    //         characters[3].IncrementHappiness();
    //         characters[3].DecrementOpponent(characters[7]);
    //         characters[3].DecrementOpponent(characters[8]);
    //         characters[3].DecrementOpponent(characters[9]);
    //     }
    //     if (bizimChar == characters[4]) //geek i�in
    //     {
    //         characters[4].IncrementHappiness();
    //     }
    //     if (bizimChar == characters[5]) //asiri sanatci i�in
    //     {
    //         characters[5].IncrementHappiness();
    //         characters[5].DecrementOpponent(characters[1]);
    //         characters[5].DecrementOpponent(characters[9]);
    //     }
    //     if (bizimChar == characters[6]) //insel i�in
    //     {
    //         characters[6].IncrementHappiness();
    //         characters[6].DecrementOpponent(characters[0]);
    //         characters[6].DecrementOpponent(characters[9]);
    //     }
    //     if (bizimChar == characters[7]) //sek�ler i�in
    //     {
    //         characters[7].IncrementHappiness();
    //         characters[7].DecrementOpponent(characters[3]);
    //         characters[7].DecrementOpponent(characters[5]);
    //         characters[7].DecrementOpponent(characters[9]);
    //     }
    //     if (bizimChar == characters[8]) //d�nya bar����s� i�in
    //     {
    //         characters[8].IncrementHappiness();
    //         characters[8].DecrementOpponent(characters[3]);
    //         characters[8].DecrementOpponent(characters[5]);
    //         characters[8].DecrementOpponent(characters[9]);
    //     }
    //     if (bizimChar == characters[9]) //siyasal islamc� i�in
    //     {
    //         characters[9].IncrementHappiness();
    //         characters[9].DecrementOpponent(characters[0]);
    //         characters[9].DecrementOpponent(characters[1]);
    //         characters[9].DecrementOpponent(characters[2]);
    //         characters[9].DecrementOpponent(characters[3]);
    //         characters[9].DecrementOpponent(characters[5]);
    //         characters[9].DecrementOpponent(characters[6]);
    //         characters[9].DecrementOpponent(characters[7]);
    //         characters[9].DecrementOpponent(characters[8]);
    //     }
    //
    //     
    // }
}


