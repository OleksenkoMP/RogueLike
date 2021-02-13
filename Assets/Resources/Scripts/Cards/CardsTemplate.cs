using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardsTemplate : ScriptableObject
{
    public string CardName;

    public int ÑharacteristicId;


    public int Value1;
    public int Value2;
    public int Value3;
    
    public string Desc;

    public Sprite ArtWork;
    public Sprite Icon;
}
