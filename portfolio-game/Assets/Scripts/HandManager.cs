using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandManager : MonoBehaviour
{
    public static HandManager instance;
    public List<Card> Hand = new List<Card>();

    public Transform HandContent;
    public GameObject CardInHand;

    //Called from Deck.cs
    public void GetCards(List<ScriptableObject> cards)
    {
        foreach (Card card in cards)
        {
            Hand.Add(card);
        }
    }

    private void Awake()
    {
        instance = this;
    }

    //Adds a card to the Hand list with an input of a Card prefab object
    public void Add(Card card)
    {
        Hand.Add(card);
    }

    //Removes a card from the Hand list with an input of a Card prefab object
    public void Remove(Card card)
    {
        Hand.Remove(card);
    }

    public void ShowHand()
    {
        //Deletes duplicate cards 
        foreach (Transform card in HandContent)
        {
            Destroy(card.gameObject);
        }
        //Instantiates all cards in the Hand list
        foreach (var card in Hand)
        {
            GameObject obj = Instantiate(CardInHand, HandContent);
            var cardName = obj.transform.Find("CardText").GetComponent<TMPro.TextMeshProUGUI>();
            var cardImage = obj.transform.Find("CardImage").GetComponent<Image>();
            obj.GetComponent<CardController>().card = card;

            cardName.text = card.cardName;
            cardImage.sprite = card.image;
        }
    }
}