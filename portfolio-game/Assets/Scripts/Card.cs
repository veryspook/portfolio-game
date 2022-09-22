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
    //we can use ints to identify various card effects. (ex. if cardEffect = 1, then the player's deck will reshuffle. Keep as 0 if no card effect.)
    public Sprite image;
}
