using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{

    [SerializeField] FiringBehaviour firingBehaviour;
    [SerializeField] Movement2DRigidbody playerMovement;
    [SerializeField] PauseMenuController pauseMenuController;


    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Home))
        {
            GameManager.Singleton.SwitchScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.Singleton.SwitchScene(1);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            //Fire Projectile!!!
            firingBehaviour.FireProjectile();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerMovement.Jump();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuController.ToggleMenu();
        }

        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        //Debug.Log(horizontalAxis);
        playerMovement.Move(horizontalAxis);

    }
}
 