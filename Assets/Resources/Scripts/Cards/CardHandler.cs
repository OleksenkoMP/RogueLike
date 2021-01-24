using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardHandler : MonoBehaviour
{
    public CardsTemplate card;

    public int cardNum;

    public GameObject CardName;
    public GameObject Value;
    public Image ArtWork;
    public Image Sh;
    public Image Icon;
    public Image Frame;

    public Sprite ClosedCard;
    public Sprite OpenCard;

    void Start()
    {
        ShowCard();
    }

    public void ShowCard()
    {
        if (card != null)
        {
            Frame.sprite = OpenCard;
            Icon.sprite = card.Icon;
            ArtWork.sprite = card.ArtWork;
            Sh.sprite = card.ArtWork;
            CardName.GetComponent<TextMeshPro>().text = card.CardName;
            switch (cardNum)
            {
                case 1:
                    SetTextForCard1();
                    break;
                case 2:
                    Value.GetComponent<TextMeshPro>().text = "+" + card.Value2.ToString();
                    break;
                case 3:
                    Value.GetComponent<TextMeshPro>().text = "+" + card.Value3.ToString();
                    break;
                default:
                    break;
            }
        }
        else
            Frame.sprite = ClosedCard;
    }

    void SetTextForCard1()
    {
        switch (card.ÑharacteristicId)
        {
            case 0:
                Value.GetComponent<TextMeshPro>().text = "STR +" + card.Value1.ToString();
                break;
            case 1:
                Value.GetComponent<TextMeshPro>().text = "DEX +" + card.Value1.ToString();
                break;
            case 2:
                Value.GetComponent<TextMeshPro>().text = "CON +" + card.Value1.ToString();
                break;
            case 3:
                Value.GetComponent<TextMeshPro>().text = "INT +" + card.Value1.ToString();
                break;
            case 4:
                Value.GetComponent<TextMeshPro>().text = "WIS +" + card.Value1.ToString();
                break;
            case 5:
                Value.GetComponent<TextMeshPro>().text = "CHA +" + card.Value1.ToString();
                break;
            default:
                break;
        }
    }
}
