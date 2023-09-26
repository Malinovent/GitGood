using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(float direction)
    {
        //rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed * -direction, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Option 2
        Health health = collision.GetComponent<Health>();

        if(health != null)
        {
            health.TakeDamage(damage);
            Destroy(this.gameObject);
        }

        /*
        //Option 1
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            Destroy(this.gameObject);
        }*/
    }


}
