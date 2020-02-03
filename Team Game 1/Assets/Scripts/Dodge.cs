using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    Vector3 direction;
    float speed;
    float cooldown;
    public AudioSource laser;
    // Start is called before the first frame update
    void Start()
    {
        //cool down is to keep from user spamming the dodge!
        cooldown = 0.0f;
        speed = 15.0f;
        direction = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //dodge distance is simply the same movement with a multiplier applied
        //turns out that since the direction is so big, it emulates the effect of being invincible since 
        //the playerball never actually touches the enemy during this transformation
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.L) && cooldown <= 0.0f){
            direction = Vector3.up * 25;
            transform.position = transform.position + (direction * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.L) && cooldown <= 0.0f){
            direction = Vector3.down * 25;
            transform.position = transform.position + (direction * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.L) && cooldown <= 0.0f){
            direction = Vector3.left * 25;
            transform.position = transform.position + (direction * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.L) && cooldown <= 0.0f){
            direction = Vector3.right * 25;
            transform.position = transform.position + (direction * speed * Time.deltaTime);
        }

        //cooldown occurs
        //check also for cooldown already occuring so as to not keep cooldown at 2.0f
        //if user holds down L
        if(Input.GetKey(KeyCode.L) && cooldown <= 0.0f){
            laser.Play();
            cooldown = 1.0f;
        }
        cooldown -= Time.deltaTime;
        direction = Vector3.zero;
        //debug to show cooldown time actually working
        //Debug.Log("cooldown : " + cooldown);
    }
}