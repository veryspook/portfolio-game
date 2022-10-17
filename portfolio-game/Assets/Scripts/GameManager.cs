using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //DO NOT TURN TO STATIC it will remove all the existing values
    public List<GameObject> artifacts;
    public List<Image> angelSprites;
    public List<Image> demonSprites;
    public List<Image> eldritchSprites;
    public List<Image> druidSprites;
    public List<string> garbageNames;
    public List<string> valuableNames;
    public List<string> treasureNames;
    public List<string> heirloomNames;

    public List<string> rarityNames;

    public int artifactValue;
    public string rarity;
    public int tempBidNumber;
    public int bidNumber;
    public int points;
    public int roundCounter;

    public GameObject cancelButton;
    public GameObject player;
    public GameObject opponent1;
    public GameObject opponent2;
    public GameObject opponent3;
    public TextMeshProUGUI artifactText;
    public GameObject artifactSprite;
    public TextMeshProUGUI bidText;
    public TextMeshProUGUI tempBidText;
    public TextMeshProUGUI pointsText;

    public TextMeshProUGUI roundText;
    public TextMeshProUGUI artifactValueText;

    public GameObject handManager;
    public GameObject OpponentManager;

    public OpponentManager opponentManagerScript;

    System.Random rnd = new System.Random();

    public void CreateArtifact()
    {
        //Gets reference to artifact from list
        GameObject artifactRef = artifacts[rnd.Next(artifacts.Count)];

        //changes sprite in scene to artifact sprite
        artifactSprite.GetComponent<Image>().sprite = artifactRef.GetComponent<SpriteRenderer>().sprite;

        artifactValue = rnd.Next(100, 400);

        if (artifactValue <= 175)
        {
            rarity = "Garbage";
            rarityNames = garbageNames;
        }
        else if (175 < artifactValue && artifactValue <= 250)
        {
            rarity = "Valuable";
            rarityNames = valuableNames;
        }
        else if (250 < artifactValue && artifactValue <= 325)
        {
            rarity = "Treasure";
            rarityNames = treasureNames;
        }
        else
        {
            rarity = "Heirloom";
            rarityNames = heirloomNames;
        }

        //changes text in scene to randomly generated artifact name
        artifactText.text = artifactRef.name + " of " + rarityNames[rnd.Next(rarityNames.Count)];
    }

    public void OnRoundStart()
    {
        roundCounter += 1;
        if (bidNumber > opponentManagerScript.op1Bid && bidNumber > opponentManagerScript.op2Bid && bidNumber > opponentManagerScript.op3Bid)
        {
            points += artifactValue;
        }
        pointsText.text = $"{points}";
        //Debug.Log(artifactValue);
        handManager.GetComponent<Deck>().GenerateDeck();
        HandManager.instance.ShowHand();
        OpponentManager.GetComponent<OpponentManager>().RoundStart();
        //Calls RoundStart() in OpponentManager to activate AI behavoir (such as getting points if they win) per round- which is every 3 turns.
        bidNumber = 0;
        tempBidNumber = 0;
        bidText.text = $"{bidNumber}";
        tempBidText.text = $"{tempBidNumber}";
        CreateArtifact();
        artifactValueText.text = $"{artifactValue}";
        roundText.text = "Round " + roundCounter + "/3";
        //roundCounter int used to count up amount of rounds passed. Clears every 3 rounds passed to dictate when a round is over and begin a new one.
    }

    public void OnTurnStart()
    {
        tempBidNumber = 0;
        tempBidText.text = $"{tempBidNumber}";
        handManager.GetComponent<Deck>().GenerateDeck();
        HandManager.instance.ShowHand();
        OpponentManager.GetComponent<OpponentManager>().TurnStart();
        //Calls TurnStart() in OpponentManager to activate AI bids per turn.
    }

    public void ConfirmBid()
    {
        cancelButton.SetActive(false);
        bidNumber += tempBidNumber;
        tempBidNumber = 0;
        bidText.text = $"{bidNumber}";
        tempBidText.text = $"{tempBidNumber}";
        HandManager.instance.tempHand = new List<Card>();
    }

    public void RejectBid()
    {
        cancelButton.SetActive(false);
        tempBidNumber = 0;
        tempBidText.text = $"{tempBidNumber}";
        foreach (var Card in HandManager.instance.tempHand)
        {
            HandManager.instance.Add(Card);
        }
        HandManager.instance.tempHand = new List<Card>();
        HandManager.instance.ShowHand();
    }

    public void ChangeBid(int bid)
    {
        cancelButton.SetActive(true);
        tempBidNumber += bid;
        if (tempBidNumber > 0)
            tempBidText.text = $"+{tempBidNumber}";
        if (tempBidNumber < 0)
            tempBidText.text = $"{tempBidNumber}";
        if (tempBidNumber == 0)
        {
            tempBidText.text = $"{tempBidNumber}";
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        roundCounter = 0;
        instance = this;
        OnRoundStart();
        if (SharedDeckManager.amountOfPlayers == 2)
        {
            opponent2.SetActive(true);
            opponent3.SetActive(false);
        }
        if (SharedDeckManager.amountOfPlayers == 3)
        {
            opponent2.SetActive(true);
            opponent3.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
