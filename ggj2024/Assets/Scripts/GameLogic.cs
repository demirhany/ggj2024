using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public Characters character;
    public RandomCharacterSelector characterSelector;
    public List<Character> ThreeRaandomJudges;
    void Start()
    {
        character.createCharacters();
        ThreeRaandomJudges = new List<Character>();
        //character = GameObject.FindGameObjectWithTag("Character").GetComponent<Characters>();
        //characterSelector = GameObject.FindGameObjectWithTag("RandomCharacterSelector").GetComponent<RandomCharacterSelector>();
        List<int> indexArray = characterSelector.SelectJuris();
        
        for(int i = 0; i < 3; i++)
        {
            ThreeRaandomJudges.Add(character.characters[indexArray[i]]);
        }
        character.UpdateJudgeStats(ThreeRaandomJudges[0]);
        foreach(Character c in ThreeRaandomJudges) 
        {
            Debug.Log(c.name + " " +  c.happiness);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
