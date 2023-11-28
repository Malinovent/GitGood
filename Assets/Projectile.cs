using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] ParticleSystem particles;
    [SerializeField] string soundEffectName = "fireball";

    private Rigidbody2D rb;
    private Queue<GameObject> pool;

    public Action<GameObject> OnDeactivated;

    Coroutine coroutine;

    // Start is called before the first frame update
    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        //Invoke("ReturnToPool", 10);
        coroutine = StartCoroutine(ProjectileLifetimeCoroutine());
    }

    IEnumerator ProjectileLifetimeCoroutine()
    {
        yield return new WaitForSeconds(10);
        OnDeactivated?.Invoke(this.gameObject);
    }



    public void SetDirection(float direction)
    {
        //rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed * -direction, 0);
    }

    public void PassPool(Queue<GameObject> poolQueue)
    {
        pool = poolQueue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Option 2
        Health health = collision.GetComponent<Health>();

        if(health != null)
        {
            health.TakeDamage(damage);
            AudioManager.Singleton.PlaySoundEffect(soundEffectName);

            //Create particle system
            GameObject particleGO = Instantiate(particles.gameObject);
            particleGO.transform.position = this.transform.position;
            Destroy(particleGO, 2);

            OnDeactivated?.Invoke(this.gameObject);
            StopCoroutine(coroutine);
        }
    }




}
