using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int STR_Base;
    public int DEX_Base;
    public int CON_Base;
    public int INT_Base;
    public int WIS_Base;
    public int CHA_Base;

    public int maxHP;
    public int damageM;
    public int damageR;
    public float movSpeed;
    public float WRSize;
    public float WMSize;

    public int curHP;
    public float moveSpeed = 2f;


    public GameObject Player;

    private void Start()
    {
        maxHP = STR_Base * 6;

        curHP = maxHP;

        damageM = DEX_Base * 4;
        damageR = CON_Base * 4;
        movSpeed = INT_Base * 0.02f;
        WRSize = WIS_Base * 0.01f;
        WMSize = CHA_Base * 0.01f;

        moveSpeed = movSpeed;

        Player = GameObject.Find("Player");
    }

    public void TakeDamage(int damage)
    {
        curHP -= damage;
        if (curHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        rb.velocity = new Vector2(0, 0);
        rb.AddForce(new Vector2(0, 0));
        if (curHP > 0) transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, 0.001f);

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(Random.Range(damageM - 12, damageM + 6));
        }
    }

    public Rigidbody2D rb;
}
