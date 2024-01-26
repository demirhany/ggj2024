using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Character> judges;
    public Character characters;
    public RandomCharacterSelector characterSelector;
    public List<Character> selectedCharacter;
    void Start()
    {
        selectedCharacter = new List<Character>();
        characters = GameObject.FindGameObjectWithTag("Character").GetComponent<Character>();
        characterSelector = GameObject.FindGameObjectWithTag("RandomCharacterSelector").GetComponent<RandomCharacterSelector>();
        
        for(int i = 0; i < 3; i++)
        {
            selectedCharacter.Add(characters.characters[characterSelector.SelectJuris()[i]])
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
