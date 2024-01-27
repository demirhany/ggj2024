using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Card
{
    public int Id;
    public string name;
    public int CharacterId;
    public bool isOnclick;

    public Card(int id, string name, int characterId)
    {
        this.Id = id;
        this.name = name;
        this.CharacterId = characterId;
        isOnclick = false;
    }
    public Card()
    {
    }

};
public class MainCharacterLogic : MonoBehaviour
{
    public bool isButtonClicked;
    public List<Card>cards;
    public List<Card> selectedFiveCards;
    public GameObject card1;
    public GameObject card2;
    public GameObject card3;
    public GameObject card4;
    public GameObject card5;
    public GameObject judge1;
    public GameObject judge2;
    public GameObject judge3;
    public static List<Character> ThreeRaandomJudges;
    
    
    //newCardAnimation part start

    public GameObject prefabNewCard;
    public int selectedCardIndex;
    public GameObject bunch;
    
    
    //newCardAnimation part end
    
    
    
    
    // public GameLogic gameLogic;
    //public Characters characterLogic;

    private void Awake()
    {
        selectedFiveCards = new List<Card>();
        cards = new List<Card>();
        ThreeRaandomJudges = new List<Character>();
        Characters.createCharacters();
        // gameLogic = GameObject.FindGameObjectWithTag("Game Logic").GetComponent<GameLogic>();
        //characterLogic = GameObject.FindGameObjectWithTag("Character").GetComponent<Characters>();
        //characterLogic = new Characters();


        InitializeCards();

        // bu kartlari, kartlari array olarak donduren bir fonksiyonu kullanarak cekecegiz
        //card = GameObject.FindGameObjectWithTag("Card").GetComponent<CardScript>();
        //cards = card.GetCard();
        ////GetCard() bir object array dondurmeli
        List<string> cardTexts = new List<string>();
        for (int i = 0; i < 5; i++)
        {
            selectedFiveCards.Add(SelectRandomOneCard());
            cardTexts.Add(selectedFiveCards[i].name);
        }
        card1.GetComponentInChildren<TextMeshPro>().text = cardTexts[0];
        card2.GetComponentInChildren<TextMeshPro>().text = cardTexts[1];
        card3.GetComponentInChildren<TextMeshPro>().text = cardTexts[2];
        card4.GetComponentInChildren<TextMeshPro>().text = cardTexts[3];
        card5.GetComponentInChildren<TextMeshPro>().text = cardTexts[4];

        SelectThreeRandomJudges();

        judge1.GetComponentInChildren<TextMeshPro>().text = ThreeRaandomJudges[0].happiness.ToString();
        judge2.GetComponentInChildren<TextMeshPro>().text = ThreeRaandomJudges[1].happiness.ToString();
        judge3.GetComponentInChildren<TextMeshPro>().text = ThreeRaandomJudges[2].happiness.ToString();
    }


    // Select a random card that returns card object 

