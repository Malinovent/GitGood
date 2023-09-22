using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    // Update is called once per frame
    void Update()
    {
       
        //Move up
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }

        //Move down
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
        }

        //Move left
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        //Move right
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }

    }
}
