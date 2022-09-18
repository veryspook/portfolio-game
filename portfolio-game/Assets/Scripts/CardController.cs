using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public Card card;

    public void UseCard()
    {
        if (card.bidValue > 0)
        {
            Debug.Log(card.bidValue);
            GameManager.instance.ChangeBid(card.bidValue);
        }
        Destroy(this.gameObject);
        HandManager.instance.Remove(card);
    }
}
