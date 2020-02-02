using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    float timeToShake;
    float frequency;
    Vector3 originalCamPos;
    // Start is called before the first frame update
    void Start()
    {
        timeToShake = 0.0f;
        frequency = 25f;
        originalCamPos = transform.position;
    }

    private void OnEnable() {
        timeToShake = 0.5f;
    }

    public void shakeFor(float time){
        timeToShake = time;
    }

    // Update is called once per frame
    void Update()
    {
        timeToShake -= Time.deltaTime;
        if(timeToShake <= 0){
            Debug.Log("Finished!");
            //reset camera position
            transform.position = new Vector3(0, 0, -10);
            Debug.Log("Original Position: " + transform.position);
        }
        if(timeToShake > 0){
        transform.position = new Vector3(
            Mathf.PerlinNoise(0, Time.time * frequency) * 2 - 1, 
            Mathf.PerlinNoise(1, Time.time * frequency) * 2 - 1, 
            -10) * 0.5f;
        }
    }
}
