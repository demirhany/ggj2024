using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ListingCharacterSceneManager : MonoBehaviour
{
    public GameObject judge1;
    public GameObject judge2;
    public GameObject judge3;
    public GameObject judge4;
    public GameObject judge5;
    public GameObject judge6;
    public GameObject judge7;
    public GameObject judge8;
    public GameObject judge9;
    public GameObject judge10;

    public List<GameObject> judgeList;

    private void Start()
    {
        judgeList = new List<GameObject>();
        judgeList.Add(judge1);
        judgeList.Add(judge2);
        judgeList.Add(judge3);
        judgeList.Add(judge4);
        judgeList.Add(judge5);
        judgeList.Add(judge6);
        judgeList.Add(judge7);
        judgeList.Add(judge8);
        judgeList.Add(judge9);
        judgeList.Add(judge10);

        for(int i = 0; i < 10; i++)
        {
            if (Characters.characters[i].isStatChanged == true)
                judgeList[i].GetComponentInChildren<TextMeshPro>().text = Characters.characters[i].GetHappiness() + " " + Characters.characters[i].name + " the stat was changed";

            else
                judgeList[i].GetComponentInChildren<TextMeshPro>().text = Characters.characters[i].GetHappiness() + " " + Characters.characters[i].name;
        }
        
    }

    public void newTurn()
    {
        for(int i = 0;i < 10;i++) 
        {
            Characters.characters[i].isStatChanged = false;
        }

        SceneManager.LoadScene("Main");
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}
