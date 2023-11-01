using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInputAudio : MonoBehaviour
{
       // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            AudioManager.Singleton.PlaySoundEffect("fireball");
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            AudioManager.Singleton.PlaySoundEffect("iceball");
        }
    }
}
