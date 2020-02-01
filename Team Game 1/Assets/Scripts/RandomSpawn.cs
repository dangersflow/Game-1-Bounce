using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    float timeLeft;
    GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        //set the timer to 3 seconds
        timeLeft = 3;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0){
        //"spawn an object"
            if(transform.childCount > 0){
                //get the first child
                ball = transform.GetChild(0).gameObject;
                //detach it from the parent
                ball.transform.parent = null;
                //enable the script
                ball.GetComponent<Bounce>().enabled = true;
            }
            else{
                //once there is no children, then disable script
                transform.GetComponent<RandomSpawn>().enabled = false;
            }
        //reset the timer to 3
        timeLeft = 3;
        }   
    }
}