    public void Update()
    {
        if(cards.Count == 0) 
        {
            //change scene to end game
        }

        // Mouse sol tu�a t�klan�p t�klanmad���n� kontrol et
        if (Input.GetMouseButtonDown(0))
        {
            // Mouse pozisyonundan bir ���n olu�tur
            Vector2 rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.zero);

            // I��ma �arpan bir nesne var m� kontrol et
            if (hit.collider != null)
            {
                // E�er �arpan nesnenin bir etiketi varsa (ba�ka kriterleri de kullanabilirsiniz)
                if (hit.collider.CompareTag("Card1"))
                {
                    selectedFiveCards[0].isOnclick = true;
                    selectedFiveCards[1].isOnclick = false;
                    selectedFiveCards[2].isOnclick = false;
                    selectedFiveCards[3].isOnclick = false;
                    selectedFiveCards[4].isOnclick = false;
                    Debug.Log(selectedFiveCards[0].name + " " + selectedFiveCards[0].isOnclick);

                }
                else if (hit.collider.CompareTag("Card2"))
                {
                    selectedFiveCards[0].isOnclick = false;
                    selectedFiveCards[1].isOnclick = true;
                    selectedFiveCards[2].isOnclick = false;
                    selectedFiveCards[3].isOnclick = false;
                    selectedFiveCards[4].isOnclick = false;
                    Debug.Log(selectedFiveCards[1].name + " " + selectedFiveCards[1].isOnclick);
                }
                else if (hit.collider.CompareTag("Card3"))
                {
                    selectedFiveCards[0].isOnclick = false;
                    selectedFiveCards[1].isOnclick = false;
                    selectedFiveCards[2].isOnclick = true;
                    selectedFiveCards[3].isOnclick = false;
                    selectedFiveCards[4].isOnclick = false;
                    Debug.Log(selectedFiveCards[2].name + " " + selectedFiveCards[2].isOnclick);
                }
                else if (hit.collider.CompareTag("Card4"))
                {
                    selectedFiveCards[0].isOnclick = false;
                    selectedFiveCards[1].isOnclick = false;
                    selectedFiveCards[2].isOnclick = false;
                    selectedFiveCards[3].isOnclick = true;
                    selectedFiveCards[4].isOnclick = false;
                    Debug.Log(selectedFiveCards[3].name + " " + selectedFiveCards[3].isOnclick);
                }
                else if (hit.collider.CompareTag("Card5"))
                {
                    selectedFiveCards[0].isOnclick = false;
                    selectedFiveCards[1].isOnclick = false;
                    selectedFiveCards[2].isOnclick = false;
                    selectedFiveCards[3].isOnclick = false;
                    selectedFiveCards[4].isOnclick = true;
                    Debug.Log(selectedFiveCards[4].name + " " + selectedFiveCards[4].isOnclick);
                }
            }
        }
    }

    public static void SelectThreeRandomJudges()
    {
        List<int> indexArray = RandomCharacterSelector.SelectJuris();
        if(ThreeRaandomJudges.Count >= 3 ) { ThreeRaandomJudges.Clear(); }
        for (int i = 0; i < 3; i++)
        {
            ThreeRaandomJudges.Add(Characters.characters[indexArray[i]]);
        }
    }

    public Card SelectRandomOneCard()
    {
        Card selectedCard = new Card();
        
        int value = UnityEngine.Random.Range(0, cards.Count);
        selectedCard = cards[value];
        cards.RemoveAt(value);
        return selectedCard;
    }

    public void EndTurn()
    {
        Card newCard = SelectRandomOneCard();
        for(int i = 0; i < 5; i++) 
        {
            if(selectedFiveCards[i].isOnclick == true)
            {
                selectedFiveCards.RemoveAt(i);
                selectedFiveCards.Insert(i, newCard);
                selectedCardIndex = i;
            }
        }

        Instantiate(prefabNewCard, bunch.transform.position, Quaternion.identity);
        
        
        card1.GetComponentInChildren<TextMeshPro>().text = selectedFiveCards[0].name;
        card2.GetComponentInChildren<TextMeshPro>().text = selectedFiveCards[1].name;
        card3.GetComponentInChildren<TextMeshPro>().text = selectedFiveCards[2].name;
        card4.GetComponentInChildren<TextMeshPro>().text = selectedFiveCards[3].name;
        card5.GetComponentInChildren<TextMeshPro>().text = selectedFiveCards[4].name;



        SelectThreeRandomJudges();

        judge1.GetComponentInChildren<TextMeshPro>().text = ThreeRaandomJudges[0].happiness.ToString() + ThreeRaandomJudges[0].name;
        judge2.GetComponentInChildren<TextMeshPro>().text = ThreeRaandomJudges[1].happiness.ToString() + ThreeRaandomJudges[1].name;
        judge3.GetComponentInChildren<TextMeshPro>().text = ThreeRaandomJudges[2].happiness.ToString() + ThreeRaandomJudges[2].name;
    }
    
    
    // Initialize Card with starting values
    public void InitializeCards()
    {
        cards.Add(new Card(0,"0",0));
        cards.Add(new Card(1,"1",0));
        cards.Add(new Card(2,"2",0));
        cards.Add(new Card(3,"3",1));
        cards.Add(new Card(4,"4",1));
        cards.Add(new Card(5,"5",1));
        cards.Add(new Card(6,"6",2));
        cards.Add(new Card(7,"7",2));
        cards.Add(new Card(8,"8",2));
        cards.Add(new Card(9,"9",3));
        cards.Add(new Card(10,"10",3));
        cards.Add(new Card(11,"11",3));
        cards.Add(new Card(12,"12",4));
        cards.Add(new Card(13,"13",4));
        cards.Add(new Card(14,"14",4));
        cards.Add(new Card(15,"15",5));
        cards.Add(new Card(16,"16",5));
        cards.Add(new Card(17,"17",5));
        cards.Add(new Card(18,"18",6));
        cards.Add(new Card(19,"19",6));
        cards.Add(new Card(20,"20",6));
        cards.Add(new Card(21,"21",7));
        cards.Add(new Card(22,"22",7));
        cards.Add(new Card(23,"23",7));
        cards.Add(new Card(24,"24",8));
        cards.Add(new Card(25,"25",8));
        cards.Add(new Card(26,"26",8));
        cards.Add(new Card(27,"27",9));
        cards.Add(new Card(28,"28",9));
        cards.Add(new Card(29,"29",9));
         
    }
    
}
