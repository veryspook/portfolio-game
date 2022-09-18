using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedDeckManager : MonoBehaviour
{
    int allCards;
    public int cardsPerPlayer;

    public static int amountOfPlayers;

    public GameObject deck;
    //public GameObject deck2;
    //public GameObject deck3;
    //public GameObject deck4;

    //a deck for each player to be added later

    //allCards represents the entirety of the shared deck between each player in the current game. cardsPerPlayer is the allocated amount of cards that will be distributed for each players deck.
    
    void Start()
    {
        allCards = 120;
        cardsPerPlayer = allCards / amountOfPlayers;
        //distrubutes allCards among amountOfPlayers
        deck.GetComponent<Deck>().ReceiveCards(cardsPerPlayer);
    }

    
    void Update()
    {
        
    }
}
