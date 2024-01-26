using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacterLogic : MonoBehaviour
{
    public bool isButtonClicked;
    public List<object>cards;
    private List<object> selectedFiveCards;
    private void Awake()
    {
        cards = new List<object>(); // bu kartlari, kartlari array olarak donduren bir fonksiyonu kullanarak cekecegiz
        //card = GameObject.FindGameObjectWithTag("Card").GetComponent<CardScript>();
        //cards = card.GetCard(); //GetCard() bir object array dondurmeli

        for(int i = 0; i < 30; i++)
        {
            cards.Add(("deneme" + i, i));
        }
        selectedFiveCards = SelectRandomFiveCards();
        //foreach (var item in selectedFiveCards)
        //{
        //    Debug.Log(item);
        //}
    }

    private void Update()
    {
        
    }

    public void ChangeIsClicked()
    {
        isButtonClicked = true;
    }

    public List<object> SelectRandomFiveCards()
    {
        List<int> cardId = new List<int>();
        for (int j = 0; j < 30; j++)
        {
            cardId.Add(j);
        }
        List<object> selectedCards = new List<object>();
        for(int j = 0; j < 5; j++)
        {
            int value = Random.Range(0, cardId.Count);
            selectedCards.Add(cards[cardId[value]]);
            cardId.RemoveAt(value);
        }
        return selectedCards;
    }
}
