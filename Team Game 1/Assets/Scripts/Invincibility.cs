using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    float invincibilityTime = 4;
    float blinkTime = 0.1f;
    SpriteRenderer mainSprite;

    // Start is called before the first frame update
    void Start()
    {
        mainSprite = GetComponent<SpriteRenderer>();
        //GetComponent<Invincibility>().enabled = false;
    }

    void OnEnable() {
        invincibilityTime = 4;
        blinkTime = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Invincibility: " + invincibilityTime);
        invincibilityTime -= Time.deltaTime;
        blinkTime -= Time.deltaTime;
        if(blinkTime <= 0){
            mainSprite.enabled = !mainSprite.enabled;
            blinkTime = 0.1f;
        }
        if(invincibilityTime <= 0){
            GetComponent<Invincibility>().enabled = false;
            mainSprite.enabled = true;
        }
    }
}
