using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    float timeToShake;
    // Start is called before the first frame update
    void Start()
    {
        timeToShake = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        timeToShake -= Time.deltaTime;
        if(timeToShake <= 0){
            Debug.Log("Finished!");
            GetComponent<CameraShake>().enabled = false;
        }
    }
}
