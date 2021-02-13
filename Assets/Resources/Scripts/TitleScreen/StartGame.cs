using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            animator.SetTrigger("FadeTrigger");
            Invoke("Load", 1f);
        }
    }


    void Load()
    {
        SceneManager.LoadScene("MainScene");
    }
}
