
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 2f;

    public Rigidbody2D rb;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    Vector2 movement;

    public SpriteRenderer spriteRenderer;

    public Animator weaponAnimator;

    public int maxHP;
    public int damageM;
    public int damageR;
    public float movSpeed;
    public float WRSize;
    public float WMSize;

    public int curHP;

    public GameObject Sword;

    public void setHero(int a, int b, int c, float d, float e, float z)
    {
        maxHP = a;

        curHP = maxHP;

        damageM = b;
        damageR = c;
        movSpeed = d;
        WRSize = e;
        WMSize = z;


        moveSpeed = movSpeed;
        Sword.transform.localScale = new Vector3(WMSize, WMSize, 1f);
}

    void Update()
    {
        rb.velocity = new Vector2(0,0);
        rb.AddForce(new Vector2(0,0));
        if(Input.GetMouseButtonDown(0))
        {
            weaponAnimator.SetTrigger("Attack");
            Attack();
        }
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");
       
    }
  
    void FixedUpdate()
    {
        if (movement.x < 0)
        {
            animator.SetTrigger("Walking");
            spriteRenderer.flipX = true;
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        else if (movement.x > 0)
        {
            
            animator.SetTrigger("Walking");
            spriteRenderer.flipX = false;
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        else if(movement.y >0 || movement.y <0)
        {
            animator.SetTrigger("Walking");
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            animator.SetTrigger("Idle");
        }
    }
    void Attack()
    {
       Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
       
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(Random.Range(damageM - 12, damageM + 6));
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    public Death death;
    public void TakeDamage(int damage)
    {
        curHP -= damage;
        if (curHP <= 0)
        {
            death.PlayerDies();
        }
    }

}
