using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Create New Card")]

public class Card : ScriptableObject
{
    public int id;
    public string cardName;
    public string cardDesc;
    public int bidValue;
    public Sprite image;
}
