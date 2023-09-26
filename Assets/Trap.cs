using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    private void OnTriggerStay2D(Collider2D other)
    {
        Health health = other.GetComponent<Health>();
        if(health)
        {
            health.TakeDamage(damage);
        }
    }
}
