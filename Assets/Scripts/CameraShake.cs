using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 initialPosition;

    private bool isShakingCamera = false;
    private float intensity, duration;
    private float timePassed = 0;

    private void Awake()
    {
        initialPosition = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            ShakeCamera(1, 0.2f);
        }


        if(isShakingCamera)
        {
            timePassed += Time.deltaTime;

            this.transform.position = initialPosition + (Random.insideUnitSphere * intensity);

            if(timePassed > duration)
            {
                isShakingCamera = false;
                this.transform.position = initialPosition;
                
            }
        }
    }

    public void ShakeCamera(float intensity, float duration)
    {
        isShakingCamera = true;
        initialPosition = this.transform.position;
        this.duration = duration;
        this.intensity = intensity;
        timePassed = 0;
    }
}
