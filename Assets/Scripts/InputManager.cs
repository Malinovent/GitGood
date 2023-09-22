using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{

    [SerializeField] FiringBehaviour firingBehaviour;
    [SerializeField] Movement2DRigidbody playerMovement;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            //Fire Projectile!!!
            firingBehaviour.FireProjectile();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerMovement.Jump();
        }

        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        Debug.Log(horizontalAxis);
        playerMovement.Move(horizontalAxis);

    }
}
 