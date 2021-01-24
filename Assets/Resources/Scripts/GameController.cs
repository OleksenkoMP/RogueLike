using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Animator InventoryAnimator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InventoryAnimator.SetTrigger("Trigger1");
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            InventoryAnimator.SetTrigger("Trigger2");
        }
    }
}
