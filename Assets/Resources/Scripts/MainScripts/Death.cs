using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public DontDestroyIt memoryHolder;
    public Stats stats;
    public CardHolder cardHolder;

    public Animator animator;

    private void Start()
    {
        memoryHolder = GameObject.FindGameObjectWithTag("MemoryHolder").GetComponent<DontDestroyIt>();
    }
    public void PlayerDies()
    {
        //save and update stats with cards
        cardHolder.MoveCards();

        memoryHolder.C1 = stats.C1.card;
        memoryHolder.C2 = stats.C2.card;
        memoryHolder.C3 = stats.C3.card;

        memoryHolder.STR = stats.STR + 2;
        memoryHolder.DEX = stats.DEX + 2;
        memoryHolder.CON = stats.CON;
        memoryHolder.INT = stats.INT;
        memoryHolder.WIS = stats.WIS;
        memoryHolder.CHA = stats.CHA;

        //play animations
        animator.SetTrigger("Died");

        //create new map
        Invoke("Load", 2.6f);


    }

    void Load()
    {
        SceneManager.LoadScene("MainScene");
    }
}
