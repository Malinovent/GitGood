using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;

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

    
}
