using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Create New Card")]

public class Card : ScriptableObject
{
    public int id;
    public string cardName;
    public string cardDesc;
    public int timeAffect;
    public int bidValue;
    public int cardEffect;
    //can write different effects to correspond to different numbers.
    //for example, cardEffect would = 1 if we want it to shuffle the opponent's cards.
    //It would = 2 if we want it to shuffle all of your own cards. etc
    //for bid cards, keep this value 0
    public Sprite image;
}
