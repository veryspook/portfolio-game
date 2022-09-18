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
    public List<string> garbageNames;
    public List<string> valuableNames;
    public List<string> treasureNames;
    public List<string> heirloomNames;

    public List<string> rarityNames;

    public int artifactValue;
    public string rarity;
    public int bidNumber;
    public int points;

    public TextMeshProUGUI artifactText;
    public GameObject artifactSprite;
    public TextMeshProUGUI bidText;
    public TextMeshProUGUI pointsText;


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

    public void OnTurnStart()
    {
        points += artifactValue;
        pointsText.text = $"{points}";
        Debug.Log(artifactValue);
        bidNumber = 0;
        bidText.text = $"{bidNumber}";
        CreateArtifact();
    }

    public void ChangeBid(int bid)
    {
        bidNumber += bid;
        bidText.text = $"{bidNumber}";
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        OnTurnStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
