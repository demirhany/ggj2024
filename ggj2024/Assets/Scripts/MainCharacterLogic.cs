using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class Card
{
    public int Id;
    public string name;
    public int CharacterId;
    public List<int> Dislikes;
    public bool isOnclick;

    public Card(int id, string name, int characterId, List<int> dislikes)
    {
        this.Id = id;
        this.name = name;
        this.CharacterId = characterId;
        isOnclick = false;
        Dislikes = dislikes;
    }
    public Card()
    {
    }

};
public class MainCharacterLogic : MonoBehaviour
{
    public bool isButtonClicked;
    public bool isCardSelected;
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

        judge1.GetComponentInChildren<TextMeshPro>().text = ThreeRaandomJudges[0].GetHappiness() + " " + ThreeRaandomJudges[0].name;
        judge2.GetComponentInChildren<TextMeshPro>().text = ThreeRaandomJudges[1].GetHappiness() + " " + ThreeRaandomJudges[1].name;
        judge3.GetComponentInChildren<TextMeshPro>().text = ThreeRaandomJudges[2].GetHappiness() + " " + ThreeRaandomJudges[2].name;
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
                    isCardSelected = true;
                    selectedFiveCards[0].isOnclick = true;
                    selectedFiveCards[1].isOnclick = false;
                    selectedFiveCards[2].isOnclick = false;
                    selectedFiveCards[3].isOnclick = false;
                    selectedFiveCards[4].isOnclick = false;
                    Debug.Log(selectedFiveCards[0].name + " " + selectedFiveCards[0].isOnclick);

                }
                else if (hit.collider.CompareTag("Card2"))
                {
                    isCardSelected = true;
                    selectedFiveCards[0].isOnclick = false;
                    selectedFiveCards[1].isOnclick = true;
                    selectedFiveCards[2].isOnclick = false;
                    selectedFiveCards[3].isOnclick = false;
                    selectedFiveCards[4].isOnclick = false;
                    Debug.Log(selectedFiveCards[1].name + " " + selectedFiveCards[1].isOnclick);
                }
                else if (hit.collider.CompareTag("Card3"))
                {
                    isCardSelected = true;
                    selectedFiveCards[0].isOnclick = false;
                    selectedFiveCards[1].isOnclick = false;
                    selectedFiveCards[2].isOnclick = true;
                    selectedFiveCards[3].isOnclick = false;
                    selectedFiveCards[4].isOnclick = false;
                    Debug.Log(selectedFiveCards[2].name + " " + selectedFiveCards[2].isOnclick);
                }
                else if (hit.collider.CompareTag("Card4"))
                {
                    isCardSelected = true;
                    selectedFiveCards[0].isOnclick = false;
                    selectedFiveCards[1].isOnclick = false;
                    selectedFiveCards[2].isOnclick = false;
                    selectedFiveCards[3].isOnclick = true;
                    selectedFiveCards[4].isOnclick = false;
                    Debug.Log(selectedFiveCards[3].name + " " + selectedFiveCards[3].isOnclick);
                }
                else if (hit.collider.CompareTag("Card5"))
                {
                    isCardSelected = true;
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
        if(isCardSelected == true)
        {
            Card newCard = SelectRandomOneCard();
            for(int i = 0; i < 5; i++) 
            {

                if(selectedFiveCards[i].isOnclick == true)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        if (selectedFiveCards[i].CharacterId == ThreeRaandomJudges[j].Id)
                            Characters.IncreaseJudgeHappiness(ThreeRaandomJudges[j]);
                        for(int k = 0; k < selectedFiveCards[i].Dislikes.Count; k++)
                        {
                            if (selectedFiveCards[i].Dislikes[k] == ThreeRaandomJudges[j].Id)
                                Characters.DecreaseJudgeHappiness(ThreeRaandomJudges[j]);
                        }
                    } 
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

            //SelectThreeRandomJudges();

            //judge1.GetComponentInChildren<TextMeshPro>().text = ThreeRaandomJudges[0].happiness.ToString() + ThreeRaandomJudges[0].name;
            //judge2.GetComponentInChildren<TextMeshPro>().text = ThreeRaandomJudges[1].happiness.ToString() + ThreeRaandomJudges[1].name;
            //judge3.GetComponentInChildren<TextMeshPro>().text = ThreeRaandomJudges[2].happiness.ToString() + ThreeRaandomJudges[2].name;

            SceneManager.LoadScene("Listing Character");
        }
        foreach (var item in Characters.characters)
        {
            if(item.GetHappiness() == 0 || cards.Count <= 0)
                SceneManager.LoadScene("End");
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }

    // Initialize Card with starting values
    public void InitializeCards()
    {
        List<int> FeministDislikes = new List<int>(); FeministDislikes.Add(1); FeministDislikes.Add(6); FeministDislikes.Add(9);
        List<int> SiyasalIslamciDislikes = new List<int>(); SiyasalIslamciDislikes.Add(0); SiyasalIslamciDislikes.Add(2); SiyasalIslamciDislikes.Add(5); SiyasalIslamciDislikes.Add(7); SiyasalIslamciDislikes.Add(8); SiyasalIslamciDislikes.Add(9);
        List<int> DogaSeverDislikes = new List<int>(); DogaSeverDislikes.Add(9); DogaSeverDislikes.Add(1);
        List<int> MilliyetciDislikes = new List<int>(); MilliyetciDislikes.Add(7); MilliyetciDislikes.Add(8); MilliyetciDislikes.Add(9);
        List<int> GeekDislikes = new List<int>(); 
        List<int> AsiriSanatciDislikes = new List<int>(); AsiriSanatciDislikes.Add(1); AsiriSanatciDislikes.Add(9);
        List<int> InselDislikes = new List<int>(); InselDislikes.Add(0); InselDislikes.Add(9);
        List<int> SekulerDislikes = new List<int>(); SekulerDislikes.Add(5); SekulerDislikes.Add(3); SekulerDislikes.Add(9);
        List<int> DunyaBariscisiDislikes = new List<int>(); DunyaBariscisiDislikes.Add(5); DunyaBariscisiDislikes.Add(3); DunyaBariscisiDislikes.Add(9);
        List<int> SatanistDislikes = new List<int>(); SatanistDislikes.Add(0); SatanistDislikes.Add(1); SatanistDislikes.Add(2); SatanistDislikes.Add(3); SatanistDislikes.Add(5); SatanistDislikes.Add(6); SatanistDislikes.Add(7); SatanistDislikes.Add(8);
        cards.Add(new Card(0, "Feminist 0",0, FeministDislikes));
        cards.Add(new Card(1, "Feminist 1", 0, FeministDislikes));
        cards.Add(new Card(2, "Feminist 2", 0, FeministDislikes));
        cards.Add(new Card(3, "Siyasal Islamci 3",1, SiyasalIslamciDislikes));
        cards.Add(new Card(4, "Siyasal Islamci 4", 1, SiyasalIslamciDislikes));
        cards.Add(new Card(5, "Siyasal Islamci 5", 1, SiyasalIslamciDislikes));
        cards.Add(new Card(6, "Doga Sever 6",2, DogaSeverDislikes));
        cards.Add(new Card(7, "Doga Sever 7", 2, DogaSeverDislikes));
        cards.Add(new Card(8, "Doga Sever 8", 2, DogaSeverDislikes));
        cards.Add(new Card(9, "Milliyetci 9",3, MilliyetciDislikes));
        cards.Add(new Card(10, "Milliyetci 10", 3, MilliyetciDislikes));
        cards.Add(new Card(11, "Milliyetci 11", 3, MilliyetciDislikes));
        cards.Add(new Card(12, "Geek 12",4, GeekDislikes));
        cards.Add(new Card(13, "Geek 13", 4, GeekDislikes));
        cards.Add(new Card(14, "Geek 14", 4, GeekDislikes));
        cards.Add(new Card(15, "Asiri Sanatci 15",5, AsiriSanatciDislikes));
        cards.Add(new Card(16, "Asiri Sanatci 16", 5, AsiriSanatciDislikes));
        cards.Add(new Card(17, "Asiri Sanatci 17", 5, AsiriSanatciDislikes));
        cards.Add(new Card(18, "Insel 18",6, InselDislikes));
        cards.Add(new Card(19, "Insel 19", 6, InselDislikes));
        cards.Add(new Card(20, "Insel 20", 6, InselDislikes));
        cards.Add(new Card(21, "Sekuler 21",7, SekulerDislikes));
        cards.Add(new Card(22, "Sekuler 22", 7, SekulerDislikes));
        cards.Add(new Card(23, "Sekuler 23", 7, SekulerDislikes));
        cards.Add(new Card(24, "Dunya Bariscilari 24",8, DunyaBariscisiDislikes));
        cards.Add(new Card(25, "Dunya Bariscilari 25", 8, DunyaBariscisiDislikes));
        cards.Add(new Card(26, "Dunya Bariscilari 26", 8, DunyaBariscisiDislikes));
        cards.Add(new Card(27, "Satanist 27",9, SatanistDislikes));
        cards.Add(new Card(28, "Satanist 28", 9, SatanistDislikes));
        cards.Add(new Card(29, "Satanist 29", 9, SatanistDislikes));
         
    }
    
}
