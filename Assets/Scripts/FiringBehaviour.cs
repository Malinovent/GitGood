using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private int initialPoolSize = 5;

    public Queue<GameObject> projectilePool = new Queue<GameObject>();
    private GameObject projectileParent;

    private void Awake()
    {
        projectileParent = new GameObject();
        projectileParent.name = "Projectile Pool";

        CreateProjectiles(initialPoolSize);
    }

    private void CreateProjectiles(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject projectileGO = Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity);
            projectilePool.Enqueue(projectileGO);
            projectileGO.SetActive(false);
            projectileGO.transform.parent = projectileParent.transform;
            projectileGO.GetComponent<Projectile>().OnDeactivated += ReturnToPool;
            //projectileGO.GetComponent<Projectile>().PassPool(projectilePool);
        }
    }

    public void FireProjectile()
    {

        if(projectilePool.Count <= 0)
        {
            //Create more projectiles
            CreateProjectiles(5);
        }
        
        GameObject go = projectilePool.Dequeue();

        go.SetActive(true);
        go.transform.position = projectileSpawnPoint.position;
        go.GetComponent<Projectile>().SetDirection(this.transform.localScale.x);
    }

    private void ReturnToPool(GameObject gameObject)
    {
        projectilePool.Enqueue(gameObject);
    }
}
