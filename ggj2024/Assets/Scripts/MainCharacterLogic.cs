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

    public Card(int id, string name, int characterId)
    {
        this.Id = id;
        this.name = name;
        this.CharacterId = characterId;
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
    
    
    
    private void Awake()
    {
        selectedFiveCards = new List<Card>();
        cards = new List<Card>(); 
        
        InitializeCards();
        
        // bu kartlari, kartlari array olarak donduren bir fonksiyonu kullanarak cekecegiz
        //card = GameObject.FindGameObjectWithTag("Card").GetComponent<CardScript>();
        //cards = card.GetCard();
        ////GetCard() bir object array dondurmeli

        
        for (int i = 0; i < 5; i++)
        {
            selectedFiveCards.Add(SelectRandomOneCard());
            Debug.Log(cards[i].name);
        }
    }

    
    // Select a random card that returns card object 

    public Card SelectRandomOneCard()
    {
        Card selectedCard = new Card();
        
        int value = UnityEngine.Random.Range(0, cards.Count);
        selectedCard = cards[value];
        cards.RemoveAt(value);
        return selectedCard;
    }
    
    
    // Initialize Card with starting values
    public void InitializeCards()
    {
        cards.Add(new Card(0,"demirhan",0));
        cards.Add(new Card(1,"asdasd",0));
        cards.Add(new Card(2,"Ahmetcan",0));
        cards.Add(new Card(3,"asdasd",1));
        cards.Add(new Card(4,"asdasd",1));
        cards.Add(new Card(5,"asdasd",1));
        cards.Add(new Card(6,"asdasd",2));
        cards.Add(new Card(7,"asdasd",2));
        cards.Add(new Card(8,"asdasd",2));
        cards.Add(new Card(9,"asdasd",3));
        cards.Add(new Card(10,"asdasd",3));
        cards.Add(new Card(11,"asdasd",3));
        cards.Add(new Card(12,"asdasd",4));
        cards.Add(new Card(13,"asdasd",4));
        cards.Add(new Card(14,"asdasd",4));
        cards.Add(new Card(15,"asdasd",5));
        cards.Add(new Card(16,"asdasd",5));
        cards.Add(new Card(17,"asdasd",5));
        cards.Add(new Card(18,"asdasd",6));
        cards.Add(new Card(19,"asdasd",6));
        cards.Add(new Card(20,"asdasd",6));
        cards.Add(new Card(21,"asdasd",7));
        cards.Add(new Card(22,"asdasd",7));
        cards.Add(new Card(23,"asdasd",7));
        cards.Add(new Card(24,"asdasd",8));
        cards.Add(new Card(25,"asdasd",8));
        cards.Add(new Card(26,"asdasd",8));
        cards.Add(new Card(27,"asdasd",9));
        cards.Add(new Card(28,"asdasd",9));
        cards.Add(new Card(29,"asdasd",9));
         
    }
    
}
