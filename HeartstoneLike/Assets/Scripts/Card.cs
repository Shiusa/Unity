using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card/New Card")]
public class Card : ScriptableObject
{
    public string name;
    public string description;

    public Sprite visual;

    public int attack;
    public int hp;
    public int mana;

}
