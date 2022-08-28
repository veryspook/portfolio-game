using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandManager : MonoBehaviour
{
    public static HandManager Instance;
    public List<Card> Hand = new List<Card>();

    public Transform HandContent;
    public GameObject CardInHand;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Card card)
    {
        Hand.Add(card);
    }

    public void Remove(Card card)
    {
        Hand.Remove(card);
    }

    public void ShowHand()
    {
        foreach (Transform card in HandContent)
        {
            Destroy(card.gameObject);
        }
        foreach (var card in Hand)
        {
            GameObject obj = Instantiate(CardInHand, HandContent);
            var cardName = obj.transform.Find("CardText").GetComponent<TMPro.TextMeshProUGUI>();
            var cardImage = obj.transform.Find("CardImage").GetComponent<Image>();

            cardName.text = card.cardName;
            cardImage.sprite = card.image;
        }
    }
}