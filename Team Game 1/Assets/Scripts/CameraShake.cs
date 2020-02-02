using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    float timeToShake;
    float frequency;
    // Start is called before the first frame update
    void Start()
    {
        timeToShake = 0.5f;
        frequency = 25f;
    }

    private void OnEnable() {
        timeToShake = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        timeToShake -= Time.deltaTime;
        if(timeToShake <= 0){
            Debug.Log("Finished!");
            GetComponent<CameraShake>().enabled = false;
        }
        transform.position = new Vector3(
            Mathf.PerlinNoise(0, Time.time * frequency) * 2 - 1, 
            Mathf.PerlinNoise(1, Time.time * frequency) * 2 - 1, 
            -10) * 0.5f;
    }
}
