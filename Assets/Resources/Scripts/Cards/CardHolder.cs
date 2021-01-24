using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHolder : MonoBehaviour
{ 
    public CardsTemplate[] AllCards;

    public CardsTemplate card_1;
    public CardsTemplate card_2;
    public CardsTemplate card_3;

    public CardHandler C1;
    public CardHandler C2;
    public CardHandler C3;

    public Stats stats;

    private void Start()
    {
        DontDestroyIt memoryHolder = GameObject.FindGameObjectWithTag("MemoryHolder").GetComponent<DontDestroyIt>();

        card_1 = memoryHolder.C1;
        card_2 = memoryHolder.C2;
        card_3 = memoryHolder.C3;

        C1.card = card_1;
        C2.card = card_2;
        C3.card = card_3;

        C1.ShowCard();
        C2.ShowCard();
        C3.ShowCard();

        stats.CardEffect();
    }
    public void MoveCards()
    {
        card_1 = C1.card;
        card_2 = C2.card;
        card_3 = C3.card;

        C1.card = AllCards[Random.Range(0, AllCards.Length - 1)];
        C2.card = card_1;
        C3.card = card_2;

        C1.ShowCard();
        C2.ShowCard();
        C3.ShowCard();

        stats.CardEffect();
    }
}
