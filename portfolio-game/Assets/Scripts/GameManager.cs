using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public List<List<string>> rarityNames = new List<List<string>>();
    public TextMeshProUGUI artifactText;
    public TextMeshProUGUI bidText;
    public int bidNumber;

    System.Random rnd = new System.Random();

    public void CreateArtifact()
    {
        //Gets reference to artifact from list
        GameObject artifactRef = artifacts[rnd.Next(artifacts.Count)];

        //Creates artifact in scene
        GameObject artifact = Instantiate(artifactRef, new Vector3(0, 0, 0), Quaternion.identity);
        artifact.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        //List<string> rarityNames = namesList[rnd.Next(0,3)];
        List<string> getNames = rarityNames[rnd.Next(rarityNames.Count)];

        artifactText.text = artifactRef.name + " of " + getNames[rnd.Next(getNames.Count)];
        //Debug.Log(rarityNames);
    }

    void OnTurnStart()
    {
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
        rarityNames.Add(garbageNames);
        rarityNames.Add(valuableNames);
        rarityNames.Add(treasureNames);
        rarityNames.Add(heirloomNames);
        OnTurnStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
