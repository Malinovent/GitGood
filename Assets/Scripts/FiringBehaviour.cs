using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform projectileSpawnPoint;

    public void FireProjectile()
    {

        GameObject go = Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity);

        go.GetComponent<Projectile>().SetDirection(this.transform.localScale.x);
       
        
    }
}
