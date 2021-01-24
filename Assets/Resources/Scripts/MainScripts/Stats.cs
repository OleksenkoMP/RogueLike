using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    //Base
    public int STR_Base;
    public int DEX_Base;
    public int CON_Base;
    public int INT_Base;
    public int WIS_Base;
    public int CHA_Base;

    //After all boosts
    public int STR;
    public int DEX;
    public int CON;
    public int INT;
    public int WIS;
    public int CHA;


    public CardHandler C1;
    public CardHandler C2;
    public CardHandler C3;


    public void CardEffect()
    {
        STR = STR_Base;
        DEX = DEX_Base;
        CON = CON_Base;
        INT = INT_Base;
        WIS = WIS_Base;
        CHA = CHA_Base;

        if (C1.card != null)
        {
            SetCardEffect(C1.card, 1);
        }
        if (C2.card != null)
        {
            SetCardEffect(C2.card, 2);
        }
        if (C3.card != null)
        {
            SetCardEffect(C3.card, 3);
        }
    }

    private void SetCardEffect(CardsTemplate card, int cardNum)
    {
        switch (card.ÑharacteristicId)
        {
            case 0:
                STR += ChooseValue(card, cardNum);
                break;
            case 1:
                DEX += ChooseValue(card, cardNum);
                break;
            case 2:
                CON += ChooseValue(card, cardNum);
                break;
            case 3:
                INT += ChooseValue(card, cardNum);
                break;
            case 4:
                WIS += ChooseValue(card, cardNum);
                break;
            case 5:
                CHA += ChooseValue(card, cardNum);
                break;
            default:
                break;
        }
    }
    private int ChooseValue(CardsTemplate curCcard, int id)
    {
        switch (id)
        {
            case 1:
                return curCcard.Value1;
            case 2:
                return curCcard.Value2;
            case 3:
                return curCcard.Value3;
            default:
                return 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyIt memoryHolder = GameObject.FindGameObjectWithTag("MemoryHolder").GetComponent<DontDestroyIt>();
        
        STR_Base = memoryHolder.STR;
        DEX_Base = memoryHolder.DEX;
        CON_Base = memoryHolder.CON;
        INT_Base = memoryHolder.INT;
        WIS_Base = memoryHolder.WIS;
        CHA_Base = memoryHolder.CHA;
        
        CardEffect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
