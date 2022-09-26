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
            GameManager.instance.ChangeBid(card.bidValue);
            HandManager.instance.tempHand.Add(card);
        }
            Destroy(this.gameObject);
            HandManager.instance.Remove(card);
    }
}
