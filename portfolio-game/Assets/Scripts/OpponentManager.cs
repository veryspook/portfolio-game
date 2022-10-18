using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class OpponentManager : MonoBehaviour
{
    public static OpponentManager instance;

    public GameObject opponent1;
    public TextMeshProUGUI op1PointsText;
    public TextMeshProUGUI op1BidText;
    [SerializeField] public int op1Points;
    [SerializeField] public int op1Bid;
    private bool op1Active;

    public GameObject opponent2;
    public TextMeshProUGUI op2PointsText;
    public TextMeshProUGUI op2BidText;
    [SerializeField] public int op2Points;
    [SerializeField] public int op2Bid;
    private bool op2Active;

    public GameObject opponent3;
    public TextMeshProUGUI op3PointsText;
    public TextMeshProUGUI op3BidText;
    [SerializeField] public int op3Points;
    [SerializeField] public int op3Bid;
    private bool op3Active;

    

    private int aiBidDecider;
    private int aiBidDecider2;
    private int aiBidDecider3;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
        if (opponent1.activeInHierarchy)
        {
            op1Active = true;
        }
        if (opponent2.activeInHierarchy)
        {
            op2Active = true;
        }
        if (opponent3.activeInHierarchy)
        {
            op3Active = true;
        }
    }

    //These selections check if the opponents are active in the scene based on what mode the player selected in the main menu.

    // Update is called once per frame
    void Update()
    {

    }

    public void RoundStart()
    {
        if (op1Active == true)
        {
            if (op1Bid > op2Bid && op1Bid > op3Bid && op1Bid > gameManager.bidNumber)
            {
                op1Points += gameManager.artifactValue;
                
            }
            op1PointsText.text = $"{op1Points}";
            op1Bid = 0;
            op1BidText.text = $"{op1Bid}";
        }

        if (op2Active == true)
        {
            if (op2Bid > op1Bid && op2Bid > op3Bid && op2Bid > gameManager.bidNumber)
            {
                op2Points += gameManager.artifactValue;
                
            }
            op2PointsText.text = $"{op2Points}";
            op2Bid = 0;
            op2BidText.text = $"{op2Bid}";
        }

        if (op3Active == true)
        {
            if (op3Bid > op1Bid && op3Bid > op2Bid && op3Bid > gameManager.bidNumber)
            {
                op3Points += gameManager.artifactValue;
               
            }
            op3PointsText.text = $"{op3Points}";
            op3Bid = 0;
            op3BidText.text = $"{op3Bid}";
        }
    }

    //starts every new artifact. Check if opponent is active. If opponent's bid is above all others, opponent receives points. If not, points remain the same. Bid set back to 0.

    public void TurnStart()
    {
        if (op1Active == true)
        {
            
            AIBid();
            op1Bid += aiBidDecider;
            op1BidText.text = $"{op1Bid}";
            
        }

        if (op2Active == true)
        {
            
            AIBid2();
            op2Bid += aiBidDecider2;
            op2BidText.text = $"{op2Bid}";
            
        }

        if (op3Active == true)
        {
            
            AIBid3();
            op3Bid += aiBidDecider3;
            op3BidText.text = $"{op3Bid}";
            
        }
    }

    //starts every turn (every time timer counts down). Check if opponent is active. Calls corresponding AIBid functions to determine random bid choice.

    private void AIBid()
    {
        aiBidDecider = Random.Range(1, 10);
        if (aiBidDecider <= 4)
        {
            aiBidDecider += aiBidDecider*40;
        }
        else
        {
            aiBidDecider += aiBidDecider*30;
        }
    }
    private void AIBid2()
    {
        aiBidDecider2 = Random.Range(1, 10);
        if (aiBidDecider2 <= 4)
        {
            aiBidDecider2 += aiBidDecider2*40;
        }
        else
        {
            aiBidDecider2 += aiBidDecider2*30;
        }
    }
    private void AIBid3()
    {
        aiBidDecider3 = Random.Range(1, 10);
        if (aiBidDecider3 <= 4)
        {
            aiBidDecider3 += aiBidDecider3*40;
        }
        else
        {
            aiBidDecider3 += aiBidDecider3*30;
        }
    }
    //AIBid with a different function for each AI opponent to seperate values. creates some random bid values for the bots.

    
}
