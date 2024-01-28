using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Character
{
    public int Id;
    public string name;
    public int happiness;
    public bool isStatChanged;
    public int happinessValue;
    public Character(int Id, string name, int happiness)
    {
        this.Id = Id;
        this.name = name;
        this.happiness = happiness;
    }
    public void DisplayInfo()
    {
        //Console.WriteLine($"Name: {charname}, Happiness: {happiness}");
    }
    public void IncrementHappiness()
    {
        happiness += 10;
        PlayerPrefs.SetInt("Happiness_" + Id, happiness);
        PlayerPrefs.Save();
        happinessValue = 0;
    }
    public void DecrementOpponent(Character character2)
    {
        
        if (character2.happiness > 0)
        {
            character2.happiness -= 10;
            PlayerPrefs.SetInt("Happiness_" + Id, happiness);
            PlayerPrefs.Save();
            happinessValue = 1;
        }
        else
        {
            //Console.WriteLine("happinest can't be negative");
        }
    }
    public int GetHappiness()
    {
        if (PlayerPrefs.HasKey("Happiness_" + Id))
        {
            happiness = PlayerPrefs.GetInt("Happiness_" + Id);
        }
        return happiness;
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

    public static Character[] characters = new Character[10];
    //// Start is called before the first frame update
    public static void createCharacters()
    {
        characters[0] = new Character(0,"feminist", 50); //feminist -> 2 7 10  ARRAYDE 1 6 9
        characters[1] = new Character(1,"siyasal islamci", 50); //siyasal islamci 1 3 6 8 9 10 ARRAYDE 0 2 5 7 8 9 
        characters[2] = new Character(2,"doga sever", 50); //doga sever 2 10 ARRAYDE 1 9
        characters[3] = new Character(3,"milliyetci", 50); // milliyetci 8 9 10 ARRAYDE 7 8 9
        characters[4] = new Character(4,"geek", 50); // geekler 
        characters[5] = new Character(5,"asiri sanatci", 50); //asiri sanatci 2 10 ARRAYDE 1 9
        characters[6] = new Character(6,"insel", 50); //insel 1 10 ARRAYDE 0 9
        characters[7] = new Character(7,"sekuler", 50); // sekuler 4 6 10 ARRAYDE 3 5 9
        characters[8] = new Character(8,"dunya bariscisi", 50); // dunya bariscisi  4 6 10 ARRAYDE 3 5 9
        characters[9] = new Character(9,"satanist", 50); // satanist 1 2 3 4 6 7 8 9 ARRAYDE 0 1 2 3 5 6 7 8

    }

    public static void IncreaseJudgeHappiness(Character character)
    {
        if (character == characters[0]) //feminist i�in
        {
            characters[0].isStatChanged = true;
            characters[0].IncrementHappiness();
        }
        if (character == characters[1]) //siyasal islamc� i�in
        {
            characters[1].isStatChanged = true;
            characters[1].IncrementHappiness();
        }
        if (character == characters[2]) //do�a sever i�in
        {
            characters[2].isStatChanged = true;
            characters[2].IncrementHappiness();
        }
        if (character == characters[3]) //milliyet�i i�in
        {
            characters[3].isStatChanged = true;
            characters[3].IncrementHappiness();
        }
        if (character == characters[4]) //geek i�in
        {
            characters[4].isStatChanged = true;
            characters[4].IncrementHappiness();
        }
        if (character == characters[5]) //asiri sanatci i�in
        {
            characters[5].isStatChanged = true;
            characters[5].IncrementHappiness();
        }
        if (character == characters[6]) //insel i�in
        {
            characters[6].isStatChanged = true;
            characters[6].IncrementHappiness();
        }
        if (character == characters[7]) //sek�ler i�in
        {
            characters[7].isStatChanged = true;
            characters[7].IncrementHappiness();
        }
        if (character == characters[8]) //d�nya bar����s� i�in
        {
            characters[8].isStatChanged = true;
            characters[8].IncrementHappiness();
        }
        if (character == characters[9]) //siyasal islamc� i�in
        {
            characters[9].isStatChanged = true;
            characters[9].IncrementHappiness();
        }
    }

    public static void DecreaseJudgeHappiness(Character bizimChar)
    {
        if (bizimChar == characters[0]) //feminist i�in
        {
            characters[0].isStatChanged = true;
            characters[0].DecrementOpponent(characters[0]);
 
        }
        if (bizimChar == characters[1]) //siyasal islamc� i�in
        {
            characters[1].isStatChanged = true;
            characters[1].DecrementOpponent(characters[1]);
        }
        if (bizimChar == characters[2]) //do�a sever i�in
        {
            characters[2].isStatChanged = true;;
            characters[2].DecrementOpponent(characters[2]);
        }
        if (bizimChar == characters[3]) //milliyet�i i�in
        {
            characters[3].isStatChanged = true;
            characters[3].DecrementOpponent(characters[3]);
        }
        if (bizimChar == characters[4]) //geek i�in
        {
            characters[4].isStatChanged = true;
            characters[4].DecrementOpponent(characters[4]);
        }
        if (bizimChar == characters[5]) //asiri sanatci i�in
        {
            characters[5].isStatChanged = true;
            characters[5].DecrementOpponent(characters[5]);
        }
        if (bizimChar == characters[6]) //insel i�in
        {
            characters[6].isStatChanged = true;
            characters[6].DecrementOpponent(characters[6]);
        }
        if (bizimChar == characters[7]) //sek�ler i�in
        {
            characters[7].isStatChanged = true;
            characters[7].DecrementOpponent(characters[7]);
        }
        if (bizimChar == characters[8]) //d�nya bar����s� i�in
        {
            characters[8].isStatChanged = true;
            characters[8].DecrementOpponent(characters[8]);
        }
        if (bizimChar == characters[9]) //siyasal islamc� i�in
        {
            characters[9].isStatChanged = true;
            characters[9].DecrementOpponent(characters[9]);
        }
    }


    //public static void UpdateJudgeStats(Character bizimChar)
    //{
    //    if (bizimChar == characters[0]) //feminist i�in
    //    {
    //        characters[0].isStatChanged = true;
    //        characters[0].IncrementHappiness();
    //        characters[0].DecrementOpponent(characters[1]);
    //        characters[0].DecrementOpponent(characters[6]);
    //        characters[0].DecrementOpponent(characters[9]);
    //        Debug.Log("Feminist Happiness " + characters[0].happiness);
    //    }
    //    if (bizimChar == characters[1]) //siyasal islamc� i�in
    //    {
    //        characters[1].isStatChanged = true;
    //        characters[1].IncrementHappiness();
    //        characters[1].DecrementOpponent(characters[0]);
    //        characters[1].DecrementOpponent(characters[2]);
    //        characters[1].DecrementOpponent(characters[5]);
    //        characters[1].DecrementOpponent(characters[7]);
    //        characters[1].DecrementOpponent(characters[8]);
    //        characters[1].DecrementOpponent(characters[9]);
    //    }
    //    if (bizimChar == characters[2]) //do�a sever i�in
    //    {
    //        characters[2].isStatChanged = true;
    //        characters[2].IncrementHappiness();
    //        characters[2].DecrementOpponent(characters[1]);
    //        characters[2].DecrementOpponent(characters[9]);
    //    }
    //    if (bizimChar == characters[3]) //milliyet�i i�in
    //    {
    //        characters[3].isStatChanged = true;
    //        characters[3].IncrementHappiness();
    //        characters[3].DecrementOpponent(characters[7]);
    //        characters[3].DecrementOpponent(characters[8]);
    //        characters[3].DecrementOpponent(characters[9]);
    //    }
    //    if (bizimChar == characters[4]) //geek i�in
    //    {
    //        characters[4].isStatChanged = true;
    //        characters[4].IncrementHappiness();
    //    }
    //    if (bizimChar == characters[5]) //asiri sanatci i�in
    //    {
    //        characters[5].isStatChanged = true;
    //        characters[5].IncrementHappiness();
    //        characters[5].DecrementOpponent(characters[1]);
    //        characters[5].DecrementOpponent(characters[9]);
    //    }
    //    if (bizimChar == characters[6]) //insel i�in
    //    {
    //        characters[6].isStatChanged = true;
    //        characters[6].IncrementHappiness();
    //        characters[6].DecrementOpponent(characters[0]);
    //        characters[6].DecrementOpponent(characters[9]);
    //    }
    //    if (bizimChar == characters[7]) //sek�ler i�in
    //    {
    //        characters[7].isStatChanged = true;
    //        characters[7].IncrementHappiness();
    //        characters[7].DecrementOpponent(characters[3]);
    //        characters[7].DecrementOpponent(characters[5]);
    //        characters[7].DecrementOpponent(characters[9]);
    //    }
    //    if (bizimChar == characters[8]) //d�nya bar����s� i�in
    //    {
    //        characters[8].isStatChanged = true;
    //        characters[8].IncrementHappiness();
    //        characters[8].DecrementOpponent(characters[3]);
    //        characters[8].DecrementOpponent(characters[5]);
    //        characters[8].DecrementOpponent(characters[9]);
    //    }
    //    if (bizimChar == characters[9]) //siyasal islamc� i�in
    //    {
    //        characters[9].isStatChanged = true;
    //        characters[9].IncrementHappiness();
    //        characters[9].DecrementOpponent(characters[0]);
    //        characters[9].DecrementOpponent(characters[1]);
    //        characters[9].DecrementOpponent(characters[2]);
    //        characters[9].DecrementOpponent(characters[3]);
    //        characters[9].DecrementOpponent(characters[5]);
    //        characters[9].DecrementOpponent(characters[6]);
    //        characters[9].DecrementOpponent(characters[7]);
    //        characters[9].DecrementOpponent(characters[8]);
    //    }
    //}

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


