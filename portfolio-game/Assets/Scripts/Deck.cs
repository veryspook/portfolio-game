using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Deck : MonoBehaviour
{
    public int availableCards;
    public int totalCards;
    public int allocatedCards;
    public List<ScriptableObject> cardList;
    public List<ScriptableObject> currentCards;

    System.Random rnd = new System.Random();

    void Start()
    {
        //GenerateDeck();
        allocatedCards = 10;
        totalCards = allocatedCards;
        availableCards = totalCards;
        //allocatedCards represents the amount of cards allocated for each player out of the total shared card deck.
        //totalCards represents the totalCards in each individual players deck.
        //availableCards is how many cards are currently inside of the available deck. Once the player cycles through this amount, the deck will reshuffle itself.
    }

    public void GenerateDeck()
    {
        for (int i = 0; i < 10; i++)
        {
            currentCards.Add(cardList[rnd.Next(cardList.Count)]);
        }
        HandManager.instance.GetCards(currentCards);
        currentCards = new List<ScriptableObject>();
    }

    void Update()
    {

    }

    public void ReceiveCards(int cards)
    {
        allocatedCards = cards;
        Debug.Log("Player received cards");
        Debug.Log(allocatedCards + " cards received by player 1.");

        //The ReceiveCards function is called from the SharedDeckManager script. It allocates the number of cards in the deck to each player depending on how many players are present.
    }
}
