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

    public HealthBar HealthBar1;
    public HealthBar HealthBar2;
    public HealthBar HealthBar3;
    public HealthBar HealthBar4;
    public HealthBar HealthBar5;
    public HealthBar HealthBar6;
    public HealthBar HealthBar7;
    public HealthBar HealthBar8;
    public HealthBar HealthBar9;
    public HealthBar HealthBar10;

    public Sprite Feminist;
    public Sprite siyasalislamci;
    public Sprite Dogaci;
    public Sprite Millitetci;
    public Sprite Geek;
    public Sprite sanatci;
    public Sprite Insel;
    public Sprite sekuler;
    public Sprite DunyaBarisi;
    public Sprite Satanist;

    public List<GameObject> judgeList;
    public List<Sprite> judgeSpriteList;
    public List<HealthBar> HealthBarList;

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

        judgeSpriteList = new List<Sprite>();
        judgeSpriteList.Add(Feminist);
        judgeSpriteList.Add(siyasalislamci);
        judgeSpriteList.Add(Dogaci);
        judgeSpriteList.Add(Millitetci);
        judgeSpriteList.Add(Geek);
        judgeSpriteList.Add(sanatci);
        judgeSpriteList.Add(Insel);
        judgeSpriteList.Add(sekuler);
        judgeSpriteList.Add(DunyaBarisi);
        judgeSpriteList.Add(Satanist);

        HealthBarList = new List<HealthBar>();
        HealthBarList.Add(HealthBar1);
        HealthBarList.Add(HealthBar2);
        HealthBarList.Add(HealthBar3);
        HealthBarList.Add(HealthBar4);
        HealthBarList.Add(HealthBar5);
        HealthBarList.Add(HealthBar6);
        HealthBarList.Add(HealthBar7);
        HealthBarList.Add(HealthBar8);
        HealthBarList.Add(HealthBar9);
        HealthBarList.Add(HealthBar10);

        for (int i = 0; i < 10; i++)
        {
            if (Characters.characters[i].isStatChanged == true) 
            {
                judgeList[i].GetComponent<SpriteRenderer>().sprite = judgeSpriteList[i];
            }

            else
            {
                judgeList[i].GetComponent<SpriteRenderer>().sprite = judgeSpriteList[i];

            }
        }

        for (int i = 0; i < HealthBarList.Count; i++)
        {
            HealthBarList[i].SetSlider(PlayerPrefs.GetInt("Happiness_" + i));
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
