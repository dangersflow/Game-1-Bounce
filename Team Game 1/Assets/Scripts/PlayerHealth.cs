using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    float lives = 4;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void loseLife(){
        lives -= 1;
    }

    public float health(){
        return lives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
