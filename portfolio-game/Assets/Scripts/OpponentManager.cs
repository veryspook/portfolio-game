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
    public int op1Points;
    public int op1Bid;
    private bool op1Active;

    public GameObject opponent2;
    public TextMeshProUGUI op2PointsText;
    public TextMeshProUGUI op2BidText;
    public int op2Points;
    public int op2Bid;
    private bool op2Active;

    public GameObject opponent3;
    public TextMeshProUGUI op3PointsText;
    public TextMeshProUGUI op3BidText;
    public int op3Points;
    public int op3Bid;
    private bool op3Active;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
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

    // Update is called once per frame
    void Update()
    {

    }
}
