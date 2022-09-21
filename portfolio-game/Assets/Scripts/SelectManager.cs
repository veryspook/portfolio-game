using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OneOpponent()
    {
        SceneManager.LoadScene("SampleScene");
        SharedDeckManager.amountOfPlayers += 1;
    }

    public void TwoOpponent()
    {
        SceneManager.LoadScene("SampleScene");
        SharedDeckManager.amountOfPlayers += 2;
    }

    public void ThreeOpponent()
    {
        SceneManager.LoadScene("SampleScene");
        SharedDeckManager.amountOfPlayers += 3;
    }
}
