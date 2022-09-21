using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public Card card;

    public void UseCard()
    {
        Destroy(this.gameObject);
        HandManager.instance.Remove(card);
    }
}
