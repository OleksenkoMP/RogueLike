using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * 2);
    }
}
