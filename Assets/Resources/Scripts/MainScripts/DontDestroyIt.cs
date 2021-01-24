using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyIt : MonoBehaviour
{
    public CardsTemplate C1;
    public CardsTemplate C2;
    public CardsTemplate C3;

    public int STR;
    public int DEX;
    public int CON;
    public int INT;
    public int WIS;
    public int CHA;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
